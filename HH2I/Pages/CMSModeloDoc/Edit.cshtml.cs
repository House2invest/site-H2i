using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace House2Invest.Pages.CMSModeloDoc
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public EditModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public INVEST_ModeloDoc modelo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            modelo = await _context.INVEST_ModeloDocs.FirstOrDefaultAsync(m => m.Id == id);

            if (modelo == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppPerfilExists(modelo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppPerfilExists(int id)
        {
            return _context.INVEST_ModeloDocs.Any(e => e.Id == id);
        }
    }
}