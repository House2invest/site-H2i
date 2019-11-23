namespace House2Invest.Pages.blocoCRUDItemDoc
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet(int idbloco)
        {
            if (idbloco <= 0)
            {
                return this.NotFound();
            }
            this.modelo = new BlocoProjInvestimento_ItemDoc();
            this.modelo.BlocoProjInvestimentoId = idbloco;
            base.get_ViewData().set_Item("INVEST_ModeloDocId", new SelectList(this._context.INVEST_ModeloDocs, "Id", "Titulo"));
            return this.Page();
        }


    }
}

