namespace House2Invest.Pages.Api
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using HtmlAgilityPack;
    using Ionic.Zip;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.Primitives;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using SelectPdf;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Z.EntityFramework.Plus;

    [Route("api/[controller]/[action]"), ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHubContext<NotificacoesHub> _hubNotificacoes;
        private readonly IHubContext<MensagensHub> _hubMensagens;
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _context1;
        private readonly SignInManager<UsuarioApp> _signInManager;

        public SistemaController(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment, SignInManager<UsuarioApp> signInManager, ApplicationDbContext context, ApplicationDbContext context1, IHubContext<NotificacoesHub> hubNotificacoes, IHubContext<MensagensHub> hubMensagens)
        {
            this._signInManager = signInManager;
            this._context = context;
            this._context1 = context1;
            this._hubNotificacoes = hubNotificacoes;
            this._hubMensagens = hubMensagens;
            this._hostingEnvironment = hostingEnvironment;
            this._accessor = accessor;
        }
    }
}

