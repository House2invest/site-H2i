namespace House2Invest.Areas.Identity.Pages.Account
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;

    [AllowAnonymous]
    public class LockoutModelPage : PageModel
    {
        public void OnGet()
        {
        }
    }
}

