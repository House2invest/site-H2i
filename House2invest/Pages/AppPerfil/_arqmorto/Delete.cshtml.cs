using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Data;
using House2Invest.Models;

namespace House2Invest.Pages.AppPerfil
{
    public class DeleteModel : PageModel
    {
        private readonly House2Invest.Data.ApplicationDbContext _context;
        public DeleteModel(House2Invest.Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public Models.AppPerfil AppPerfil { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //AppPerfil = await _context.AppPerfil
            //    .Include(a => a.AppConfiguracoes).FirstOrDefaultAsync(m => m.Id == id);

            //if (AppPerfil == null)
            //{
            //    return NotFound();
            //}
            //return Page();
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //AppPerfil = await _context.AppPerfil.FindAsync(id);
            //if (AppPerfil != null)
            //{
            //    _context.AppPerfil.Remove(AppPerfil);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
