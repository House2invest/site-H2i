namespace House2Invest.Pages.BlocosProjInvest
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet()
        {
            BlocoProjInvestimentoViewModel model = new BlocoProjInvestimentoViewModel();
            model.UrlImgPrinc = "/images/fundo-padrao-investimento-001.jpg";
            model.Ativo = true;
            object[] objArray1 = new object[] { ((int)DateTime.get_Now().Day).ToString("D2"), ((int)DateTime.get_Now().AddMonths(6).Month).ToString("D2"), (int)DateTime.get_Now().Year, ((int)DateTime.get_Now().Hour).ToString("D2"), ((int)DateTime.get_Now().Minute).ToString("D2"), ((int)DateTime.get_Now().Second).ToString("D2") };
            model.Contador_DataFinal = string.Format("{0}/{1}/{2} {3}:{4}{5}", (object[])objArray1);
            model.Valor = "100.000,00";
            model.LanceMinimo = "1.000,00";
            model.ValorMinimoDocs = "10.000,00";
            model.SaldoReservado = 0.0;
            model.Status = "A";
            model.Contador_Exib = true;
            model.BlocoProjInvest_ExibTitulo = true;
            model.Rentabilidade_TIR_TIT = "Rentabilidade anual projetada<br> (TIR)*";
            model.Rentabilidade_TIR_INI = "15.3";
            model.Rentabilidade_TIR_FIM = "19.2";
            model.Rentabilidade_PRE_TIT = "Rentabilidade m\x00ednima<br> pr\x00e9-fixada";
            model.Rentabilidade_PRE_INI = "0";
            model.Rentabilidade_PRE_FIM = "120";
            model.Rentabilidade_ROI_TIT = "Rentabilidade projetada<br> (ROI)";
            model.Rentabilidade_ROI_INI = "53.2";
            model.Rentabilidade_ROI_FIM = "69.4";
            model.AndamentoObra = "0 %";
            model.AndamentoObraAcabamento = "0 %";
            this.BlocoProjInvestimento = model;
            return this.Page();
        }


    }
}


