using House2Invest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.Documentacao
{
    [Authorize]
    public class DocumentoPDFModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public DocumentoPDFModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public DocViewModel modelo { get; set; }
        public Construtora construtora { get; set; }
        public async Task<IActionResult> OnGetAsync(string tp = "", int idconstru = 0, string idusu = "")
        {
            if (string.IsNullOrEmpty(tp))
            {
                return NotFound();
            }
            if (idconstru <= 0 && string.IsNullOrEmpty(idusu))
            {
                return NotFound();
            }

            var _offline = true;
            var _usulogado = new UsuarioApp();
            modelo = new DocViewModel();
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                _usulogado = await _context.Users
                    .FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);

                if (_usulogado == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(idusu))
                {
                    if(_usulogado.Id != idusu)
                    {
                        return NotFound();
                    }
                }

                var _totinvestido = _context.INVEST_Lancamentos
                    .Where(x => x.UsuarioAppId == _usulogado.Id && x.TP == "E" && x.Status == "A")
                    .Sum(x => x.Valor);

                modelo.MONTANTE = Convert.ToDouble(_totinvestido).ToString("C2").Replace("R$", "");

                _offline = false;

                if (string.IsNullOrEmpty(idusu))
                    construtora = _context.Construtoras.FirstOrDefault(x => x.Id == idconstru);
            }
            else
            {
                modelo.MONTANTE = "R$ 0,00";
            }

            modelo.NOME = _offline == false ? $"{_usulogado.Nome} {_usulogado.Sobrenome}" : "";
            modelo.CPF = _offline == false ? $"{_usulogado.Documentacao_CPF}" : "";
            modelo.TIPO = tp;

            modelo.IDUSU = _usulogado.Id;
            modelo.EMAILUSU = _usulogado.Email;

            return Page();
        }
    }
}