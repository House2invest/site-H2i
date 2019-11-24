using House2Invest.Data;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModelPage : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly IEmailSender _emailSender;
        public IndexModelPage(ApplicationDbContext context, UserManager<UsuarioApp> userManager, SignInManager<UsuarioApp> signInManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public MeuPerfilViewModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _context.Users
                .Where(x => x.UserName.ToLower().Trim() == User.Identity.Name.ToLower().Trim())
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound($"Não pude carregar dados do usuário ID '{_userManager.GetUserId(User)}'.");
            }

            Input = new MeuPerfilViewModel();

            Input.Id = user.Id;
            Input.Nome = user.Nome;
            Input.UserName = user.UserName;
            Input.Sobrenome = user.Sobrenome;
            Input.Email = user.Email;
            Input.Nascimento = user.Nascimento;
            Input.PhoneNumber = user.PhoneNumber;
            Input.EstadoCivil = user.EstadoCivil;
            Input.Documentacao_CPF = user.Documentacao_CPF;
            Input.Documentacao_RG = user.Documentacao_RG;

            Input.Trabalho_Profissao = user.Trabalho_Profissao;
            Input.Trabalho_Empresa = user.Trabalho_Empresa;
            Input.Trabalho_Cargo = user.Trabalho_Cargo;

            Input.Contato_Logradouro = user.Contato_Logradouro;
            Input.Contato_LogradouroNum = user.Contato_LogradouroNum;
            Input.Contato_Complemento = user.Contato_Complemento;
            Input.Contato_Bairro = user.Contato_Bairro;
            Input.Contato_Cidade = user.Contato_Cidade;
            Input.Contato_Estado = user.Contato_Estado;
            Input.Contato_CEP = user.Contato_CEP;
            Input.Contato_Pais = user.Contato_Pais;

            Input.PessoaPoliticamenteExposta = user.Sistema_DeclaracaoPessoaExposta;
            Input.Financeiro_Banco_Nome = user.Financeiro_Banco_Nome;
            Input.Financeiro_Banco_Ag = user.Financeiro_Banco_Ag;
            Input.Financeiro_Banco_CC = user.Financeiro_Banco_CC;

            Input.ContatoAutenticacao_Fone = user.ContatoAutenticacao_Fone;
            Input.ContatoAutenticacao_FoneAlternativo = user.ContatoAutenticacao_FoneAlternativo;
            Input.Contato_FoneCelular = user.Contato_FoneCelular;
            Input.Contato_FoneComercial = user.Contato_FoneComercial;

            Input.Sistema_URLSelfieDocFRENTE = !string.IsNullOrEmpty(user.Sistema_URLSelfieDocFRENTE) ? user.Sistema_URLSelfieDocFRENTE : "/images/220px-Modelo_da_nova_carteira_de_identidade_brasileira.png";
            Input.Sistema_URLSelfieDocVERSO = !string.IsNullOrEmpty(user.Sistema_URLSelfieDocVERSO) ? user.Sistema_URLSelfieDocVERSO : "/images/220px-Modelo_da_nova_carteira_de_identidade_brasileira.png";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //var user = await _userManager.GetUserAsync(User);
            var user = await _context.Users
                .Where(x => x.UserName.ToLower().Trim() == Input.UserName.ToLower().Trim())
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound($"Não pude carregar dados do usuário ID '{_userManager.GetUserId(User)}'.");
            }

            try
            {
                user.Nome = Input.Nome;
                user.Sobrenome = Input.Sobrenome;

                user.Contato_CEP = Input.Contato_CEP;
                user.Contato_Logradouro = Input.Contato_Logradouro;
                user.Contato_LogradouroNum = Input.Contato_LogradouroNum;
                user.Contato_Complemento = Input.Contato_Complemento;
                user.Contato_Bairro = Input.Contato_Bairro;
                user.Contato_Cidade = Input.Contato_Cidade;
                user.Contato_Estado = Input.Contato_Estado;

                user.Financeiro_Banco_Nome = Input.Financeiro_Banco_Nome;
                user.Financeiro_Banco_CC = Input.Financeiro_Banco_CC;
                user.Financeiro_Banco_Ag = Input.Financeiro_Banco_Ag;

                var _config = _context.AppPerfil
                    .Include(x => x.AppConfiguracoes)
                    .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                    .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                    .FirstOrDefault();

                var _errosValidacoes = false;
                if (Input.ImagemSelfieFRENTE != null)
                {
                    var _imagemLogotipo =
                         VerificadoresRetornos
                        .EnviarImagemAzure(Input.ImagemSelfieFRENTE, 
                        614200,
                        0,
                        0,
                        _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName,
                        _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey,
                        _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz,false,"");

                    if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                        user.Sistema_URLSelfieDocFRENTE = _imagemLogotipo;
                    else
                    {
                        ModelState.AddModelError(string.Empty, "A imagem é muito grande");
                        _errosValidacoes = true;
                    }
                }
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Selecione uma imagem do seu computador");
                //    _errosValidacoes = true;
                //}

                if (Input.ImagemSelfieVERSO != null)
                {
                    var _imagemLogotipo =
                         VerificadoresRetornos
                        .EnviarImagemAzure(Input.ImagemSelfieVERSO, 614200, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz,false,"");

                    if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                        user.Sistema_URLSelfieDocVERSO = _imagemLogotipo;
                    else
                    {
                        ModelState.AddModelError(string.Empty, "A imagem é muito grande");
                        _errosValidacoes = true;
                    }
                }
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Selecione uma imagem do seu computador");
                //    _errosValidacoes = true;
                //}

                if (_errosValidacoes)
                {
                    Input.Sistema_URLSelfieDocFRENTE = @"/images/220px-Modelo_da_nova_carteira_de_identidade_brasileira.png";
                    Input.Sistema_URLSelfieDocVERSO = @"/images/220px-Modelo_da_nova_carteira_de_identidade_brasileira.png";
                    return Page();
                }

                _context.Attach(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception) { }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.UserName != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Ocorreu um erro inesperado ao configurar o email para o usuário com o ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Ocorreu um erro inesperado ao definir o número de telefone do usuário com o ID '{userId}'.");
                }
            }

            //await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Seu perfil foi atualizado";

            return Redirect("/Identity/Account/Manage");
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não é possível carregar o usuário com o ID '{_userManager.GetUserId(User)}'.");
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page("/Account/ConfirmEmail", pageHandler: null, values: new { userId, code }, protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(email, "Confirme seu email", $"Por favor, confirme sua conta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui</a>.");
            StatusMessage = "E-mail de verificação enviado. Por favor verifique seu email.";

            return RedirectToPage();
        }
    }
}