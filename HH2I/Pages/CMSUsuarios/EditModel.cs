namespace House2Invest.Pages.CMSUsuarios
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize(Roles="SIS")]
    public class EditModel : PageModel
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IHubContext<ChatHubCMS> _hubContextCMS;
        private readonly ApplicationDbContext _context;

        public EditModel(IHttpContextAccessor accessor, ApplicationDbContext context, IHubContext<ChatHub> hubContext, IHubContext<ChatHubCMS> hubContextCMS)
        {
            this._context = context;
            this._hubContext = hubContext;
            this._hubContextCMS = hubContextCMS;
            this._accessor = accessor;
        }
    }
}

