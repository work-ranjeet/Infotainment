using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class PoliticalNewsController : Controller
    {
        //
        // GET: /PoliticalNews/

        public ActionResult NewsList()
        {
            return View();
        }

        //
        // GET: /PoliticalNews/Details/5

        public ActionResult NewsDetails(int id)
        {
            return View();
        }

       
    }
}
