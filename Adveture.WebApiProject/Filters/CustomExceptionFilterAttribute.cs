using Microsoft.AspNetCore.Mvc.Filters;

namespace Adveture.WebApiProject.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }
    }
}
