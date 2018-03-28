using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseProject.Infrastructure.Filter
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context)
        {
            base.OnException(context);
        }

        public override Task OnExceptionAsync(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context)
        {
            return base.OnExceptionAsync(context);
        }
    }
}
