using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.Configuracoes
{
    [Authorize(Roles = "SIS")]
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public IndexModel(Data.ApplicationDbContext context) { _context = context; }
        public ListaPaginada<AppConfiguracoes> ListaAppConfiguracoes { get; set; }

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

            var registros = _context.AppConfiguracoes
                    .Include(a => a.AppConfiguracoes_Aplicativo)
                    .Include(a => a.AppConfiguracoes_Azure)
                    .AsQueryable();

            if (!string.IsNullOrEmpty(StringBusca))
            {
                registros =
                    registros
                    .Where(s => s.AppConfiguracoes_Aplicativo.Empresa.Contains(StringBusca) || s.AppConfiguracoes_Aplicativo.CPFCNPJ.Contains(StringBusca));
            }

            switch (OrdenarPor)
            {
                case "name_desc":
                    registros = registros.OrderByDescending(s => s.AppConfiguracoes_Aplicativo.Empresa);
                    break;
                case "Date":
                    registros = registros.OrderBy(s => s.AppConfiguracoes_Aplicativo.DTHR);
                    break;
                case "date_desc":
                    registros = registros.OrderByDescending(s => s.AppConfiguracoes_Aplicativo.DTHR);
                    break;
                default:
                    registros = registros.OrderBy(s => s.AppConfiguracoes_Aplicativo.CPFCNPJ);
                    break;
            }

            ListaAppConfiguracoes = await ListaPaginada<AppConfiguracoes>.CriarAsync(registros.AsNoTracking(), Pagina ?? 1, Startup._LISTAPAGINADATOT);
        }
    }
}