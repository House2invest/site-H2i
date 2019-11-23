using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.BlocosProjInvest
{
    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly House2Invest.Data.ApplicationDbContext _context;
        public EditModel(IHttpContextAccessor accessor, House2Invest.Data.ApplicationDbContext context) { _context = context; _accessor = accessor; }
        [BindProperty]
        public BlocoProjInvestimentoViewModel BlocoProjInvestimento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context
                .BlocoProjInvestimentos
                .Include(x => x.GaleriaPerfilAlbum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            BlocoProjInvestimento = new BlocoProjInvestimentoViewModel()
            {
                Ativo = registro.Ativo,
                BlocoProjInvest_ExibTitulo = registro.BlocoProjInvest_ExibTitulo,
                Contador_DataFinal = registro.Contador_DataFinal,
                Contador_Exib = registro.Contador_Exib,
                Id = registro.Id,
                Titulo = registro.Titulo,
                DescricaoDetalhadaProjeto = registro.DescricaoDetalhadaProjeto,
                UrlImgPrinc = registro.UrlImgPrinc,
                Valor = registro.Valor,
                LanceMinimo = registro.LanceMinimo,
                ValorMinimoDocs = registro.ValorMinimoDocs,
                Status = registro.Status,
                Contato_CEP = registro.Contato_CEP,
                Contato_Logradouro = registro.Contato_Logradouro,
                Contato_LogradouroNum = registro.Contato_LogradouroNum,
                Contato_Bairro = registro.Contato_Bairro,
                Contato_Cidade = registro.Contato_Cidade,
                Contato_Complemento = registro.Contato_Complemento,
                Contato_Estado = registro.Contato_Estado,
                DTHR = registro.DTHR,
                GaleriaPerfilAlbumId = registro.GaleriaPerfilAlbumId,
                GaleriaPerfilAlbum = registro.GaleriaPerfilAlbum,
                LinkVideoProjeto = registro.LinkVideoProjeto,
                Rentabilidade_PRE_FIM = registro.Rentabilidade_PRE_FIM,
                Rentabilidade_PRE_INI = registro.Rentabilidade_PRE_INI,
                Rentabilidade_PRE_TIT = registro.Rentabilidade_PRE_TIT,
                Rentabilidade_ROI_FIM = registro.Rentabilidade_ROI_FIM,
                Rentabilidade_ROI_INI = registro.Rentabilidade_ROI_INI,
                Rentabilidade_ROI_TIT = registro.Rentabilidade_ROI_TIT,
                Rentabilidade_TIR_FIM = registro.Rentabilidade_TIR_FIM,
                Rentabilidade_TIR_INI = registro.Rentabilidade_TIR_INI,
                Rentabilidade_TIR_TIT = registro.Rentabilidade_TIR_TIT,
                SaldoReservado = registro.SaldoReservado,
                AndamentoObra = registro.AndamentoObra,
                AndamentoObraAcabamento = registro.AndamentoObraAcabamento
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var _errosValidacoes = false;
            if (!ModelState.IsValid)
                _errosValidacoes = true;

            var _config = _context.AppPerfil
                .Include(x => x.AppConfiguracoes)
                .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                .FirstOrDefault();

            var registro =
                _context
                .BlocoProjInvestimentos
                .Where(x => x.Id == BlocoProjInvestimento.Id)
                .FirstOrDefault();

            registro.BlocoProjInvest_ExibTitulo = BlocoProjInvestimento.BlocoProjInvest_ExibTitulo;
            registro.Contador_DataFinal = BlocoProjInvestimento.Contador_DataFinal;
            registro.Contador_Exib = BlocoProjInvestimento.Contador_Exib;

            registro.Titulo = BlocoProjInvestimento.Titulo;
            registro.Ativo = BlocoProjInvestimento.Ativo;
            registro.DescricaoDetalhadaProjeto = BlocoProjInvestimento.DescricaoDetalhadaProjeto;
            registro.Valor = BlocoProjInvestimento.Valor;
            registro.LanceMinimo = BlocoProjInvestimento.LanceMinimo;
            registro.ValorMinimoDocs = BlocoProjInvestimento.ValorMinimoDocs;
            //registro.Status = BlocoProjInvestimento.Status;
            registro.GaleriaPerfilAlbumId = BlocoProjInvestimento.GaleriaPerfilAlbumId;

            registro.Contato_CEP = BlocoProjInvestimento.Contato_CEP;
            registro.Contato_Logradouro = BlocoProjInvestimento.Contato_Logradouro;
            registro.Contato_LogradouroNum = BlocoProjInvestimento.Contato_LogradouroNum;
            registro.Contato_Bairro = BlocoProjInvestimento.Contato_Bairro;
            registro.Contato_Cidade = BlocoProjInvestimento.Contato_Cidade;
            registro.Contato_Complemento = BlocoProjInvestimento.Contato_Complemento;
            registro.Contato_Estado = BlocoProjInvestimento.Contato_Estado;

            registro.LinkVideoProjeto = BlocoProjInvestimento.LinkVideoProjeto;

            registro.Rentabilidade_TIR_TIT = BlocoProjInvestimento.Rentabilidade_TIR_TIT;
            registro.Rentabilidade_TIR_INI = BlocoProjInvestimento.Rentabilidade_TIR_INI;
            registro.Rentabilidade_TIR_FIM = BlocoProjInvestimento.Rentabilidade_TIR_FIM;

            registro.Rentabilidade_PRE_TIT = BlocoProjInvestimento.Rentabilidade_PRE_TIT;
            registro.Rentabilidade_PRE_INI = BlocoProjInvestimento.Rentabilidade_PRE_INI;
            registro.Rentabilidade_PRE_FIM = BlocoProjInvestimento.Rentabilidade_PRE_FIM;

            registro.Rentabilidade_ROI_TIT = BlocoProjInvestimento.Rentabilidade_ROI_TIT;
            registro.Rentabilidade_ROI_INI = BlocoProjInvestimento.Rentabilidade_ROI_INI;
            registro.Rentabilidade_ROI_FIM = BlocoProjInvestimento.Rentabilidade_ROI_FIM;

            registro.AndamentoObra = BlocoProjInvestimento.AndamentoObra;
            registro.AndamentoObraAcabamento = BlocoProjInvestimento.AndamentoObraAcabamento;

            if (BlocoProjInvestimento.ImagemDestaque != null)
            {
                var _imagemLogotipo =
                    await VerificadoresRetornos
                    .EnviarImagemAzure(BlocoProjInvestimento.ImagemDestaque, 550000, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                    registro.UrlImgPrinc = _imagemLogotipo;
                else
                {
                    ModelState.AddModelError(string.Empty, "A imagem é muito grande");
                    _errosValidacoes = true;
                }
            }

            if (Convert.ToDouble(BlocoProjInvestimento.LanceMinimo) > Convert.ToDouble(BlocoProjInvestimento.Valor))
            {
                ModelState.AddModelError(string.Empty, "O Lance mínimo deve ser INFERIOR ao VALOR TOTAL DO INVESTIMENTO");
                _errosValidacoes = true;
            }

            if (VerificadoresRetornos.ConverteStringParaDateTime(BlocoProjInvestimento.Contador_DataFinal) < DateTime.Now)
            {
                ModelState.AddModelError(string.Empty, "A data limite do contador deve ser SUPERIOR a data de hoje");
                _errosValidacoes = true;
            }

            if (Convert.ToDouble(BlocoProjInvestimento.Valor) <= 0)
            {
                ModelState.AddModelError(string.Empty, "Necessário: VALOR TOTAL DO INVESTIMENTO");
                _errosValidacoes = true;
            }

            if (Convert.ToDouble(BlocoProjInvestimento.LanceMinimo) <= 0)
            {
                ModelState.AddModelError(string.Empty, "Necessário: VALOR LANCE MÍNIMO");
                _errosValidacoes = true;
            }

            if (_errosValidacoes)
            {
                BlocoProjInvestimento.UrlImgPrinc = BlocoProjInvestimento.UrlImgPrinc;
                return Page();
            }

            _context.Attach(registro).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

                //if (BlocoProjInvestimento.Status == "C" || 
                //    BlocoProjInvestimento.Status == "E")
                //{
                //    var _todoslancamentos = new List<INVEST_Lancamento>();
                //    _todoslancamentos = _context.INVEST_Lancamentos
                //        .Where(x => x.BlocoProjInvestimentosId == BlocoProjInvestimento.Id)
                //        .ToList();

                //    foreach (var lanca in _todoslancamentos)
                //    {
                //        lanca.Status = "C";
                //        _context.Attach(lanca).State = EntityState.Modified;
                //        await _context.SaveChangesAsync();
                //    }

                //    var _todastransfs = new List<INVEST_ControleTransf>();
                //    _todastransfs = _context.INVEST_ControleTransfs
                //        .Where(x => x.BlocoProjInvestimentosId == BlocoProjInvestimento.Id)
                //        .ToList();

                //    foreach (var transf in _todastransfs)
                //    {
                //        transf.Status = "C";
                //        _context.Attach(transf).State = EntityState.Modified;
                //        await _context.SaveChangesAsync();
                //    }

                //    var _usu = _context.Users
                //        .Where(x => x.UserName == User.Identity.Name)
                //        .FirstOrDefault();

                //    var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                //    var _ips = new string[] { ip, "value2" };

                //    foreach (var item in _todoslancamentos)
                //    {
                //        // LOGCENTRAL
                //        _context.LOGCENTRALs.Add(new LOGCENTRAL()
                //        {
                //            ACAO = "CANCELOU INVESTIMENTO",
                //            INVEST_LancamentoId = item.Id,
                //            INVEST_ModeloDocId = item.Id,
                //            TP = item.TP,
                //            URLDOC = "",
                //            VALOR = item.Valor,
                //            STATUS = item.Status,
                //            UsuarioAppId = _usu.Id,
                //            IP = _ips.FirstOrDefault()
                //        });
                //        await _context.SaveChangesAsync();

                //        var _usuemail = _context.Users.FirstOrDefault(x => x.Id == item.UsuarioAppId).Email;
                //        var _titbloc = _context.BlocoProjInvestimentos.Where(x => x.Id == item.BlocoProjInvestimentosId).FirstOrDefault().Titulo;


                //        // instanciar objeto email
                //        var _configAplicacoes =
                //            _context.AppConfiguracoes_Aplicativo
                //            .FirstOrDefault();
                //        var _objemail = new ObjetoEmailEnvio()
                //        {
                //            ASSUNTO = "[INVESTIMENTO] House2Invest",
                //            COPIA = _configAplicacoes.mailToAdd,
                //            mailFrom = _configAplicacoes.mailFrom,
                //            MENSAGEM = string.Format($"Olá!!!{Environment.NewLine}<br/>O investimento <b>{_titbloc}</b> foi CANCELADO."),
                //            PARA = _usuemail,
                //            smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                //            smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                //            smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                //            smtpHost = _configAplicacoes.smtpHost,
                //            smtpPort = _configAplicacoes.smtpPort,
                //            smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                //        };
                //        var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);
                //    }
                //}
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlocoProjInvestimentoExists(BlocoProjInvestimento.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BlocoProjInvestimentoExists(int id)
        {
            return _context.BlocoProjInvestimentos.Any(e => e.Id == id);
        }
    }
}
