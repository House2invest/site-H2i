using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using House2Invest.Models;
using System.Threading.Tasks;
namespace House2Invest.Pages.ConfigAzure
{
    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public CreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AppConfiguracoes_Azure AppConfiguracoes_Azure { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AppConfiguracoes_Azure.Add(AppConfiguracoes_Azure);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}