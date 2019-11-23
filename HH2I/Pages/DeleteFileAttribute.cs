namespace House2Invest.Pages
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.IO;

    public class DeleteFileAttribute : TypeFilterAttribute
    {
        public DeleteFileAttribute() : base(typeof(DeleteFileAttributeImpl))
        {
        }

        private class DeleteFileAttributeImpl : IActionFilter, IFilterMetadata
        {
            private readonly IHostingEnvironment _hostingEnvironment;

            public DeleteFileAttributeImpl(IHostingEnvironment hostingEnvironment)
            {
                this._hostingEnvironment = hostingEnvironment;
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                try
                {
                    string path = Path.Combine(this._hostingEnvironment.get_WebRootPath() + @"\Upload", context.get_HttpContext().get_Request().get_QueryString().get_Value()).Replace("?file=", "");
                    File.Delete(path);
                    File.Delete(path.Replace(".pdf", ".html"));
                }
                catch (Exception)
                {
                }
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
            }
        }
    }
}

