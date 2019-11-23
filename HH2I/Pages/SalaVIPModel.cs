namespace House2Invest.Pages
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;

    [Authorize]
    public class SalaVIPModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

