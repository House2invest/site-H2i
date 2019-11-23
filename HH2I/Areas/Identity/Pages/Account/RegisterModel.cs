namespace House2Invest.Areas.Identity.Pages.Account
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(IHttpContextAccessor accessor, UserManager<UsuarioApp> userManager, SignInManager<UsuarioApp> signInManager, ILogger<RegisterModel> logger, IEmailSender emailSender, ApplicationDbContext context)
        {
            this._accessor = accessor;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
            this._emailSender = emailSender;
            this._context = context;
        }

        public void OnGet(string returnUrl)
        {
            this.ReturnUrl = returnUrl;
        }
    }
}

