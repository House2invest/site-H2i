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
namespace House2Invest.Pages.BlocosProjInvestValor
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly Data.ApplicationDbContext _context;
        public CreateModel(IHttpContextAccessor accessor, Data.ApplicationDbContext context) { _context = context; _accessor = accessor; }
        [BindProperty]
        public INVEST_LancamentoImagemViewModel modelo { get; set; }
        public IActionResult OnGet(int idlanc = 0)
        {
            if (idlanc <= 0)
            {
                return NotFound();
            }

            modelo = new INVEST_LancamentoImagemViewModel()
            {
                //UrlImgPrinc = "/temas/dpslintm1/assets/images/sem-imagem-modelo-projetos.png",
                //Ativo = true,
                ////Contador_DataFinal = $"{DateTime.Now.Year}/{DateTime.Now.AddMonths(1).Month.ToString("D2")}/{DateTime.Now.Day.ToString("D2")}",
                //Contador_DataFinal = $"{DateTime.Now.Day.ToString("D2")}/{DateTime.Now.AddMonths(6).Month.ToString("D2")}/{DateTime.Now.Year}",
                //Valor = "100.000,00",
                //LanceMinimo = "1.000,00",
                //ValorMinimoDocs = "10.000,00",
                //SaldoReservado = 0
                URLComprovTransf = "/temas/dpslintm1/assets/images/sem-imagem-modelo-projetos.png",
                URLPerfilInvest = "/temas/dpslintm1/assets/images/sem-imagem-modelo-projetos.png",
                INVEST_LancamentoId = idlanc
            };

            //ViewData["INVEST_ModeloDocId"] = new SelectList(_context.INVEST_ModeloDocs, "Id", "Titulo");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var _config = _context.AppPerfil
                .Include(x => x.AppConfiguracoes)
                .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                .FirstOrDefault();

            var _errosValidacoes = false;
            if (modelo.ArquivoComprovTransf != null)
            {
                var _imagemLogotipo =
                    await VerificadoresRetornos
                    .EnviarImagemAzure(modelo.ArquivoComprovTransf, 614200, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                    modelo.URLComprovTransf = _imagemLogotipo;
                else
                {
                    ModelState.AddModelError(string.Empty, "A imagem é muito grande");
                    _errosValidacoes = true;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Selecione uma imagem do seu computador");
                _errosValidacoes = true;
            }

            //if (modelo.ArquivoPerfilInvestidor != null)
            //{
            //    var _imagemLogotipo =
            //        await VerificadoresRetornos
            //        .EnviarImagemAzure(modelo.ArquivoPerfilInvestidor, 614200, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

            //    if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
            //        modelo.URLPerfilInvest = _imagemLogotipo;
            //    else
            //    {
            //        ModelState.AddModelError(string.Empty, "A imagem é muito grande");
            //        _errosValidacoes = true;
            //    }
            //}
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "Selecione uma imagem do seu computador");
            //    _errosValidacoes = true;
            //}

            //if (Convert.ToDouble(BlocoProjInvestimento.LanceMinimo) > Convert.ToDouble(BlocoProjInvestimento.Valor))
            //{
            //    ModelState.AddModelError(string.Empty, "O Lance mínimo deve ser INFERIOR ao VALOR TOTAL DO INVESTIMENTO");
            //    _errosValidacoes = true;
            //}

            //if (VerificadoresRetornos.ConverteStringParaDateTime(BlocoProjInvestimento.Contador_DataFinal) < DateTime.Now)
            //{
            //    ModelState.AddModelError(string.Empty, "A data limite do contador deve ser SUPERIOR a data de hoje");
            //    _errosValidacoes = true;
            //}

            //if (Convert.ToDouble(BlocoProjInvestimento.Valor) <= 0)
            //{
            //    ModelState.AddModelError(string.Empty, "Necessário: VALOR TOTAL DO INVESTIMENTO");
            //    _errosValidacoes = true;
            //}

            //if (Convert.ToDouble(BlocoProjInvestimento.LanceMinimo) <= 0)
            //{
            //    ModelState.AddModelError(string.Empty, "Necessário: VALOR LANCE MÍNIMO");
            //    _errosValidacoes = true;
            //}

            if (_errosValidacoes)
            {
                modelo.URLComprovTransf = @"/temas/dpslintm1/assets/images/sem-imagem-modelo-projetos.png";
                modelo.URLPerfilInvest = @"/temas/dpslintm1/assets/images/sem-imagem-modelo-projetos.png";
                return Page();
            }

            _context.INVEST_LancamentoImagens.Add(modelo);
            await _context.SaveChangesAsync();

            //var _enviou =
            //    await VerificadoresRetornos
            //    .EnviarEmail(_usuario.Email, "", "[INVESTIMENTO] House2Invest", string.Format($"Olá!!!{Environment.NewLine}<br/>Você fez um investimento de <b>{_valormoeda.ToString("C2")}</b> em <b>{_context.BlocoProjInvestimentos.Where(x => x.Id == Convert.ToInt32(_id)).FirstOrDefault().Titulo}</b>."));

            var _Lancamento =
                _context.INVEST_Lancamentos
                .Include(x => x.UsuarioApp)
                .Include(x => x.BlocoProjInvestimentos)
                .Where(x => x.Id == modelo.INVEST_LancamentoId)
                .FirstOrDefault();

            modelo.INVEST_Lancamento = _Lancamento;

            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            //// LOGCENTRAL
            await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
            {
                ICOMENS = "<i class='fas fa-image text-success'></i>",
                MENSAGEM = $"O usuário <b>{_Lancamento.UsuarioApp.Nome} {_Lancamento.UsuarioApp.Sobrenome}</b> <b style='color:green;'>ENVIOU</b> os comprovantes digitalizados para a reserva de <b>{_Lancamento.Valor.ToString("C2")}</b> na oferta <b>{_Lancamento.BlocoProjInvestimentos.Titulo}</b>.",
                ACAO = $"ENVIO DE IMAGEM (TED)",
                DTHR = DateTime.Now,
                IP = _ips.FirstOrDefault(),
                STATUS = "ENVIADO",
                TIPO = "CONFIRMAÇÕES",
                UsuarioAppId = _Lancamento.UsuarioAppId,
                VALOR = _Lancamento.Valor,
                UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
            }, _context);

            //_context.LOGCENTRALs.Add(new LOGCENTRAL()
            //{
            //    ACAO = "INVESTIMENTO - ENVIO DA IMAGEM (TED)",
            //    INVEST_LancamentoId = modelo.INVEST_Lancamento.Id,
            //    INVEST_ModeloDocId = modelo.INVEST_Lancamento.Id,
            //    TP = modelo.INVEST_Lancamento.TP,
            //    URLDOC = "",
            //    VALOR = modelo.INVEST_Lancamento.Valor,
            //    STATUS = modelo.INVEST_Lancamento.Status,
            //    UsuarioAppId = modelo.INVEST_Lancamento.UsuarioAppId,
            //    IP = _ips.FirstOrDefault()
            //});
            //await _context.SaveChangesAsync();


            // USU LOGADO
            var _usu = _context.Users
                .Where(x => x.UserName == User.Identity.Name)
                .FirstOrDefault();

            // LANCAMENTO EM QUESTÃO
            var _lanca = _context.INVEST_Lancamentos
                .Include(x => x.BlocoProjInvestimentos)
                .Where(x => x.Id == modelo.INVEST_LancamentoId)
                .FirstOrDefault();

            //--------------------------------
            // APLICACAO PADRAO
            //--------------------------------
            var _configAplicacoes =
                _context.AppConfiguracoes_Aplicativo
                .FirstOrDefault();

            // instanciar objeto email
            var _objemail = new ObjetoEmailEnvio()
            {
                ASSUNTO = "[INVESTIMENTO] House2Invest",
                COPIA = _configAplicacoes.mailToAdd,
                mailFrom = _configAplicacoes.mailFrom,
                MENSAGEM = string.Format($"Olá!!!{Environment.NewLine}<br/>A documentação referente a aprovação do investimento <b>" + _lanca.BlocoProjInvestimentos.Titulo + "</b> foi ENVIADA COM SUCESSO. Estamos analisando sua documentação."),
                PARA = _usu.Email,
                smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                smtpHost = _configAplicacoes.smtpHost,
                smtpPort = _configAplicacoes.smtpPort,
                smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
            };
            var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);


            return RedirectToPage("./Index");
        }
    }
}