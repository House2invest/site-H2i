using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.CMSTaxasMercado
{
    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public TaxaGLOBAL taxaglobal { get; set; }
        public IActionResult OnGet()
        {
            taxaglobal = new TaxaGLOBAL();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaxasGLOBAIS.Add(taxaglobal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}