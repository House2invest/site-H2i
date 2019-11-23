namespace House2Invest.Pages.AppPerfil
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Runtime.CompilerServices;

    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult OnGetAsync(int? id)
        {
            return this.RedirectToPage("./Index");
        }

        public IActionResult OnPostAsync(int? id)
        {
            return this.RedirectToPage("./Index");
        }
    }
}

