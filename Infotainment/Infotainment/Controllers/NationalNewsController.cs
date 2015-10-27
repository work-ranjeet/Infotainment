using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class NationalNewsController : Controller
    {
        //
        // GET: /NationalNews/

        public ActionResult NationalNewsList()
        {
            return View();
        }

        //
        // GET: /NationalNews/Details/5

        public ActionResult NationalNewsDetails(int id)
        {
            return View();
        }

       
    }
}
