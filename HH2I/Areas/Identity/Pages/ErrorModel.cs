namespace House2Invest.Areas.Identity.Pages
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [AllowAnonymous]
    public class ErrorModel : PageModel
    {

        public void OnGet()
        {
            string text1;
            Activity activity1 = Activity.Current;
            if (activity1 != null)
            {
                text1 = activity1.Id;
            }
            else
            {
                Activity local1 = activity1;
                text1 = null;
            }
            this.RequestId = text1 ?? base.HttpContext.TraceIdentifier;
        }

        public string RequestId
        {
            get => RequestId;
            set
            {
                RequestId  = value;
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

