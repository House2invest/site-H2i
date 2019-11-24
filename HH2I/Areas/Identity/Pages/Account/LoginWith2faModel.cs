namespace House2Invest.Areas.Identity.Pages.Account
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class LoginWith2faModelc : PageModel
    {
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly ILogger<LoginWith2faModel> _logger;

        public LoginWith2faModelc(SignInManager<UsuarioApp> signInManager, ILogger<LoginWith2faModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
    }
}

