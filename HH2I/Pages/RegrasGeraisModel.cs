namespace House2Invest.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Runtime.CompilerServices;

    public class RegrasGeraisModel : PageModel
    {

        public void OnGet()
        {
            this.Mensagem = "Regras Gerais";
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

