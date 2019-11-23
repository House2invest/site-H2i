namespace House2Invest.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Runtime.CompilerServices;

    public class AvisodeRiscoModel : PageModel
    {

        public void OnGet()
        {
            this.Mensagem = "Aviso de Risco";
        }

        public string Mensagem
        {
            get
            {
                return this.<Mensagem>k__BackingField;
            }
            set
            {
                this.<Mensagem>k__BackingField = value;
            }
        }
    }
}

