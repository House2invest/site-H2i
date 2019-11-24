namespace House2Invest
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class AutoLogAttribute : TypeFilterAttribute
    {
        public AutoLogAttribute() : base(typeof(ResourceFilter))
        {
        }

        public class ActionFilter : IActionFilter, IFilterMetadata
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
            }
        }

        public class ExceptionFilter : IExceptionFilter, IFilterMetadata
        {
            public void OnException(ExceptionContext context)
            {
            }
        }

        public class ResourceFilter : IResourceFilter, IFilterMetadata
        {
            private readonly ApplicationDbContext _contexto;
            private readonly ApplicationDbContext _contexto1;

            public ResourceFilter(ApplicationDbContext contexto, ApplicationDbContext contexto1)
            {
                this._contexto = contexto;
                this._contexto1 = contexto1;
            }

            public void OnResourceExecuted(ResourceExecutedContext context)
            {
            }

            public void OnResourceExecuting(ResourceExecutingContext context)
            {
                throw new NotImplementedException();
            }

            public class ResultFilter : IResultFilter, IFilterMetadata
            {
                public void OnResultExecuted(ResultExecutedContext context)
                {
                }

                public void OnResultExecuting(ResultExecutingContext context)
                {
                }
            }
        }
    }
}

