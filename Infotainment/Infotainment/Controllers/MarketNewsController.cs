using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class MarketNewsController : Controller
    {
        //
        // GET: /MarketNews/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /MarketNews/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

      
    }
}
