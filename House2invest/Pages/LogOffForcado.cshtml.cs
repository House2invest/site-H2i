using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace House2Invest.Pages
{
    public class LogOffForcadoModel : PageModel
    {
        private readonly House2Invest.Data.ApplicationDbContext _context;
        public LogOffForcadoModel(House2Invest.Data.ApplicationDbContext context) { _context = context; }
        public string Mensagem { get; set; }
        public IActionResult OnGet() { return Page(); }
    }
}