namespace House2Invest.Pages.Configuracoes
{
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize(Roles="SIS")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        private bool AppConfiguracoesExists(int id)
        {
            ParameterExpression expression = Expression.Parameter((Type) typeof(House2Invest.Models.AppConfiguracoes), "e");
            ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
            return Queryable.Any<House2Invest.Models.AppConfiguracoes>(this._context.AppConfiguracoes, Expression.Lambda<Func<House2Invest.Models.AppConfiguracoes, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(House2Invest.Models.AppConfiguracoes.get_Id)), (Expression) Expression.Field((Expression) Expression.Constant(class_, (Type) typeof(<>c__DisplayClass8_0)), fieldof(<>c__DisplayClass8_0.id))), expressionArray1));
        }

        
    }
}

