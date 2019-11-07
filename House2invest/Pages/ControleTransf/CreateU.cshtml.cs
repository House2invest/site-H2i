using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.ControleTransf
{
    [Authorize]
    public class CreateUModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly Data.ApplicationDbContext _context;
        public CreateUModel(IHttpContextAccessor accessor, Data.ApplicationDbContext context) { _context = context; _accessor = accessor; }
        [BindProperty]
        public TransferenciaViewModel modelo { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            var _modelo =
                _context.Tranferencias
                .Include(x => x.BlocoProjInvestimentos)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var _usu = _context.Users
                .Where(x => x.Id == _modelo.IdUsu)
                .FirstOrDefault();

            if (_modelo == null || _usu == null)
                return NotFound();

            modelo = new TransferenciaViewModel()
            {
                Id = _modelo.Id,
                IDUSU = _usu.Id,
                Montante = _modelo.Valor
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // USUÁRIO LOGADO
            var _usu = _context.Users
                .Where(x => x.UserName == User.Identity.Name)
                .FirstOrDefault();

            var _config = _context.AppPerfil
                .Include(x => x.AppConfiguracoes)
                .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                .FirstOrDefault();

            var _atualizaTransf =
                _context.Tranferencias
                .Include(x => x.BlocoProjInvestimentos)
                .Where(x => x.Id == modelo.Id)
                .FirstOrDefault();

            var _errosValidacoes = false;
            if (modelo.ArquivoComprovTransf != null)
            {
                var _imagemLogotipo =
                    await VerificadoresRetornos
                    .EnviarImagemAzure(modelo.ArquivoComprovTransf, 614200, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                if (!_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                {
                    ModelState.AddModelError(string.Empty, "A imagem é muito grande");
                    _errosValidacoes = true;
                }
                else
                {
                    _atualizaTransf.URLComprovante = _imagemLogotipo;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Selecione uma imagem");
                _errosValidacoes = true;
            }

            if (_errosValidacoes)
            {
                return Page();
            }

            _context.Attach(_atualizaTransf).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            // PEGO O USUARIO DA TRANSFERENCIA, CASO EXISTA
            var _usuTransf = new UsuarioApp();
            if (!string.IsNullOrEmpty(_atualizaTransf.IdUsu))
            {
                _usuTransf = _context.Users
                    .Where(x => x.Id == _atualizaTransf.IdUsu)
                    .FirstOrDefault();
            }

            //// LOGCENTRAL
            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            {
                ICOMENS = "<i class='fas fa-image text-success'></i>",
                MENSAGEM = $"A transferência de <b>{_atualizaTransf.Valor.ToString("C2")}</b> para o investidor <b>{_usuTransf.Nome} {_usuTransf.Sobrenome}</b> foi <b style='color:green;'>EFETUADA COM SUCESSO</b>. O comprovante digitalizado da transação é <a href='{_atualizaTransf.URLComprovante}' target='_blank'>esse aqui</a>.",
                ACAO = $"ENVIO DE COMPROVANTE (TRANSFERÊNCIA)",
                DTHR = DateTime.Now,
                IP = _ips.FirstOrDefault(),
                STATUS = "TRANSFERIDO",
                TIPO = "CONFIRMAÇÕES",
                UsuarioAppId = !string.IsNullOrEmpty(_atualizaTransf.IdUsu) ? _atualizaTransf.IdUsu : "b1aadecb-4357-457d-bfea-27e153505497",
                VALOR = _atualizaTransf.Valor,
                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            }, _context);

            if (!string.IsNullOrEmpty(_atualizaTransf.IdUsu))
            {
                //--------------------------------
                // APLICACAO PADRAO
                //--------------------------------
                var _appPadrao =
                    _context.AppConfiguracoes_Aplicativo
                    .FirstOrDefault();

                string _textoEmail = $"Prezado {_usuTransf.Nome} <br>";
                _textoEmail += $"A transferência no valor de <b>{_atualizaTransf.Valor.ToString("C2")}</b> foi <b style='color:green;'>EFETUADA COM SUCESSO</b>. <br>";
                _textoEmail += $"Abaixo está o link com o comprovante: <br>";
                _textoEmail += $"<a href='{_atualizaTransf.URLComprovante}' target='_blank'>Comprovante</a> <br><br>";
                _textoEmail += $"Atenciosamente, <br>";
                _textoEmail += $"<b>Equipe House2invest</b> <br>";
                // instanciar objeto email
                var _objemail = new ObjetoEmailEnvio()
                {
                    ASSUNTO = "[STATUS INVESTIMENTO] House2Invest",
                    COPIA = _appPadrao.mailToAdd,
                    mailFrom = _appPadrao.mailFrom,
                    MENSAGEM = _textoEmail,
                    PARA = _usuTransf.Email,
                    smtpCredentialsEmail = _appPadrao.smtpCredentialsEmail,
                    smtpCredentialsSenha = _appPadrao.smtpCredentialsSenha,
                    smtpEnableSsl = _appPadrao.smtpEnableSsl,
                    smtpHost = _appPadrao.smtpHost,
                    smtpPort = _appPadrao.smtpPort,
                    smtpUseDefaultCredentials = _appPadrao.smtpUseDefaultCredentials
                };
                var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);

                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                {
                    ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                    MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _textoEmail + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog({_atualizaTransf.Id});' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                    ACAO = $"ENVIOU EMAIL",
                    DTHR = DateTime.Now,
                    IP = _ips.FirstOrDefault(),
                    STATUS = "ENVIADO",
                    TIPO = "NOTIFICAÇÃO",
                    UsuarioAppId = !string.IsNullOrEmpty(_atualizaTransf.IdUsu) ? _atualizaTransf.IdUsu : "b1aadecb-4357-457d-bfea-27e153505497",
                    VALOR = _atualizaTransf.Valor,
                    UsuarioAppCriadorId = _usu.Id
                }, _context);
            }

            //_context.LOGCENTRALs.Add(new LOGCENTRAL()
            //{
            //    ACAO = "TRANSFERÊNCIA INVESTIMENTO",
            //    INVEST_LancamentoId = 0,
            //    INVEST_ModeloDocId = 0,
            //    TP = "TRANSF",
            //    URLDOC = "",
            //    VALOR = _atualizaTransf.Valor,
            //    STATUS = "SUSPENSO",
            //    UsuarioAppId = _atualizaTransf.IdUsu,
            //    IP = _ips.FirstOrDefault()
            //});
            //await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}