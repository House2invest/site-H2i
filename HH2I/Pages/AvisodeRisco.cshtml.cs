using Microsoft.AspNetCore.Mvc.RazorPages;
namespace House2Invest.Pages
{
    public class AvisodeRiscoModel : PageModel
    {
        public string Mensagem { get; set; }
        public void OnGet()
        {
            Mensagem = "Aviso de Risco";
        }
    }
}