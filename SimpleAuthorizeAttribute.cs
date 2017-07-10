using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace SimpleApi
{
    public class SimpleAuthorizeAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues header;
            if (context.HttpContext.Request.Headers.TryGetValue("Authentication", out header))
            {
                if (header == "BardzoTajnyToken!@#$122342TakTokenNiePowinienBycGenerowany")
                {
                    return;
                }
            }
            context.Result = new StatusCodeResult(401);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}