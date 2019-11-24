namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class PerfilMeusDocumentosModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private List<INVEST_Lancamento> ListaInvestimentos;

        public INVEST_Lancamento Investimento { get; private set; }

        public PerfilMeusDocumentosModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void OnGet(int? idinvest)
        {
            this.ListaInvestimentos = new List<INVEST_Lancamento>();
            this.Investimento = new INVEST_Lancamento();
            //try
            //{
            //    ParameterExpression expression = Expression.Parameter((Type) typeof(UsuarioApp), "x");
            //    ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
            //    UsuarioApp _usulogado = Queryable.FirstOrDefault<UsuarioApp>(this._context.Users, Expression.Lambda<Func<UsuarioApp, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(IdentityUser<string>.get_UserName, IdentityUser<string>)), (Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Constant(this, (Type) typeof(PerfilMeusDocumentosModel)), (MethodInfo) methodof(PageModel.get_User)), (MethodInfo) methodof(ClaimsPrincipal.get_Identity)), (MethodInfo) methodof(IIdentity.get_Name))), expressionArray1));
            //    expression = Expression.Parameter((Type) typeof(INVEST_Lancamento), "x");
            //    ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
            //    IIncludableQueryable<INVEST_Lancamento, BlocoProjInvestimento> queryable1 = EntityFrameworkQueryableExtensions.Include<INVEST_Lancamento, BlocoProjInvestimento>(this._context.INVEST_Lancamentos, Expression.Lambda<Func<INVEST_Lancamento, BlocoProjInvestimento>>((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(INVEST_Lancamento.get_BlocoProjInvestimentos)), expressionArray2));
            //    expression = Expression.Parameter((Type) typeof(INVEST_Lancamento), "x");
            //    ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
            //    IIncludableQueryable<INVEST_Lancamento, Construtora> queryable2 = EntityFrameworkQueryableExtensions.Include<INVEST_Lancamento, Construtora>(queryable1, Expression.Lambda<Func<INVEST_Lancamento, Construtora>>((Expression) Expression.Property((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(INVEST_Lancamento.get_BlocoProjInvestimentos)), (MethodInfo) methodof(BlocoProjInvestimento.get_Construtora)), expressionArray3));
            //    expression = Expression.Parameter((Type) typeof(INVEST_Lancamento), "x");
            //    ParameterExpression[] expressionArray4 = new ParameterExpression[] { expression };
            //    IIncludableQueryable<INVEST_Lancamento, UsuarioApp> queryable3 = EntityFrameworkQueryableExtensions.Include<INVEST_Lancamento, UsuarioApp>(queryable2, Expression.Lambda<Func<INVEST_Lancamento, UsuarioApp>>((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(INVEST_Lancamento.get_UsuarioApp)), expressionArray4));
            //    expression = Expression.Parameter((Type) typeof(INVEST_Lancamento), "x");
            //    ParameterExpression[] expressionArray5 = new ParameterExpression[] { expression };
            //    this.ListaInvestimentos = Enumerable.ToList<INVEST_Lancamento>((IEnumerable<INVEST_Lancamento>) Queryable.Where<INVEST_Lancamento>(queryable3, Expression.Lambda<Func<INVEST_Lancamento, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(INVEST_Lancamento.get_UsuarioAppId)), (Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant(class_2, (Type) typeof(<>c__DisplayClass10_1)), fieldof(<>c__DisplayClass10_1._usulogado)), (MethodInfo) methodof(IdentityUser<string>.get_Id, IdentityUser<string>))), expressionArray5)));
            //    int? nullable = idinvest;
            //    int num = 0;
            //    if ((nullable.GetValueOrDefault() > num) & nullable.HasValue)
            //    {
            //        this.Investimento = Enumerable.FirstOrDefault<INVEST_Lancamento>(Enumerable.Where<INVEST_Lancamento>((IEnumerable<INVEST_Lancamento>) this.ListaInvestimentos, delegate (INVEST_Lancamento x) {
            //            int? nullable = idinvest;
            //            return (x.Id == nullable.GetValueOrDefault()) & nullable.HasValue;
            //        }));
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }
    }
}

