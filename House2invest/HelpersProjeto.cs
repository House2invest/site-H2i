using House2Invest.Data;
using House2Invest.Models;
using House2Invest.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ToolBox.Bridge;
using ToolBox.Platform;

namespace House2Invest
{
    [HtmlTargetElement(Attributes = "is-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ActiveRouteTagHelper(IHttpContextAccessor contextAccessor) { _contextAccessor = contextAccessor; }
        private IDictionary<string, string> _routeValues;
        /// <summary>The name of the action method.</summary>
        /// <remarks>Must be <c>null</c> if <see cref="P:Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Route" /> is non-<c>null</c>.</remarks>
        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }
        /// <summary>The name of the controller.</summary>
        /// <remarks>Must be <c>null</c> if <see cref="P:Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Route" /> is non-<c>null</c>.</remarks>
        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }
        [HtmlAttributeName("asp-page")]
        public string Page { get; set; }
        /// <summary>Additional parameters for the route.</summary>
        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string, string> RouteValues
        {
            get
            {
                if (this._routeValues == null)
                    this._routeValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                return this._routeValues;
            }
            set
            {
                this._routeValues = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.AspNetCore.Mvc.Rendering.ViewContext" /> for the current request.
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (ShouldBeActive())
            {
                MakeActive(output);
            }
            output.Attributes.RemoveAll("is-active-route");
        }

        private bool ShouldBeActive()
        {
            string currentController = string.Empty;
            string currentAction = string.Empty;
            if (ViewContext.RouteData.Values["Controller"] != null)
            {
                currentController = ViewContext.RouteData.Values["Controller"].ToString();
            }
            if (ViewContext.RouteData.Values["Action"] != null)
            {
                currentAction = ViewContext.RouteData.Values["Action"].ToString();
            }
            if (Controller != null)
            {
                if (!string.IsNullOrWhiteSpace(Controller) && Controller.ToLower() != currentController.ToLower())
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(Action) && Action.ToLower() != currentAction.ToLower())
                {
                    return false;
                }
            }
            if (Page != null)
            {
                if (!string.IsNullOrWhiteSpace(Page) && Page.ToLower() != _contextAccessor.HttpContext.Request.Path.Value.ToLower())
                {
                    return false;
                }
            }
            foreach (KeyValuePair<string, string> routeValue in RouteValues)
            {
                if (!ViewContext.RouteData.Values.ContainsKey(routeValue.Key) || ViewContext.RouteData.Values[routeValue.Key].ToString() != routeValue.Value)
                {
                    return false;
                }
            }
            return true;
        }
        private void MakeActive(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (classAttr == null)
            {
                classAttr = new TagHelperAttribute("class", "active");
                output.Attributes.Add(classAttr);
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active") < 0)
            {
                output.Attributes.SetAttribute("class", classAttr.Value == null ? "active" : classAttr.Value.ToString() + " active");
            }
        }
    }
    public class AutoLogAttribute : Microsoft.AspNetCore.Mvc.TypeFilterAttribute
    {
        public AutoLogAttribute() : base(typeof(ResourceFilter)) { }
        public class ResultFilter : IResultFilter
        {
            public void OnResultExecuting(ResultExecutingContext context)
            {
                //Console.WriteLine("Passando pelo result filter antes de retornar ao usuario.");
            }

            public void OnResultExecuted(ResultExecutedContext context)
            {
                //Console.WriteLine("Passando pelo result filter apos retornar ao usuario, ja nao podemos alterar a resposta.");
            }
        }

        public class ResourceFilter : IResourceFilter
        {
            private readonly ApplicationDbContext _contexto;
            private readonly ApplicationDbContext _contexto1;
            public ResourceFilter(ApplicationDbContext contexto, ApplicationDbContext contexto1) { _contexto = contexto; _contexto1 = contexto1; }
            public async void OnResourceExecuting(ResourceExecutingContext context)
            {
                try
                {
                    // FILTRO AS REQUISICOES
                    // /api/sistema/checkrotina
                    if (context.HttpContext.Request.Path != "/api/sistema/checkrotina")
                    {
                        _contexto.SEO_Visitas
                        .Add(new SEO_Visita()
                        {
                            URL = context.HttpContext.Request.Path,
                            DTHR = DateTime.Now,
                            IdUsu = context.HttpContext.User.Identity.IsAuthenticated ? context.HttpContext.User.Identity.Name : "visitante"
                        });

                        await _contexto.SaveChangesAsync();
                    }
                }
                catch (Exception) { }

                //Console.WriteLine("Passando pelo Resource Filter ANTES do metodo");
            }
            public void OnResourceExecuted(ResourceExecutedContext context)
            {
                //Console.WriteLine("Passando pelo Resource Filter DEPOIS do metodo");
            }
        }

        public class ActionFilter : IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                //Console.WriteLine("Passando pelo Action Filter ANTES do metodo");
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                //Console.WriteLine("Passando pelo Action Filter DEPOIS do metodo");
            }
        }
        public class ExceptionFilter : IExceptionFilter
        {
            public void OnException(ExceptionContext context)
            {
                //Console.WriteLine("Uma exceção não tratada ocorreu na action");
            }
        }
    }
}

namespace ToolBox.Platform
{
    public static class OS
    {
        public static bool IsWin() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool IsMac() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public static bool IsGnu() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static string GetCurrent()
        {
            return
            (IsWin() ? "win" : null) ??
            (IsMac() ? "mac" : null) ??
            (IsGnu() ? "gnu" : null);
        }
    }
}
namespace ToolBox.Bridge
{
    public class Response
    {
        public int code { get; set; }
        public string stdout { get; set; }
        public string stderr { get; set; }
    }
    public enum Output
    {
        Hidden,
        Internal,
        External
    }
    public static class Shell
    {
        //private static string GetFileName()
        //{
        //    try
        //    {
        //        switch (OS.GetCurrent())
        //        {
        //            case "win":
        //                break;
        //            case "mac":
        //            case "gnu":
        //                break;
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        Console.WriteLine(Ex.Message);
        //    }
        //}
        private static string CommandConstructor(string cmd, Output? output = Output.Hidden, string dir = "")
        {
            try
            {
                if (!String.IsNullOrEmpty(dir))
                {
                    //dir.Exists("");
                }
                switch (OS.GetCurrent())
                {
                    case "win":
                        if (!String.IsNullOrEmpty(dir))
                        {
                            dir = $" \"{dir}\"";
                        }
                        if (output == Output.External)
                        {
                            cmd = $"{Directory.GetCurrentDirectory()}/cmd.win.bat \"{cmd}\"{dir}";
                        }
                        cmd = $"/c \"{cmd}\"";
                        break;
                    case "mac":
                    case "gnu":
                        if (!String.IsNullOrEmpty(dir))
                        {
                            dir = $" '{dir}'";
                        }
                        if (output == Output.External)
                        {
                            cmd = $"sh {Directory.GetCurrentDirectory()}/cmd.mac.sh '{cmd}'{dir}";
                        }
                        cmd = $"-c \"{cmd}\"";
                        break;
                }

                return cmd;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }
        public static Response Term(string cmd, Output? output = Output.Hidden, string dir = "")
        {
            var result = new Response();
            var stderr = new StringBuilder();
            var stdout = new StringBuilder();
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd";
                startInfo.Arguments = CommandConstructor(cmd, output, dir);
                startInfo.RedirectStandardOutput = !(output == Output.External);
                startInfo.RedirectStandardError = !(output == Output.External);
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = !(output == Output.External);
                if (!String.IsNullOrEmpty(dir) && output != Output.External)
                {
                    startInfo.WorkingDirectory = dir;
                }

                using (Process process = Process.Start(startInfo))
                {
                    switch (output)
                    {
                        case Output.Internal:
                            //$"".fmNewLine();

                            while (!process.StandardOutput.EndOfStream)
                            {
                                string line = process.StandardOutput.ReadLine();
                                stdout.AppendLine(line);
                                Console.WriteLine(line);
                            }

                            while (!process.StandardError.EndOfStream)
                            {
                                string line = process.StandardError.ReadLine();
                                stderr.AppendLine(line);
                                Console.WriteLine(line);
                            }
                            break;
                        case Output.Hidden:
                            stdout.AppendLine(process.StandardOutput.ReadToEnd());
                            stderr.AppendLine(process.StandardError.ReadToEnd());
                            break;
                    }
                    process.WaitForExit();
                    result.stdout = stdout.ToString();
                    result.stderr = stderr.ToString();
                    result.code = process.ExitCode;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            return result;
        }
    }
}