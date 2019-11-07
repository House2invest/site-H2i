using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.blocoCRUDItemDoc
{
    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public EditModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public BlocoProjInvestimento_ItemDoc modelo { get; set; }
        public IActionResult OnGet(int idbloco = 0, int id = 0)
        {
            if (idbloco <= 0)
            {
                return NotFound();
            }

            modelo = new BlocoProjInvestimento_ItemDoc();

            var registro = _context.BlocoProjInvestimento_ItemDocs.Where(x => x.Id == id).FirstOrDefault();
            if (registro != null)
            {
                modelo.Id = registro.Id;
                modelo.BlocoProjInvestimentoId = idbloco;
                modelo.INVEST_ModeloDocId = registro.INVEST_ModeloDocId;
            }
            else
            {
                return NotFound();
            }

            ViewData["INVEST_ModeloDocId"] = new SelectList(_context.INVEST_ModeloDocs, "Id", "Titulo");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var _errosValidacoes = false;
            //if (Convert.ToDouble(BlocoProjInvestimento.LanceMinimo) > Convert.ToDouble(BlocoProjInvestimento.Valor))
            //{
            //    ModelState.AddModelError(string.Empty, "O Lance mínimo deve ser INFERIOR ao VALOR TOTAL DO INVESTIMENTO");
            //    _errosValidacoes = true;
            //}

            //if (VerificadoresRetornos.ConverteStringParaDateTime(BlocoProjInvestimento.Contador_DataFinal) < DateTime.Now)
            //{
            //    ModelState.AddModelError(string.Empty, "A data limite do contador deve ser SUPERIOR a data de hoje");
            //    _errosValidacoes = true;
            //}

            //if (Convert.ToDouble(BlocoProjInvestimento.Valor) <= 0)
            //{
            //    ModelState.AddModelError(string.Empty, "Necessário: VALOR TOTAL DO INVESTIMENTO");
            //    _errosValidacoes = true;
            //}

            //if (Convert.ToDouble(BlocoProjInvestimento.LanceMinimo) <= 0)
            //{
            //    ModelState.AddModelError(string.Empty, "Necessário: VALOR LANCE MÍNIMO");
            //    _errosValidacoes = true;
            //}

            if (_errosValidacoes)
            {
                return Page();
            }

            _context.BlocoProjInvestimento_ItemDocs.Add(modelo);
            await _context.SaveChangesAsync();

            return Redirect("/blocoCRUDItemDoc/Create?idbloco=" + modelo.BlocoProjInvestimentoId);
        }
    }
}