using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class ContactUsController : Controller
    {
        public async Task<ActionResult> ContactUs()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }
    }
}
