namespace House2Invest.Areas.Identity.Pages.Account
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class RegisterAgradecModelPage : PageModel
    {
        private readonly UserManager<UsuarioApp> _userManager;

        public RegisterAgradecModelPage(UserManager<UsuarioApp> userManager)
        {
            this._userManager = userManager;
        }
    }
}

