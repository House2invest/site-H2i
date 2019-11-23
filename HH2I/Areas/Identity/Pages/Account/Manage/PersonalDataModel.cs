namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;

        public PersonalDataModel(UserManager<UsuarioApp> userManager, ILogger<PersonalDataModel> logger)
        {
            this._userManager = userManager;
            this._logger = logger;
        }
    }
}

