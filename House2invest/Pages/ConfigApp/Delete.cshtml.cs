using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models;
using System.Threading.Tasks;
namespace House2Invest.Pages.ConfigApp
{
    [Authorize(Roles = "SIS")]
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DeleteModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppConfiguracoes_Aplicativo AppConfiguracoes_Aplicativo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppConfiguracoes_Aplicativo = await _context.AppConfiguracoes_Aplicativo.FirstOrDefaultAsync(m => m.Id == id);

            if (AppConfiguracoes_Aplicativo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppConfiguracoes_Aplicativo = await _context.AppConfiguracoes_Aplicativo.FindAsync(id);

            if (AppConfiguracoes_Aplicativo != null)
            {
                _context.AppConfiguracoes_Aplicativo.Remove(AppConfiguracoes_Aplicativo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}