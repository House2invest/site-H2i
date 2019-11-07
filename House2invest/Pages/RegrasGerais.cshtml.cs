using Microsoft.AspNetCore.Mvc.RazorPages;
namespace House2Invest.Pages
{
    public class RegrasGeraisModel : PageModel
    {
        public string Mensagem { get; set; }
        public void OnGet()
        {
            Mensagem = "Regras Gerais";
        }
    }
}