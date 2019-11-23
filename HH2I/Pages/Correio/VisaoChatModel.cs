namespace House2Invest.Pages.Correio
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize]
    public class VisaoChatModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public VisaoChatModel(ApplicationDbContext context)
        {
            this._context = context;
        }

        
    }
}

