using House2Invest.Hubs;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
namespace House2Invest.Pages.CMSUsuarios
{
    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IHubContext<ChatHubCMS> _hubContextCMS;
        private readonly Data.ApplicationDbContext _context;
        public EditModel(IHttpContextAccessor accessor, Data.ApplicationDbContext context, IHubContext<ChatHub> hubContext, IHubContext<ChatHubCMS> hubContextCMS) { _context = context; _hubContext = hubContext; _hubContextCMS = hubContextCMS; _accessor = accessor; }
        [BindProperty]
        public CMSUsuariosViewModel modelo { get; set; }
        public async Task<IActionResult> OnGetAsync(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var registro = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            modelo = new CMSUsuariosViewModel()
            {
                Id = registro.Id,
                Criado = registro.Sistema_DataDeclaracaoCienciaTermos,
                Nome = registro.Nome,
                Email = registro.Email,
                EmailConfirmado = registro.EmailConfirmed,
                AcessoBloqueado = registro.Sistema_AcessoBloqueado,
                Lockout = registro.LockoutEnabled,
                Sistema_URLSelfieDocFRENTE = registro.Sistema_URLSelfieDocFRENTE,
                Sistema_URLSelfieDocVERSO = registro.Sistema_URLSelfieDocVERSO,
                Financeiro_Investidor_Perfil = registro.Financeiro_Investidor_Perfil
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var registro = _context.Users
                .Where(x => x.Id == modelo.Id)
                .FirstOrDefault();

            try
            {
                var _oldAcessoBloqueado = registro.Sistema_AcessoBloqueado;
                var _newAcessoBloqueado = modelo.AcessoBloqueado;

                registro.EmailConfirmed = modelo.EmailConfirmado;
                registro.Sistema_AcessoBloqueado = modelo.AcessoBloqueado;
                registro.LockoutEnabled = modelo.Lockout;
                if (modelo.Lockout)
                    registro.AccessFailedCount = 0;

                registro.Financeiro_Investidor_Perfil = modelo.Financeiro_Investidor_Perfil;
                _context.Attach(registro).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                if (registro.Sistema_AcessoBloqueado)
                {
                    await _hubContext.Clients.All.SendAsync("ForceLogOff", $"{modelo.Id}");
                    //await _hubContextCMS.Clients.All.SendAsync("ForceLogOffCMS", $"{modelo.Id}");
                }

                if (_oldAcessoBloqueado && !_newAcessoBloqueado)
                {
                    // instanciar objeto email
                    var _configAplicacoes =
                        _context.AppConfiguracoes_Aplicativo
                        .FirstOrDefault();
                    var _objemail = new ObjetoEmailEnvio()
                    {
                        ASSUNTO = "[Documentação APROVADA] House2Invest",
                        COPIA = _configAplicacoes.mailToAdd,
                        mailFrom = _configAplicacoes.mailFrom,
                        MENSAGEM = string.Format($"Olá <b>{registro.Nome}</b>, td. em paz?{Environment.NewLine}Obaaa... Sua documentação está ok conosco!!!{Environment.NewLine}Nossa equipe de suporte entrará em contato com você. Fique de olho na sua caixa de entrada. ;)"),
                        PARA = registro.Email,
                        smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                        smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                        smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                        smtpHost = _configAplicacoes.smtpHost,
                        smtpPort = _configAplicacoes.smtpPort,
                        smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                    };
                    var _enviou = await VerificadoresRetornos.EnviarEmail(_objemail);
                    //var _enviou =
                    //    await VerificadoresRetornos
                    //    .EnviarEmail(registro.Email,
                    //    "",
                    //    "[Documentação APROVADA] House2Invest", string.Format($"Olá <b>{registro.Nome}</b>, td. em paz?{Environment.NewLine}Obaaa... Sua documentação está ok conosco!!!{Environment.NewLine}Nossa equipe de suporte entrará em contato com você. Fique de olho na sua caixa de entrada. ;)"));

                    var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                    var _ips = new string[] { ip, "value2" };

                    //// LOGCENTRAL
                    //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                    //{
                    //    ACAO = "ENVIO EMAIL - DOCUMENTAÇÃO APROVADA",
                    //    INVEST_LancamentoId = 0,
                    //    INVEST_ModeloDocId = 0,
                    //    TP = "",
                    //    URLDOC = "",
                    //    VALOR = 0,
                    //    STATUS = "",
                    //    UsuarioAppId = registro.Id,
                    //    IP = _ips.FirstOrDefault()
                    //});
                    //await _context.SaveChangesAsync();

                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}