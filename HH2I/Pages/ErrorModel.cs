﻿namespace House2Invest.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [ResponseCache(Duration=0, Location=2, NoStore=true)]
    public class ErrorModel : PageModel
    {

        public void OnGet()
        {
            string text1;
            Activity activity1 = Activity.get_Current();
            if (activity1 != null)
            {
                text1 = activity1.get_Id();
            }
            else
            {
                Activity local1 = activity1;
                text1 = null;
            }
            this.RequestId = text1 ?? base.get_HttpContext().get_TraceIdentifier();
        }

        public string RequestId
        {
            get
            {
                return this.<RequestId>k__BackingField;
            }
            set
            {
                this.<RequestId>k__BackingField = value;
            }
        }

        public bool ShowRequestId
        {
            get
            {
                return !string.IsNullOrEmpty(this.RequestId);
            }
        }
    }
}
