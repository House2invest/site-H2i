using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace House2Invest.Pages.ConfigApp
{
    [Authorize(Roles = "SIS")]
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public CreateModel(Data.ApplicationDbContext context) { _context = context; }
        [BindProperty]
        public AppConfig_AppViewModel AppConfiguracoes_Aplicativo { get; set; }
        public IActionResult OnGet()
        {
            AppConfiguracoes_Aplicativo = new AppConfig_AppViewModel()
            {
                LogotipoEmpresa = "/images/sem-imagem.png"
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

            if (AppConfiguracoes_Aplicativo.App_ImagemLogo != null)
            {
                var _imagemLogotipo =
                    await VerificadoresRetornos
                    .EnviarImagemAzure(AppConfiguracoes_Aplicativo.App_ImagemLogo, 307200, 0, 0, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountName, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_AccountKey, _config.AppConfiguracoes.AppConfiguracoes_Azure._azureblob_ContainerRaiz);

                if (_imagemLogotipo.ToLower().Trim().Contains("blob.core.windows.net"))
                    AppConfiguracoes_Aplicativo.LogotipoEmpresa = _imagemLogotipo;
            }

            _context.AppConfiguracoes_Aplicativo.Add(AppConfiguracoes_Aplicativo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}