namespace House2Invest.Pages
{
    using House2Invest.Data;
    using House2Invest.Models;
    using House2Invest.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    [Authorize(Roles="SIS,ADM,USU")]
    public class IndexCMSModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        public readonly string jobId = Guid.NewGuid().ToString("N");

        public IndexCMSModel(IHttpContextAccessor accessor, IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._context = context;
            this._accessor = accessor;
        }

        public IEnumerable<string> Get()
        {
            object obj1;
            HttpContext context1 = this._accessor.get_HttpContext();
            if (context1 == null)
            {
                HttpContext local1 = context1;
                obj1 = null;
            }
            else
            {
                ConnectionInfo info1 = context1.get_Connection();
                if (info1 == null)
                {
                    ConnectionInfo local2 = info1;
                    obj1 = null;
                }
                else
                {
                    IPAddress address1 = info1.get_RemoteIpAddress();
                    if (address1 != null)
                    {
                        obj1 = address1.ToString();
                    }
                    else
                    {
                        IPAddress local3 = address1;
                        obj1 = null;
                    }
                }
            }
            string str = obj1;
            return new string[] { ((string) str), "value2" };
        }

        
    }
}

