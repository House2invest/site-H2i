using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.AppPerfil
{
    [Authorize(Roles = "SIS")]
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public IndexModel(Data.ApplicationDbContext context) { _context = context; }
        public ListaPaginada<Models.AppPerfil> ListaPerfis { get; set; }

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

            var registros = _context.AppPerfil
                    .Include(a => a.AppConfiguracoes)
                    .Include(a => a.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                    .Include(a => a.AppConfiguracoes.AppConfiguracoes_Azure)
                    .AsQueryable();

            if (!string.IsNullOrEmpty(StringBusca))
            {
                registros =
                    registros
                    .Where(s => s.AppConfiguracoes.Descricao.Contains(StringBusca));
            }

            switch (OrdenarPor)
            {
                case "name_desc":
                    registros = registros.OrderByDescending(s => s.AppConfiguracoes.Descricao);
                    break;
                default:
                    registros = registros.OrderBy(s => s.AppConfiguracoes.Descricao);
                    break;
            }

            ListaPerfis = await ListaPaginada<Models.AppPerfil>.CriarAsync(registros.AsNoTracking(), Pagina ?? 1, Startup._LISTAPAGINADATOT);
        }
    }
}