namespace House2Invest.Areas.Identity.Pages.Account
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<UsuarioApp> _userManager;

        public ResetPasswordModel(UserManager<UsuarioApp> userManager)
        {
            this._userManager = userManager;
        }

        public IActionResult OnGet(string code)
        {
            if (code == null)
            {
                return this.BadRequest("A code must be supplied for password reset.");
            }
            InputModel model1 = new InputModel();
            model1.Code = code;
            this.Input = model1;
            return this.Page();
        }
    }
}

