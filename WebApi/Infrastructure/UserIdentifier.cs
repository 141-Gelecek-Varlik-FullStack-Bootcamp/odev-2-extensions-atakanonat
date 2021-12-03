using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Infrastructure
{
    public class UserIdentifier : Attribute, IActionFilter
    {
        public UserIdentifier() { }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            List<string> staff = new List<string> { "1", "2" };
            if (!staff.Contains(context.RouteData.Values["id"].ToString()))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Users", Action = "" }));
            }
        }
    }
}