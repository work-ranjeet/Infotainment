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
                var topNewsBL = new TopNewsBL();
                var result = topNewsBL.SelectAll(DateTime.Now.AddDays(-1), DateTime.Now, 0, 0, string.Empty);
                return View(result);
            });
        }


        [HttpPost]
        public async Task<ActionResult> Index(NewsListFilter criteria)
        {
            return await Task.Run(() =>
            {
                var topNewsBL = new TopNewsBL();
                var result = topNewsBL.SelectAll(criteria.DateFrom, criteria.DateTo, criteria.IsActive, criteria.IsActive, criteria.Header);

                return View(result);
            });
        }
    }
}
