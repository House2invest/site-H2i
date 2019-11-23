namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class ResetAuthenticatorModel : PageModel
    {
        private UserManager<UsuarioApp> _userManager;
        private readonly SignInManager<UsuarioApp> _signInManager;
        private ILogger<ResetAuthenticatorModel> _logger;

        public ResetAuthenticatorModel(UserManager<UsuarioApp> userManager, SignInManager<UsuarioApp> signInManager, ILogger<ResetAuthenticatorModel> logger)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
        }
    }
}

