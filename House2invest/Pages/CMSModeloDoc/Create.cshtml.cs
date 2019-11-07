using House2Invest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
namespace House2Invest.Pages.CMSModeloDoc
{
    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateModel(Data.ApplicationDbContext context) { _context = context; }
        public IActionResult OnGet() { return Page(); }

        [BindProperty]
        public INVEST_ModeloDoc modelo { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.INVEST_ModeloDocs.Add(modelo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}