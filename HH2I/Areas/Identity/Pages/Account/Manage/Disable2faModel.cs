namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class Disable2faModel : PageModel
    {
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly ILogger<Disable2faModel> _logger;

        public Disable2faModel(UserManager<UsuarioApp> userManager, ILogger<Disable2faModel> logger)
        {
            this._userManager = userManager;
            this._logger = logger;
        }
    }
}

