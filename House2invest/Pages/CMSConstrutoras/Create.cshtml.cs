using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.CMSConstrutoras
{
    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public ConstrutoraViewModel Construtora { get; set; }
        public IActionResult OnGet()
        {
            Construtora = new ConstrutoraViewModel()
            {
                Logotipo = "/images/sem-imagem.png"
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var _config = _context.AppPerfil
                .Include(x => x.AppConfiguracoes)
                .Include(x => x.AppConfiguracoes.AppConfiguracoes_Aplicativo)
                .Include(y => y.AppConfiguracoes.AppConfiguracoes_Azure)
                .FirstOrDefault();

            if (Construtora.Imagem != null)
            {
                var _imagemLogotipo =
                    await VerificadoresRetornos
                    .EnviarImagemAzure(Construtora.Imagem, 307200, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                    Construtora.Logotipo = _imagemLogotipo;
            }

            _context.Construtoras.Add(Construtora);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}