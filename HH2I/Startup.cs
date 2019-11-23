using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using House2Invest.Data;
using House2Invest.Hubs;
using House2Invest.Models;

namespace House2Invest
{

    public class Startup
    {
        public static int _LISTAPAGINADATOT = 10;
        public static string _CHAVECRYP = "C&F)H@McQfTjWnZr4u7x!A%D*G-KaNdR";
        public static string _VETORCRYP = "n2r5u8x/A?D(G+Kb";
        
    }
}

