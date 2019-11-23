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
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet(int idbloco, int id)
        {
            <> c__DisplayClass6_0 class_;
            if (idbloco <= 0)
            {
                return this.NotFound();
            }
            this.modelo = new BlocoProjInvestimento_ItemDoc();
            ParameterExpression expression = Expression.Parameter((Type)typeof(BlocoProjInvestimento_ItemDoc), "x");
            ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
            BlocoProjInvestimento_ItemDoc doc = Queryable.FirstOrDefault<BlocoProjInvestimento_ItemDoc>(Queryable.Where<BlocoProjInvestimento_ItemDoc>(this._context.BlocoProjInvestimento_ItemDocs, Expression.Lambda<Func<BlocoProjInvestimento_ItemDoc, bool>>((Expression)Expression.Equal((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(BlocoProjInvestimento_ItemDoc.get_Id)), (Expression)Expression.Field((Expression)Expression.Constant(class_, (Type)typeof(<> c__DisplayClass6_0)), fieldof(<> c__DisplayClass6_0.id))), expressionArray1)));
            if (doc == null)
            {
                return this.NotFound();
            }
            this.modelo.Id = doc.Id;
            this.modelo.BlocoProjInvestimentoId = idbloco;
            this.modelo.INVEST_ModeloDocId = doc.INVEST_ModeloDocId;
            base.get_ViewData().set_Item("INVEST_ModeloDocId", new SelectList(this._context.INVEST_ModeloDocs, "Id", "Titulo"));
            return this.Page();
        }
    }
}

