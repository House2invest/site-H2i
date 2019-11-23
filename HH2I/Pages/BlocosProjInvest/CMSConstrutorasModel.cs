﻿namespace House2Invest.Pages.BlocosProjInvest
{
    using House2Invest;
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    [Authorize(Roles = "SIS")]
    public class CMSConstrutorasModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CMSConstrutorasModel(ApplicationDbContext context)
        {
            this._context = context;
        }


    }
}

