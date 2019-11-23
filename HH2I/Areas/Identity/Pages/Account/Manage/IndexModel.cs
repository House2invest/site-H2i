namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text.Encodings.Web;
    using System.Threading;
    using System.Threading.Tasks;

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly SignInManager<UsuarioApp> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(ApplicationDbContext context, UserManager<UsuarioApp> userManager, SignInManager<UsuarioApp> signInManager, IEmailSender emailSender)
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._emailSender = emailSender;
        }
    }
}

