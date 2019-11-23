namespace House2Invest.Pages
{
    using House2Invest.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;

    [Authorize(Roles="SIS,ADM,USU")]
    public class IndexCMSMaterialModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHostingEnvironment _hostingEnvironment;

        public IndexCMSMaterialModel(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._context = context;
            this._accessor = accessor;
        }

        public IActionResult OnGet()
        {
            return this.Page();
        }
    }
}

