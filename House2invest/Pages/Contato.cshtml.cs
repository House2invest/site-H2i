using Microsoft.AspNetCore.Mvc.RazorPages;
namespace House2Invest.Pages
{
    public class ContatoModel : PageModel
    {
        public string Mensagem { get; set; }
        public void OnGet()
        {
            Mensagem = "Fale conosco";
        }
    }
}