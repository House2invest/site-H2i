using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.AppPerfil
{
    [Authorize(Roles = "SIS")]
    public class CMSTaxasMercadoModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CMSTaxasMercadoModel(Data.ApplicationDbContext context) { _context = context; }
        public ListaPaginada<Models.TaxaGLOBAL> ListaTaxasMercado { get; set; }

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

            var registros = _context.TaxasGLOBAIS.AsQueryable();

            ListaTaxasMercado = await ListaPaginada<Models.TaxaGLOBAL>.CriarAsync(registros.AsNoTracking(), Pagina ?? 1, Startup._LISTAPAGINADATOT);
        }
    }
}