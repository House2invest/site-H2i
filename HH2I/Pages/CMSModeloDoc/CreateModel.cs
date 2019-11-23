namespace House2Invest.Pages.CMSModeloDoc
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize(Roles="SIS")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModelcontext(ApplicationDbContext context)
        {
            this.ApplicationDbContext._context = context;
        }

        public IActionResult OnGet()
        {
            return this.Page();
        }

      
    }
}

