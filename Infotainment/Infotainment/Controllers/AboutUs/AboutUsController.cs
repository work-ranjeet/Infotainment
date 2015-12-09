using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public async Task<ActionResult> About()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }
    }
}