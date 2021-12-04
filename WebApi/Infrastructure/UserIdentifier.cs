using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using WebApi.Controllers;

namespace WebApi.Infrastructure
{
    public class UserIdentifier : Attribute, IActionFilter
    {
        public UserIdentifier() { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            int userId = int.Parse(context.RouteData.Values["id"].ToString());
            string userName = UserController.UserList.Find(user => user.Id == userId).Name;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            List<string> staff = new List<string> { "5" };
            if (staff.Contains(context.RouteData.Values["id"].ToString()))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Users", Action = "" }));
            }
        }
    }
}