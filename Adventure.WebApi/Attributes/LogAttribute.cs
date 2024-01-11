using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Adventure.WebApi.Attributes
{
    public class LogAttribute : ActionFilterAttribute
    {

        public LogAttribute()
        {
        }


        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            Console.WriteLine($"Action Method {actionContext.ActionDescriptor.DisplayName} executing");
        }


        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine($"Action Method {actionExecutedContext.ActionDescriptor.DisplayName} executed");
        }
    }

    public class ExAttribute : ExceptionFilterAttribute
    {

        public ExAttribute()
        {
        }

        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine(context.Exception);
            base.OnException(context);
        }
    }
}
