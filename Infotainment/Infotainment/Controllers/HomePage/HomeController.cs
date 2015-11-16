using Infotainment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Home()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }
    }
}
