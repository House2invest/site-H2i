namespace House2Invest.Pages.BlocosProjInvestValor
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
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ApplicationDbContext _context;

        public CreateModel(IHttpContextAccessor accessor, ApplicationDbContext context)
        {
            this._context = context;
            this._accessor = accessor;
        }

        public IActionResult OnGet(int idlanc)
        {
            if (idlanc <= 0)
            {
                return this.NotFound();
            }
            INVEST_LancamentoImagemViewModel model1 = new INVEST_LancamentoImagemViewModel();
            model1.URLComprovTransf = "/temas/dpslintm1/assets/images/sem-imagem-modelo-projetos.png";
            model1.URLPerfilInvest = "/temas/dpslintm1/assets/images/sem-imagem-modelo-projetos.png";
            model1.INVEST_LancamentoId = idlanc;
            this.modelo = model1;
            return this.Page();
        }


    }
}

