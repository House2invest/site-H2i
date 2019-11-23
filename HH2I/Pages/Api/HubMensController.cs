using House2Invest.Models;

namespace House2Invest.Pages.Api
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.Primitives;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Route("api/[controller]/[action]"), ApiController]
    public class HubMensController : ControllerBase
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IHubContext<MensagensHub> _hubMensagens;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<UsuarioApp> _signInManager;

        public HubMensController(IHttpContextAccessor accessor, SignInManager<UsuarioApp> signInManager, ApplicationDbContext context, IHubContext<NotificacoesHub> hubNotificacoes, IHubContext<MensagensHub> hubMensagens)
        {
            this._accessor = accessor;
            this._signInManager = signInManager;
            this._context = context;
            this._hubMensagens = hubMensagens;
        }
    }
}

