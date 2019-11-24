using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
namespace House2Invest.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly Data.ApplicationDbContext _context;
        public RegisterModel(IHttpContextAccessor accessor, UserManager<UsuarioApp> userManager, SignInManager<UsuarioApp> signInManager, ILogger<RegisterModel> logger, IEmailSender emailSender, Data.ApplicationDbContext context)
        {
            _accessor = accessor;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public UsuarioAppViewModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            //var _enviou =
            //    await VerificadoresRetornos
            //    .EnviarEmail("leandrodiascarvalho@hotmail.com", "javascript:alert('opa');", "[CONFIRME SEU EMAIL] House2Invest", string.Format($"Olá!!!{Environment.NewLine}Falta pouco. Por favor, confirme o seu email clicando <a href='{HtmlEncoder.Default.Encode("javascript:alert('opa');")}' style='color:#000 !important;'>AQUI</a> e prove que vc não é um robô."));
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var _erroValid = false;
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var _ips = new string[] { ip, "value2" };

            try
            {
                if (!Input.Termos)
                {
                    ModelState.AddModelError(string.Empty, "Leia e Aceite os Termos de Uso antes de prosseguir");
                    _erroValid = true;
                }
                if (string.IsNullOrEmpty(Input.Email))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o campo EMAIL");
                    _erroValid = true;
                }
                if (string.IsNullOrEmpty(Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o campo SENHA");
                    _erroValid = true;
                }
                if (string.IsNullOrEmpty(Input.ConfirmPassword))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o campo CONFIRME SUA SENHA");
                    _erroValid = true;
                }
                if (string.IsNullOrEmpty(Input.Nome))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o campo NOME");
                    _erroValid = true;
                }
                if (string.IsNullOrEmpty(Input.Sobrenome))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o campo SOBRENOME");
                    _erroValid = true;
                }
                if (Convert.ToDateTime(Input.Nascimento).Year == 0001)
                {
                    ModelState.AddModelError(string.Empty, "Preencha o campo DATA DE NASCIMENTO");
                    _erroValid = true;
                }
                //if (Input.ImagemDocDigitalizado == null)
                //{
                //    ModelState.AddModelError(string.Empty, "Necessário o envio de um documento com sua foto");
                //    _erroValid = true;
                //}
                if (Input.ImagemSelfie == null)
                {
                    ModelState.AddModelError(string.Empty, "Necessário o envio de uma foto sua");
                    _erroValid = true;
                }
                //if (Input.ImagemComprovanteResidencia == null)
                //{
                //    ModelState.AddModelError(string.Empty, "Necessário o envio de um comprovante de residência");
                //    _erroValid = true;
                //}
                if (Input.Password != Input.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "A nova senha e a sua confirmação não conferem. Digite novamente");
                    _erroValid = true;
                }

                if (_erroValid)
                    return Page();

                var _config = _context.AppPerfil
                    .Include(x => x.AppConfiguracoes)
                    .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                    .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                    .FirstOrDefault();

                //if (Input.ImagemDocDigitalizado != null)
                //{
                //    var _imagemLogotipo =
                //        await VerificadoresRetornos
                //        .EnviarImagemAzure(Input.ImagemDocDigitalizado, 502000, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                //    if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                //    {
                //        Input.Sistema_URLFotoDoc = _imagemLogotipo;
                //    }
                //}

                if (Input.ImagemSelfie != null)
                {
                    var _imagemLogotipo =
                         VerificadoresRetornos
                        .EnviarImagemAzure(Input.ImagemSelfie, 502000, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz,false,"");

                    if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                    {
                        Input.Sistema_URLSelfieDocVERSO = _imagemLogotipo;
                    }
                }

                //if (Input.ImagemComprovanteResidencia != null)
                //{
                //    var _imagemLogotipo =
                //        await VerificadoresRetornos
                //        .EnviarImagemAzure(Input.ImagemComprovanteResidencia, 502000, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                //    if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                //    {
                //        Input.Sistema_URLComprovanteResidencia = _imagemLogotipo;
                //    }
                //}

                var user = new UsuarioApp
                {
                    AppConfiguracoesId = _context.AppConfiguracoes.FirstOrDefault().Id,
                    Nome = Input.Nome,
                    Sobrenome = Input.Sobrenome,
                    Nascimento = Input.Nascimento,
                    UserName = Input.Email,
                    NormalizedUserName = Input.Email,
                    Email = Input.Email,
                    NormalizedEmail = Input.Email,
                    EmailConfirmed = false,
                    PasswordHash = Input.Password,
                    SecurityStamp = string.Empty,
                    AvatarUsuario = Input.Sistema_URLSelfieDocVERSO,
                    Sistema_FuncaoUsuario = "USUARIO",
                    Bio = "Olá mundo",
                    ContatoAutenticacao_Email = Input.Email,
                    ContatoAutenticacao_EmailAlternativo = Input.ContatoAutenticacao_EmailAlternativo,
                    ContatoAutenticacao_Fone = Input.Contato_FoneCelular,
                    ContatoAutenticacao_FoneAlternativo = Input.Contato_FoneComercial,
                    Contato_Bairro = Input.Contato_Bairro,
                    Contato_CEP = Input.Contato_CEP,
                    Contato_Cidade = Input.Contato_Cidade,
                    Contato_Complemento = Input.Contato_Complemento,
                    Contato_Escritorio = Input.Contato_Escritorio,
                    Contato_Estado = Input.Contato_Estado,
                    Contato_FoneCelular = Input.Contato_FoneCelular,
                    Contato_FoneComercial = Input.Contato_FoneComercial,
                    Contato_Logradouro = Input.Contato_Logradouro,
                    Contato_LogradouroNum = Input.Contato_LogradouroNum,
                    Contato_Pais = "BRASIL",
                    Contato_Website = Input.Contato_Website,
                    Genero = Input.Genero,
                    EstadoCivil = Input.EstadoCivil,
                    ImagemFundoPerfil = "/images/fundo_padrao_perfil.png",
                    Documentacao_CNPJ = Input.Documentacao_CNPJ,
                    Documentacao_CPF = Input.Documentacao_CPF,
                    Documentacao_RG = Input.Documentacao_RG,
                    Documentacao_TPPessoa = Input.Documentacao_TPPessoa,
                    Financeiro_Banco_Ag = string.IsNullOrEmpty(Input.Financeiro_Banco_Ag) ? "" : Input.Financeiro_Banco_Ag,
                    Financeiro_Banco_CC = string.IsNullOrEmpty(Input.Financeiro_Banco_CC) ? "" : Input.Financeiro_Banco_CC,
                    Financeiro_Banco_Nome = string.IsNullOrEmpty(Input.Financeiro_Banco_Nome) ? "" : Input.Financeiro_Banco_Nome,
                    Sistema_AcessoBloqueado = true,
                    Sistema_DataDeclaracaoCienciaTermos = DateTime.Now,
                    Sistema_DeclaracaoCienciaTermos = Input.Termos,
                    Sistema_URLComprovanteResidencia = Input.Sistema_URLComprovanteResidencia,
                    Sistema_URLSelfieDocFRENTE = "",
                    MidiasSociais_Facebook = "",
                    MidiasSociais_GooglePlus = "",
                    MidiasSociais_Instagram = "",
                    MidiasSociais_Linkedin = "",
                    MidiasSociais_Pinterest = "",
                    MidiasSociais_Twitter = "",
                    MidiasSociais_Youtube = "",
                    PhoneNumber = Input.Contato_FoneCelular,
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = false,
                    Trabalho_Empresa = "NÃO INFORMADO",
                    Trabalho_Cargo = "NÃO INFORMADO",
                    Trabalho_Profissao = "NÃO INFORMADO",
                    TwoFactorEnabled = false,
                    Sistema_URLFotoDoc = Input.Sistema_URLFotoDoc,
                    Sistema_URLSelfieDocVERSO = Input.Sistema_URLSelfieDocVERSO,
                    Financeiro_Investidor_Perfil = Input.Financeiro_Investidor_Perfil,
                    Sistema_DeclaracaoPessoaExposta = Input.Sistema_DeclaracaoPessoaExposta,
                    Sistema_NaoAparecerListaProjetos = Input.Sistema_NaoAparecerListaProjetos
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "USU");
                    _logger.LogInformation("Usuário criado.");

                    //------------------------------------
                    // LOGCENTRAL
                    //------------------------------------
                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-user-plus text-warning'></i>",
                        MENSAGEM = $"<img src='{user.AvatarUsuario}' style='border-radius:100%;max-width:100%;height:24px;margin-right:5px;'/> <b>{user.Nome} {user.Sobrenome}</b>,<br> com o email <b>{user.Email}</b><br> <b style='color:green;'>CRIOU UMA CONTA</b> na plataforma.",
                        ACAO = $"REGISTRO",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = "PENDENTE",
                        TIPO = "ACESSO A PLATAFORMA",
                        UsuarioAppId = user.Id,
                        VALOR = 0,
                        UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                    }, _context);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code },
                        protocol: Request.Scheme);

                    //var _conteudohtml = "<div style='font-size:20px;line-height:30px;'>";
                    var _conteudohtml = "<div style='line-height: 16px;'>";

                    _conteudohtml += $"Bem-vindo <b>{user.Nome} {user.Sobrenome}</b>,<br>";
                    _conteudohtml += $"Recebemos sua solicitação para cadastro na HOUSE2INVEST.<br>";
                    _conteudohtml += $"Para acessar a plataforma de investimentos da HOUSE2INVEST, você deve ativar o seu cadastro. Para isso, utilize o link abaixo e confirme os dados que você informou:<br>";
                    _conteudohtml += $"USUÁRIO: <b>{user.Email}</b> com o CPF: <b>{user.Documentacao_CPF}</b><br><br>";
                    _conteudohtml += $"Clique <a href='{callbackUrl}'>aqui</a> e ative a sua conta, ou copie e cole o link abaixo no seu navegador de preferência.<br><br><br>";
                    _conteudohtml += $"Atenciosamente,<br>";
                    _conteudohtml += $"Equipe House2Invest<br>";
                    _conteudohtml += $"<br><br>";

                    _conteudohtml += $"<div style='font-size:9px;font-style:italic;line-height:12px;'>";
                    _conteudohtml += $"Este é um e-mail automático gerado pelo sistema. Em caso de dúvidas, acesse nosso Atendimento Online. Para receber com sucesso nossos e-mails, é importante adicionar o e-mail contato@house2invest.com.br na sua lista de endereços confiáveis.<br>";
                    _conteudohtml += $"Nós valorizamos a sua privacidade. Estamos enviando esse email porque você entrou em contato com um de nossos usuários.<br>";
                    _conteudohtml += $"AVISO LEGAL: Algumas mensagens enviadas por nós podem conter conteúdos escritos e publicadas por usuários terceiros não ligados ao site, cuja responsabilidade pelas informações é exclusiva do autor - entre em contato conosco em caso de dúvidas. Ao ler este e-mail você declara que leu e aceita nossos <a href='https://depoisdalinha.blob.core.windows.net/house2invest/docs/novosdocs_usuarios/TERMO_DE_USO_H2I.pdf'>Termos de uso e privacidade</a>.<br>";
                    _conteudohtml += $"</div>";

                    _conteudohtml += $"</div>";

                    // instanciar objeto email
                    var _configAplicacoes =
                        _context.AppConfiguracoes_Aplicativo
                        .FirstOrDefault();
                    var _objemail = new ObjetoEmailEnvio()
                    {
                        ASSUNTO = "[CONFIRME SEU EMAIL] House2Invest",
                        COPIA = _configAplicacoes.mailToAdd,
                        mailFrom = _configAplicacoes.mailFrom,
                        MENSAGEM = _conteudohtml,
                        PARA = user.Email,
                        smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                        smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                        smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                        smtpHost = _configAplicacoes.smtpHost,
                        smtpPort = _configAplicacoes.smtpPort,
                        smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                    };
                    var _enviou =  VerificadoresRetornos.EnviarEmail(_objemail);

                    //----------------------------------------------------
                    // LOGCENTRAL
                    //----------------------------------------------------
                    await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                    {
                        ICOMENS = "<i class='fas fa-envelope text-primary'></i>",
                        MENSAGEM = "<i style='font-size:11px;font-family:monospace;line-height:10px;text-align:justify!important;'>" + _conteudohtml + "</i>" + $"<br> <div>    <a href='javascript:ReenviarEmailLog(0);' class='btn btn-sm bg-success' title='Reenviar email' style='padding:0.25rem 0.4rem;font-size:14px;'><i class='fas fa-paper-plane'></i></a></div>",
                        ACAO = $"ENVIOU EMAIL",
                        DTHR = DateTime.Now,
                        IP = _ips.FirstOrDefault(),
                        STATUS = "AGUARDANDO CONFIRMAÇÃO",
                        TIPO = "NOTIFICAÇÃO",
                        UsuarioAppId = user.Id,
                        VALOR = 0,
                        UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                    }, _context);

                    //var _enviou =
                    //    await VerificadoresRetornos
                    //    .EnviarEmail(user.Email, callbackUrl, "[CONFIRME SEU EMAIL] House2Invest", _conteudohtml);

                    //var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                    //var _ips = new string[] { ip, "value2" };
                    //// LOGCENTRAL
                    //_context.LOGCENTRALs.Add(new LOGCENTRAL()
                    //{
                    //    ACAO = "ENVIO EMAIL - CONFIRME SEU EMAIL",
                    //    INVEST_LancamentoId = 0,
                    //    INVEST_ModeloDocId = 0,
                    //    TP = "",
                    //    URLDOC = "",
                    //    VALOR = 0,
                    //    STATUS = "",
                    //    UsuarioAppId = user.Id,
                    //    IP = _ips.FirstOrDefault()
                    //});
                    //await _context.SaveChangesAsync();

                    if (_enviou == "ok")
                        return Redirect("/Identity/Account/RegisterAgradec?userId=" + user.Id + "&code=" + code);
                    else
                    {
                        ModelState.AddModelError(string.Empty, _enviou);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            catch (Exception erro)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }

            return Page();
        }
    }
}