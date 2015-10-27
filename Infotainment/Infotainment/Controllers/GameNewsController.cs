using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class GameNewsController : Controller
    {
        //
        // GET: /GameNews/

        public ActionResult AllGameNews()
        {
            return View();
        }

        //
        // GET: /GameNews/Details/5

        public ActionResult GameNewsList(int id)
        {
            return View();
        }

        public ActionResult GameNewsDetails(int id)
        {
            return View();
        }

       
    }
}
