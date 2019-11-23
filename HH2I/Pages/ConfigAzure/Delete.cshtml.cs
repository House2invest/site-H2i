using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models;
using System.Threading.Tasks;
namespace House2Invest.Pages.ConfigAzure
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
        public AppConfiguracoes_Azure AppConfiguracoes_Azure { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppConfiguracoes_Azure = await _context.AppConfiguracoes_Azure.FirstOrDefaultAsync(m => m.Id == id);

            if (AppConfiguracoes_Azure == null)
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

            AppConfiguracoes_Azure = await _context.AppConfiguracoes_Azure.FindAsync(id);

            if (AppConfiguracoes_Azure != null)
            {
                _context.AppConfiguracoes_Azure.Remove(AppConfiguracoes_Azure);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}