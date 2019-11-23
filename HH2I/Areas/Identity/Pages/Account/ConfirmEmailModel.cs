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
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly ApplicationDbContext _context;

        public ConfirmEmailModel(IHttpContextAccessor accessor, ApplicationDbContext context, UserManager<UsuarioApp> userManager)
        {
            this._accessor = accessor;
            this._context = context;
            this._userManager = userManager;
        }
    }
}


