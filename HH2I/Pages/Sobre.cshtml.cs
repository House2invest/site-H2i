using Microsoft.AspNetCore.Mvc.RazorPages;
namespace House2Invest.Pages
{
    public class SobreModel : PageModel
    {
        public string Mensagem { get; set; }
        public void OnGet()
        {
            Mensagem = "Saiba mais";
        }
    }
}