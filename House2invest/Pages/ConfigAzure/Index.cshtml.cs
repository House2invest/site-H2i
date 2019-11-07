using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using House2Invest.Models;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.ConfigAzure
{
    [Authorize(Roles = "SIS")]
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public IndexModel(Data.ApplicationDbContext context) { _context = context; }
        public ListaPaginada<AppConfiguracoes_Azure> ListaAppConfiguracoes_Azure { get; set; }

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

            var registros = _context.AppConfiguracoes_Azure.AsQueryable();

            if (!string.IsNullOrEmpty(StringBusca))
            {
                registros =
                    registros
                    .Where(s => s._azureblob_AccountName.Contains(StringBusca) || s._azureblob_ContainerRaiz.Contains(StringBusca));
            }

            switch (OrdenarPor)
            {
                case "name_desc":
                    registros = registros.OrderByDescending(s => s._azureblob_AccountName);
                    break;
                case "Date":
                    registros = registros.OrderBy(s => s.DTHR);
                    break;
                case "date_desc":
                    registros = registros.OrderByDescending(s => s.DTHR);
                    break;
                default:
                    registros = registros.OrderBy(s => s._azureblob_ContainerRaiz);
                    break;
            }

            ListaAppConfiguracoes_Azure = await ListaPaginada<AppConfiguracoes_Azure>.CriarAsync(registros.AsNoTracking(), Pagina ?? 1, Startup._LISTAPAGINADATOT);
        }
    }
}