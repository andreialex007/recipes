using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RecipesSystem.Models;

namespace RecipesSystem.Common
{
    public class WebAppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is WebApiException exception)
            {
                context.Result = new JsonResult(new ErrorResponse { errorMessage = exception.Message });
                context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
            else
            {
                base.OnException(context);
            }
        }
    }
}
