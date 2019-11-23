namespace House2Invest.Pages
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using HtmlAgilityPack;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.Configuration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using SelectPdf;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    [Authorize]
    public class OfertaModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        public OfertaModel(ApplicationDbContext context, IHostingEnvironment hostingEnvironment, IHttpContextAccessor accessor, IConfiguration configuration)
        {
            this._context = context;
            this._accessor = accessor;
            this._configuration = configuration;
            this._hostingEnvironment = hostingEnvironment;
        }

    }
}

