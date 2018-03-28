using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseProject.Infrastructure.Filter
{
    public interface IExceptionFilter : IFilterMetadata
    {
        void OnException(ExceptionContext context);
    }
}
