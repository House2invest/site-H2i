using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models;
using System.Threading.Tasks;
namespace House2Invest.Pages.ConfigApp
{
    [Authorize(Roles = "SIS")]
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public IndexModel(Data.ApplicationDbContext context) { _context = context; }
        public ListaPaginada<AppConfiguracoes_Aplicativo> ListaAppConfiguracoes_App { get; set; }

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

            var registros = _context.AppConfiguracoes_Aplicativo.AsQueryable();

            if (!string.IsNullOrEmpty(StringBusca))
            {
                registros =
                    registros
                    .Where(s => s.Empresa.Contains(StringBusca) || s.CPFCNPJ.Contains(StringBusca));
            }

            switch (OrdenarPor)
            {
                case "name_desc":
                    registros = registros.OrderByDescending(s => s.Empresa);
                    break;
                case "Date":
                    registros = registros.OrderBy(s => s.DTHR);
                    break;
                case "date_desc":
                    registros = registros.OrderByDescending(s => s.DTHR);
                    break;
                default:
                    registros = registros.OrderBy(s => s.CPFCNPJ);
                    break;
            }

            ListaAppConfiguracoes_App = await ListaPaginada<AppConfiguracoes_Aplicativo>.CriarAsync(registros.AsNoTracking(), Pagina ?? 1, Startup._LISTAPAGINADATOT);
        }
    }
}