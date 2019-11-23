namespace House2Invest.Pages
{
    using House2Invest.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Runtime.CompilerServices;

    public class LogOffForcadoModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LogOffForcadoModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult OnGet()
        {
            return this.Page();
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

