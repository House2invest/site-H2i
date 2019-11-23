namespace House2Invest.Pages.BlocosProjInvest
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
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize(Roles = "SIS")]
    public class EditModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ApplicationDbContext _context;

        public EditModel(IHttpContextAccessor accessor, ApplicationDbContext context)
        {
            this._context = context;
            this._accessor = accessor;
        }

        private bool BlocoProjInvestimentoExists(int id)
        {
            <> c__DisplayClass9_0 class_;
            ParameterExpression expression = Expression.Parameter((Type)typeof(House2Invest.Models.BlocoProjInvestimento), "e");
            ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
            return Queryable.Any<House2Invest.Models.BlocoProjInvestimento>(this._context.BlocoProjInvestimentos, Expression.Lambda<Func<House2Invest.Models.BlocoProjInvestimento, bool>>((Expression)Expression.Equal((Expression)Expression.Property((Expression)expression, (MethodInfo)methodof(House2Invest.Models.BlocoProjInvestimento.get_Id)), (Expression)Expression.Field((Expression)Expression.Constant(class_, (Type)typeof(<> c__DisplayClass9_0)), fieldof(<> c__DisplayClass9_0.id))), expressionArray1));
        }


    }
}


