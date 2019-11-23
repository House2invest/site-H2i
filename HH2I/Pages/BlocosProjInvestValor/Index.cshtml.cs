using House2Invest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.BlocosProjInvestValor
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public IndexModel(Data.ApplicationDbContext context) { _context = context; }
        public ListaPaginada<INVEST_Lancamento> ListaLancamentos { get; set; }
        public async Task OnGetAsync(string OrdenarPor, string FiltroAtual, string StringBusca, int? Pagina)
        {
            ViewData["OrdenarPor"] = OrdenarPor;
            ViewData["OrdPorStringParam"] = string.IsNullOrEmpty(OrdenarPor) ? "name_desc" : "";
            ViewData["OrdPorDateParam"] = OrdenarPor == "Date" ? "date_desc" : "Date";
            if (StringBusca != null)
            {
                Pagina = 1;
            }
            else
            {
                StringBusca = FiltroAtual;
            }

            ViewData["FiltroAtual"] = StringBusca;

            var registros =
                _context
                .INVEST_Lancamentos
                .Include(x => x.BlocoProjInvestimentos)
                .Include(x => x.UsuarioApp)
                .AsQueryable();

            if (!User.IsInRole("SIS"))
            {
                var _usuariologado = _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                registros = registros.Where(x => x.UsuarioAppId == _usuariologado.Id);
            }

            if (!string.IsNullOrEmpty(StringBusca))
            {
                registros =
                    registros
                    .Where(s => s.BlocoProjInvestimentos.Titulo.Contains(StringBusca));
            }

            switch (OrdenarPor)
            {
                case "name_desc":
                    registros = registros.OrderByDescending(s => s.BlocoProjInvestimentos.Titulo);
                    break;
                case "Date":
                    registros = registros.OrderBy(s => s.DTHR);
                    break;
                case "date_desc":
                    registros = registros.OrderByDescending(s => s.DTHR);
                    break;
                default:
                    registros = registros.OrderBy(s => s.Valor);
                    break;
            }


            registros = registros
                .OrderByDescending(x => x.DTHR)
                .OrderBy(s => s.BlocoProjInvestimentosId)
                ;

            ListaLancamentos = await ListaPaginada<INVEST_Lancamento>.CriarAsync(registros.AsNoTracking(), Pagina ?? 1, Startup._LISTAPAGINADATOT);
        }
    }
}