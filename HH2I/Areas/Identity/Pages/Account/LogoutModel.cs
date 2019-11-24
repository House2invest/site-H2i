namespace House2Invest.Areas.Identity.Pages.Account
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class LogoutModelPage : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ApplicationDbContext _context;

        public LogoutModelPage(IHttpContextAccessor accessor, SignInManager<UsuarioApp> signInManager, ILogger<LogoutModel> logger, ApplicationDbContext context)
        {
            this._context = context;
            this._accessor = accessor;
            this._signInManager = signInManager;
            this._logger = logger;
        }

        public void OnGet()
        {
        }
    }
}

