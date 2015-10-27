using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class MainNewsController : Controller
    {
        public ActionResult NewsList(int? NewsType)
        {
            return View();
        }

        public ActionResult NewsDetail(string NewsId)
        {
            return View();
        }

       
    }
}
