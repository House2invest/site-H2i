namespace House2Invest.Pages.Configuracoes
{
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize(Roles="SIS")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet()
        {
            base.get_ViewData().set_Item("AppConfiguracoes_AplicativoId", new SelectList(this._context.AppConfiguracoes_Aplicativo, "Id", "Empresa"));
            base.get_ViewData().set_Item("AppConfiguracoes_AzureId", new SelectList(this._context.AppConfiguracoes_Azure, "Id", "_azureblob_AccountName"));
            List<DropTema> list = new List<DropTema>();
            DropTema item = new DropTema();
            item.Chave = "_Layout";
            item.Descricao = "Padr\x00e3o";
            list.Add(item);
            DropTema tema2 = new DropTema();
            tema2.Chave = "_LayoutFundPress";
            tema2.Descricao = "Depois da Linha";
            list.Add(tema2);
            base.get_ViewData().set_Item("AppConfiguracoes_Tema", new SelectList((IEnumerable) list, "Chave", "Descricao"));
            return this.Page();
        }

       
    }
}

