using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class StateNewsController : Controller
    {
        //
        // GET: /StateNews/

        public ActionResult AllStateNews()
        {
            return View();
        }

        public ActionResult StateNewsList(int? StateId)
        {
            return View();
        }

        public ActionResult StateNews(int? NewsId)
        {
            return View();
        }


    }
}
