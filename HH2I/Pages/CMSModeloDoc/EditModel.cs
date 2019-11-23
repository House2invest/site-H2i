namespace House2Invest.Pages.CMSModeloDoc
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        private bool AppPerfilExists(int id)
        {
            ParameterExpression expression = Expression.Parameter((Type) typeof(INVEST_ModeloDoc), "e");
            ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
            return Queryable.Any<INVEST_ModeloDoc>(this._context.INVEST_ModeloDocs, Expression.Lambda<Func<INVEST_ModeloDoc, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(INVEST_ModeloDoc.get_Id)), (Expression) Expression.Field((Expression) Expression.Constant(class_, (Type) typeof(<>c__DisplayClass8_0)), fieldof(<>c__DisplayClass8_0.id))), expressionArray1));
        }

       
    }
}

