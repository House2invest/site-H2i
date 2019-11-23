namespace House2Invest.Pages
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    [Authorize(Roles="SIS,ADM,USU")]
    public class cmsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public readonly string jobId = Guid.NewGuid().ToString("N");

        public cmsModel(IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._context = context;
        }

    }
}

