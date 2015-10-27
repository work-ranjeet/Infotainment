using Infotainment.Data;
using Infotainment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Infotainment.Filter
{
    public class Autherisation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie httpCookies = null;
            IUsers currentUser = null;        

            if (filterContext.Controller != null 
                && filterContext.Controller.ControllerContext != null 
                && filterContext.Controller.ControllerContext.HttpContext != null 
                && filterContext.Controller.ControllerContext.HttpContext.Session != null)
            {
                currentUser = (IUsers)filterContext.Controller.ControllerContext.HttpContext.Session[Constants.UserSessionKey];
            }

            if (currentUser != null && filterContext.Controller.ControllerContext.HttpContext.Request.IsAuthenticated)
            {
                httpCookies = currentUser.Email != null ? FormsAuthentication.GetAuthCookie(currentUser.Email, true) : null;
                if (String.IsNullOrEmpty(httpCookies.Value))
                    httpCookies = currentUser.MobileNo != null ? FormsAuthentication.GetAuthCookie(currentUser.MobileNo, true) : null; 
            }

            if (httpCookies == null || String.IsNullOrEmpty(httpCookies.Value))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

    }
}