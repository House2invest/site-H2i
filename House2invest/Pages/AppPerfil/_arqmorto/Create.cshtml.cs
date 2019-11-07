using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using House2Invest.Data;
using House2Invest.Models;
namespace House2Invest.Pages.AppPerfil
{
    public class CreateModel : PageModel
    {
        private readonly House2Invest.Data.ApplicationDbContext _context;
        public CreateModel(House2Invest.Data.ApplicationDbContext context) { _context = context; }
        public IActionResult OnGet()
        {
            //ViewData["AppConfiguracoesId"] = new SelectList(_context.AppConfiguracoes, "Id", "Descricao");
            //return Page();
            return RedirectToPage("./Index");
        }

        [BindProperty]
        public Models.AppPerfil AppPerfil { get; set; }

        public IActionResult OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //_context.AppPerfil.Add(AppPerfil);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}