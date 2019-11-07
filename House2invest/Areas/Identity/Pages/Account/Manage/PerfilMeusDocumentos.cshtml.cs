using House2Invest.Data;
using House2Invest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    public class PerfilMeusDocumentosModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public PerfilMeusDocumentosModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public List<INVEST_Lancamento> ListaInvestimentos { get; set; }
        public INVEST_Lancamento Investimento { get; set; }
        public void OnGet(int? idinvest)
        {
            ListaInvestimentos = new List<INVEST_Lancamento>();
            Investimento = new INVEST_Lancamento();

            try
            {
                var _usulogado = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

                ListaInvestimentos =
                    _context.INVEST_Lancamentos
                    .Include(x => x.BlocoProjInvestimentos)
                    .Include(x => x.BlocoProjInvestimentos.Construtora)
                    .Include(x => x.UsuarioApp)
                    .Where(x => x.UsuarioAppId == _usulogado.Id)
                    .ToList();

                if (idinvest > 0)
                {
                    Investimento = ListaInvestimentos.Where(x => x.Id == idinvest).FirstOrDefault();
                }
            }
            catch (Exception) { }
        }
    }
}