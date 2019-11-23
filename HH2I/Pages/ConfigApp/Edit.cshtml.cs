using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.ConfigApp
{
    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public EditModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public AppConfig_AppViewModel AppConfiguracoes_Aplicativo { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.AppConfiguracoes_Aplicativo.FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            AppConfiguracoes_Aplicativo = new AppConfig_AppViewModel()
            {
                Bairro = registro.Bairro,
                Celular = registro.Celular,
                CEP = registro.CEP,
                Cidade = registro.Cidade,
                Complemento = registro.Complemento,
                CPFCNPJ = registro.CPFCNPJ,
                EmailContato = registro.EmailContato,
                EmailSuporte = registro.EmailSuporte,
                EmailVendas = registro.EmailVendas,
                Empresa = registro.Empresa,
                Estado = registro.Estado,
                Fone = registro.Fone,
                FoneRecados = registro.FoneRecados,
                LogotipoEmpresa = registro.LogotipoEmpresa,
                Logradouro = registro.Logradouro,
                Id = registro.Id,

                mailFrom = registro.mailFrom,
                mailToAdd = registro.mailToAdd,
                smtpCredentialsEmail = registro.smtpCredentialsEmail,
                smtpCredentialsSenha = registro.smtpCredentialsSenha,
                smtpEnableSsl = registro.smtpEnableSsl,
                smtpHost = registro.smtpHost,
                smtpPort = registro.smtpPort,
                smtpUseDefaultCredentials = registro.smtpUseDefaultCredentials,

                dumpSQLHost = registro.dumpSQLHost,
                dumpSQLUser = registro.dumpSQLUser,
                dumpSQLPass = registro.dumpSQLPass,

                temporizaLmiteMaximoOfertaSuspensa = registro.temporizaLmiteMaximoOfertaSuspensa,
                temporizaLmiteMaximoRevogaInvestimento = registro.temporizaLmiteMaximoRevogaInvestimento,
                temporizaLmiteMaximoCancelaInvestimento = registro.temporizaLmiteMaximoCancelaInvestimento
            };

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

            var registro =
                _context
                .AppConfiguracoes_Aplicativo
                .Where(x => x.Id == AppConfiguracoes_Aplicativo.Id)
                .FirstOrDefault();

            registro.Bairro = AppConfiguracoes_Aplicativo.Bairro;
            registro.Celular = AppConfiguracoes_Aplicativo.Celular;
            registro.CEP = AppConfiguracoes_Aplicativo.CEP;
            registro.Cidade = AppConfiguracoes_Aplicativo.Cidade;
            registro.Complemento = AppConfiguracoes_Aplicativo.Complemento;
            registro.CPFCNPJ = AppConfiguracoes_Aplicativo.CPFCNPJ;
            registro.EmailContato = AppConfiguracoes_Aplicativo.EmailContato;
            registro.EmailSuporte = AppConfiguracoes_Aplicativo.EmailSuporte;
            registro.EmailVendas = AppConfiguracoes_Aplicativo.EmailVendas;
            registro.Empresa = AppConfiguracoes_Aplicativo.Empresa;
            registro.Estado = AppConfiguracoes_Aplicativo.Estado;
            registro.Fone = AppConfiguracoes_Aplicativo.Fone;
            registro.FoneRecados = AppConfiguracoes_Aplicativo.FoneRecados;
            registro.Logradouro = AppConfiguracoes_Aplicativo.Logradouro;
            registro.mailFrom = AppConfiguracoes_Aplicativo.mailFrom;
            registro.mailToAdd = AppConfiguracoes_Aplicativo.mailToAdd;
            registro.smtpCredentialsEmail = AppConfiguracoes_Aplicativo.smtpCredentialsEmail;
            registro.smtpCredentialsSenha = AppConfiguracoes_Aplicativo.smtpCredentialsSenha;
            registro.smtpEnableSsl = AppConfiguracoes_Aplicativo.smtpEnableSsl;
            registro.smtpHost = AppConfiguracoes_Aplicativo.smtpHost;
            registro.smtpPort = AppConfiguracoes_Aplicativo.smtpPort;
            registro.smtpUseDefaultCredentials = AppConfiguracoes_Aplicativo.smtpUseDefaultCredentials;
            registro.dumpSQLHost = AppConfiguracoes_Aplicativo.dumpSQLHost;
            registro.dumpSQLUser = AppConfiguracoes_Aplicativo.dumpSQLUser;
            registro.dumpSQLPass = AppConfiguracoes_Aplicativo.dumpSQLPass;
            registro.temporizaLmiteMaximoOfertaSuspensa = AppConfiguracoes_Aplicativo.temporizaLmiteMaximoOfertaSuspensa;
            registro.temporizaLmiteMaximoRevogaInvestimento = AppConfiguracoes_Aplicativo.temporizaLmiteMaximoRevogaInvestimento;
            registro.temporizaLmiteMaximoCancelaInvestimento = AppConfiguracoes_Aplicativo.temporizaLmiteMaximoCancelaInvestimento;

            if (AppConfiguracoes_Aplicativo.App_ImagemLogo != null)
            {
                var _imagemLogotipo =
                    await VerificadoresRetornos
                    .EnviarImagemAzure(AppConfiguracoes_Aplicativo.App_ImagemLogo, 307200, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                    registro.LogotipoEmpresa = _imagemLogotipo;

                //AppConfiguracoes_Aplicativo.LogotipoEmpresa = _imagemLogotipo;
            }

            _context.Attach(registro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppConfiguracoes_AplicativoExists(AppConfiguracoes_Aplicativo.Id))
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
        private bool AppConfiguracoes_AplicativoExists(int id)
        {
            return _context.AppConfiguracoes_Aplicativo.Any(e => e.Id == id);
        }
    }
}