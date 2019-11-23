using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models;
namespace House2Invest.Pages.Configuracoes
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
        public AppConfiguracoes AppConfiguracoes { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppConfiguracoes = await _context.AppConfiguracoes
                .Include(a => a.AppConfiguracoes_Aplicativo)
                .Include(a => a.AppConfiguracoes_Azure)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (AppConfiguracoes == null)
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

            AppConfiguracoes = await _context.AppConfiguracoes.FindAsync(id);

            if (AppConfiguracoes != null)
            {
                _context.AppConfiguracoes.Remove(AppConfiguracoes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}