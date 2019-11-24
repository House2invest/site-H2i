namespace House2Invest.Areas.Identity.Pages.Account
{
    using House2Invest;
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
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<UsuarioApp> userManager, IEmailSender emailSender, ApplicationDbContext contexto)
        {
            this._userManager = userManager;
            this._emailSender = emailSender;
            this._contexto = contexto;
        }
    }
}

