using Mines_Web.Models;
using Mines_Web.Services.Business;
using System;
using System.Web.Mvc;

namespace Mines_Web.Controllers
{
    internal class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if((UserModel)filterContext.HttpContext.Session["user"] != null)
            {
                // do nothing
            }
            else
            {
                filterContext.Result = new RedirectResult("/SignIn");
            }
        }
    }
}