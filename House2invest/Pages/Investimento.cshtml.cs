using House2Invest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace House2Invest.Pages
{
    public class InvestimentosModel : PageModel
    {
        private readonly House2Invest.Data.ApplicationDbContext _context;
        public InvestimentosModel(House2Invest.Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public BlocoProjInvestimento modelo { get; set; }

        public string Mensagem { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var registro = await _context.BlocoProjInvestimentos.FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            modelo = new BlocoProjInvestimento()
            {
                Id = registro.Id,
                Titulo = registro.Titulo,
                Valor = registro.Valor,
                UrlImgPrinc = registro.UrlImgPrinc,
                Contador_DataFinal = registro.Contador_DataFinal,
                LanceMinimo = registro.LanceMinimo,
                ValorMinimoDocs = registro.ValorMinimoDocs,
                Status = registro.Status

            };

            return Page();
        }
    }
}