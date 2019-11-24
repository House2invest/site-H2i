using House2Invest.Data;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModelPage : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly IEmailSender _emailSender;
        public ForgotPasswordModelPage(UserManager<UsuarioApp> userManager, IEmailSender emailSender, ApplicationDbContext contexto)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _contexto = contexto;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { code },
                    protocol: Request.Scheme);

                // instanciar objeto email
                var _configAplicacoes =
                    _contexto.AppConfiguracoes_Aplicativo
                    .FirstOrDefault();

                var _objemail = new ObjetoEmailEnvio()
                {
                    ASSUNTO = "[ESQUECEU SUA SENHA] House2Invest",
                    COPIA = _configAplicacoes.mailToAdd,
                    mailFrom = _configAplicacoes.mailFrom,
                    MENSAGEM = string.Format($"Olá!!!{Environment.NewLine}<br/>Você solicitou um reset de senha.<br/>Clique <a href='" + callbackUrl + "'>AQUI</a> para alterar a sua senha."),
                    PARA = Input.Email,
                    smtpCredentialsEmail = _configAplicacoes.smtpCredentialsEmail,
                    smtpCredentialsSenha = _configAplicacoes.smtpCredentialsSenha,
                    smtpEnableSsl = _configAplicacoes.smtpEnableSsl,
                    smtpHost = _configAplicacoes.smtpHost,
                    smtpPort = _configAplicacoes.smtpPort,
                    smtpUseDefaultCredentials = _configAplicacoes.smtpUseDefaultCredentials
                };
                var _enviou =  VerificadoresRetornos.EnviarEmail(_objemail);

                //await _emailSender.SendEmailAsync(
                //    Input.Email,
                //    "Reset Password",
                //    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
