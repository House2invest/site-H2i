namespace House2Invest.Pages
{
    using House2Invest.Data;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.SignalR;
    using System;

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ChatHub> _hubContext;

        public IndexModel(IHubContext<ChatHub> hubContext, ApplicationDbContext context)
        {
            this._hubContext = hubContext;
            this._context = context;
        }

        public void OnGet()
        {
        }
    }
}

