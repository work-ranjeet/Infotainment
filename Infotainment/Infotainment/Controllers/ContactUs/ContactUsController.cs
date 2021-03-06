﻿using Infotainment.Models.Mailing;
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

        [HttpPost]
        public async Task<ActionResult> ContactUs(Mail mail)
        {
            return await Task.Run(() =>
            {
                return View(mail);
            });
        }
    }
}
