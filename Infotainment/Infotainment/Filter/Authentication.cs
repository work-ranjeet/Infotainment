using Infotainment.Data;
using Infotainment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Infotainment.Filter
{
    public class Insert : ActionFilterAttribute
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
                if (!currentUser.GroupList.Any(v => v.GroupID == 1 || v.GroupID == 2 || v.GroupID == 4 || v.GroupID == 5))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Authentication",
                        
                    }));
                }

            }

            if (httpCookies == null || String.IsNullOrEmpty(httpCookies.Value))
            {
                FormsAuthentication.RedirectToLoginPage();                
            }
        }
    }

    public class Update : ActionFilterAttribute
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
                if (!currentUser.GroupList.Any(v => v.GroupID == 1 || v.GroupID == 2 || v.GroupID == 4 || v.GroupID == 6))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Authentication",

                    }));
                }

            }

            if (httpCookies == null || String.IsNullOrEmpty(httpCookies.Value))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }

    public class Approve : ActionFilterAttribute
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
                if (!currentUser.GroupList.Any(v => v.GroupID == 1 || v.GroupID == 2 || v.GroupID == 7 || v.GroupID == 9))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Authentication",

                    }));
                }

            }

            if (httpCookies == null || String.IsNullOrEmpty(httpCookies.Value))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }

    public class Active : ActionFilterAttribute
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
                if (!currentUser.GroupList.Any(v => v.GroupID == 1 || v.GroupID == 2 || v.GroupID == 8 || v.GroupID == 9))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Authentication",

                    }));
                }

            }

            if (httpCookies == null || String.IsNullOrEmpty(httpCookies.Value))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}