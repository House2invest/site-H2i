using House2Invest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace House2Invest.Pages
{
    public class DocInvestVisuModel : PageModel
    {
        private readonly House2Invest.Data.ApplicationDbContext _context;
        public DocInvestVisuModel(House2Invest.Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public INVEST_ModeloDoc modelo { get; set; }

        public string Mensagem { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var registro = await _context.INVEST_ModeloDocs.FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            modelo = new INVEST_ModeloDoc()
            {
                Id = registro.Id,
                Titulo = registro.Titulo,
                Texto = registro.Texto
            };

            return Page();
        }
    }
}