namespace House2Invest.Areas.Identity.Pages.Account
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class RegisterAgradecModel : PageModel
    {
        private readonly UserManager<UsuarioApp> _userManager;

        public RegisterAgradecModel(UserManager<UsuarioApp> userManager)
        {
            this._userManager = userManager;
        }
    }
}

