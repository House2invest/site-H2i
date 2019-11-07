using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace House2Invest.Pages.Configuracoes
{
    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateModel(Data.ApplicationDbContext context) { _context = context; }

        public IActionResult OnGet()
        {
            ViewData["AppConfiguracoes_AplicativoId"] = new SelectList(_context.AppConfiguracoes_Aplicativo, "Id", "Empresa");
            ViewData["AppConfiguracoes_AzureId"] = new SelectList(_context.AppConfiguracoes_Azure, "Id", "_azureblob_AccountName");

            var _listaTemas = new List<DropTema>();
            _listaTemas.Add(new DropTema() { Chave = "_Layout", Descricao = "Padrão" });
            _listaTemas.Add(new DropTema() { Chave = "_LayoutFundPress", Descricao = "Depois da Linha" });
            //_listaTemas.Add(new DropTema() { Chave = "_Layout", Descricao = "Padrão" });
            //_listaTemas.Add(new DropTema() { Chave = "_LayoutCeline", Descricao = "Celine" });
            //_listaTemas.Add(new DropTema() { Chave = "_LayoutSirene", Descricao = "Sirene" });
            ViewData["AppConfiguracoes_Tema"] = new SelectList(_listaTemas, "Chave", "Descricao");

            return Page();

            //return RedirectToPage("./Index");
        }

        [BindProperty]
        public AppConfiguracoes AppConfiguracoes { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AppConfiguracoes.Add(AppConfiguracoes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}