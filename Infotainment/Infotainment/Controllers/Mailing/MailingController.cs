using Infotainment.Models.Mailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers.Mailing
{
    public class MailingController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> SendMail()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        [HttpPost]
        public async Task<ActionResult> SendMail(Mail mail)
        {
            return await Task.Run(() =>
            {
                return View(mail);
            });
        }
    }
}