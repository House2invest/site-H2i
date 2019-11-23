namespace House2Invest.Areas.Identity.Pages.Account
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(SignInManager<UsuarioApp> signInManager, UserManager<UsuarioApp> userManager, ILogger<ExternalLoginModel> logger)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._logger = logger;
        }

        public IActionResult OnGetAsync()
        {
            return this.RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl)
        {
            string str = UrlHelperExtensions.Page(base.get_Url(), "./ExternalLogin", "Callback", new { returnUrl = returnUrl });
            return new ChallengeResult(provider, this._signInManager.ConfigureExternalAuthenticationProperties(provider, str, null));
        }
    }
}

