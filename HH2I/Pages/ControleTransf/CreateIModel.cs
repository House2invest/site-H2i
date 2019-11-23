namespace House2Invest.Pages.ControleTransf
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize]
    public class CreateIModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ApplicationDbContext _context;

        public CreateIModel(IHttpContextAccessor accessor, ApplicationDbContext context)
        {
            this._context = context;
            this._accessor = accessor;
        }

        public IActionResult OnGet(int? id)
        {
            if (!id.HasValue)
            {
                return this.NotFound();
            }
            ParameterExpression expression = Expression.Parameter((Type)typeof(Transferencia), "x");
            ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
            IIncludableQueryable<Transferencia, BlocoProjInvestimento> queryable1 = EntityFrameworkQueryableExtensions.Include<Transferencia, BlocoProjInvestimento>(this._context.Tranferencias, Expression.Lambda<Func<Transferencia, BlocoProjInvestimento>>((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(Transferencia.get_BlocoProjInvestimentos)), expressionArray1));
            expression = Expression.Parameter((Type)typeof(Transferencia), "x");
            ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
            Transferencia _modelo = Queryable.FirstOrDefault<Transferencia>(Queryable.Where<Transferencia>(queryable1, Expression.Lambda<Func<Transferencia, bool>>((Expression)Expression.Equal((Expression)Expression.Convert((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(Transferencia.get_Id)), typeof(int?)), (Expression)Expression.Field((Expression)Expression.Constant(class_, (Type)typeof(<> c__DisplayClass7_0)), fieldof(<> c__DisplayClass7_0.id))), expressionArray2)));
            expression = Expression.Parameter((Type)typeof(Construtora), "x");
            ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
            Construtora construtora = Queryable.FirstOrDefault<Construtora>(Queryable.Where<Construtora>(this._context.Construtoras, Expression.Lambda<Func<Construtora, bool>>((Expression)Expression.Equal((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(Construtora.get_Id)), (Expression)Expression.Property((Expression)Expression.Property((Expression)Expression.Field((Expression)Expression.Constant(class_, (Type)typeof(<> c__DisplayClass7_0)), fieldof(<> c__DisplayClass7_0._modelo)), (MethodInfo)methodof(Transferencia.get_BlocoProjInvestimentos)), (MethodInfo)methodof(BlocoProjInvestimento.get_ConstrutoraId))), expressionArray3)))
           
            if ((_modelo == null) || (construtora == null))
            {
                return this.NotFound();
            }

            TransferenciaViewModel model1 = new TransferenciaViewModel();
            model1.Id = _modelo.Id;
            model1.IDUSU = "I";
            model1.Montante = _modelo.Valor;
            this.modelo = model1;
            return this.Page();
        }


    }
}

