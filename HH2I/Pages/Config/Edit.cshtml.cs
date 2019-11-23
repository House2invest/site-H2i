using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.Configuracoes
{
    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public EditModel(Data.ApplicationDbContext context) { _context = context; }

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

            ViewData["AppConfiguracoes_AplicativoId"] = new SelectList(_context.AppConfiguracoes_Aplicativo, "Id", "Empresa");
            ViewData["AppConfiguracoes_AzureId"] = new SelectList(_context.AppConfiguracoes_Azure, "Id", "_azureblob_AccountName");

            var _listaTemas = new List<DropTema>();
            _listaTemas.Add(new DropTema() { Chave = "_Layout", Descricao = "Padrão" });
            _listaTemas.Add(new DropTema() { Chave = "_LayoutFundPress", Descricao = "Depois da Linha" });
            //_listaTemas.Add(new DropTema() { Chave = "_LayoutSirene", Descricao = "Sirene" });
            ViewData["AppConfiguracoes_Tema"] = new SelectList(_listaTemas, "Chave", "Descricao");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //if (_context.AppConfiguracoes.Count() == 1 && !AppConfiguracoes.Padrao)
            //{
            //    ModelState.AddModelError("", "Como existe apenas um perfil registrado no sistema, você deve setá-lo como PADRÃO clicando na respectiva caixa de seleção.");
            //    return Page();
            //}

            //var _existepadrao =
            //    await _context.AppConfiguracoes
            //    .Where(x => x.Padrao && x.Id != AppConfiguracoes.Id)
            //    .ToListAsync();

            //if (_existepadrao.Count > 0 && AppConfiguracoes.Padrao)
            //{
            //    ModelState.AddModelError("", "Já existe um perfil setado como PADRÃO no sistema.");
            //    return Page();
            //}

            //if (_context.AppConfiguracoes.Count() > 1)
            //{
            //    var _atualiza = await _context.AppConfiguracoes.Where(x => x.Padrao && x.Id != AppConfiguracoes.Id).ToListAsync();
            //    if (_atualiza.Count > 0)
            //    {
            //        if (AppConfiguracoes.Padrao)
            //        {

            //        }
            //    }
            //}

            //    //var _maisdeumpadrao = _context.AppConfiguracoes.Where(x => x.Padrao && x.Id != AppConfiguracoes.Id).FirstOrDefault();
            //    //if (_maisdeumpadrao != null)
            //    //{
            //    //    AppConfiguracoes.Padrao = false;
            //    //}
            //}

            _context.Attach(AppConfiguracoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppConfiguracoesExists(AppConfiguracoes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return RedirectToPage("./Index");

            await OnGetAsync(id);

            return Page();
        }

        private bool AppConfiguracoesExists(int id)
        {
            return _context.AppConfiguracoes.Any(e => e.Id == id);
        }
    }
}