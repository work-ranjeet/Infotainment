using Infotainment.Areas.Admin.Models;
using Infotainment.Data.Controls;
using Infotainment.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Areas.Admin.Controllers
{
    //[Autherisation]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }
    }
}
