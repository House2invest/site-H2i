using House2Invest.Hubs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System;

namespace House2Invest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IHubContext<ChatHub> _hubContext;
        public IndexModel(IHubContext<ChatHub> hubContext, Data.ApplicationDbContext context) { _hubContext = hubContext; _context = context; }
        public void OnGet()
        {
            // await _hubContext.Clients.All.SendAsync("Notify", $"Página carregada");
            //if (User.Identity.IsAuthenticated)
            //{
            //    if (!User.IsInRole("SIS"))
            //    {
            //        await _hubContext.Clients.All.SendAsync("ReceiveMessage", User.Identity.IsAuthenticated ? User.Identity.Name : "", $"Olá. Essa é uma saudação quando um usuário abre a Página Inicial");
            //    }
            //}
        }
    }
}