namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class ExternalLoginsModel : PageModel
    {
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly SignInManager<UsuarioApp> _signInManager;

        public ExternalLoginsModel(UserManager<UsuarioApp> userManager, SignInManager<UsuarioApp> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

      
        }
    }

