using House2Invest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace House2Invest.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly Data.ApplicationDbContext _context;
        public LogoutModel(IHttpContextAccessor accessor, SignInManager<UsuarioApp> signInManager, ILogger<LogoutModel> logger, Data.ApplicationDbContext context)
        {
            _context = context;
            _accessor = accessor;
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            try
            {
                var _usu = _context.Users
                .Where(x => x.UserName == User.Identity.Name)
                .FirstOrDefault();

                //--------------------------------
                // LOGCENTRAL
                //--------------------------------
                var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var _ips = new string[] { ip, "value2" };

                await VerificadoresRetornos.PROC__GravaLOG(new LOGCENTRAL()
                {
                    ICOMENS = "<i class='fas fa-sign-out-alt text-warning'></i>",
                    MENSAGEM = $"<img src='{_usu.AvatarUsuario}' style='border-radius:100%;max-width:100%;height:24px;margin-right:5px;'/> <b>{_usu.Nome} {_usu.Sobrenome}</b> usando o email <b>{_usu.Email}</b> fez <b style='color:darkblue;'>LOGOFF</b> na plataforma.",
                    ACAO = $"LOGOFF",
                    DTHR = DateTime.Now,
                    IP = _ips.FirstOrDefault(),
                    STATUS = "SUCESSO",
                    TIPO = "ACESSO A PLATAFORMA",
                    UsuarioAppId = _usu.Id,
                    VALOR = 0,
                    UsuarioAppCriadorId = "b1aadecb-4357-457d-bfea-27e153505497"
                }, _context);
            }
            catch (System.Exception) { }

            //_logger.LogInformation("User logged out.");
            //if (returnUrl != null)
            //{
            //    return LocalRedirect(returnUrl);
            //}
            //else
            //{
            //    return Page();
            //}
            return Redirect("/");
        }
    }
}