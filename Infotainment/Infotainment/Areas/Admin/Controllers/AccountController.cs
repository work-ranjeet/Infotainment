using System.Web.Mvc;
using System.Threading.Tasks;
using Infotainment.Data.Controls;
using Infotainment.Data.Entities;
using System.Web.Security;
using Infotainment.Data;
using Infotainment.Data.Crypto;
using Infotainment.Filter;
using Infotainment.Models;

namespace Infotainment.Areas.Admin.Controllers
{
    
    public class AccountController : Controller
    {
        public async Task<ActionResult> Login()
        {
            return await Task.Run(() =>
            {               
                return View();
            });
        }

        [HttpPost]
        public async Task<ActionResult> Login(Crendential User)
        {
            if (ModelState.IsValid)
            {
                var  userBL = new UserBL();
                var  userDetail = await userBL.SelectUser(User.UserID);
                if (await userBL.IsValidUser(userDetail, User.UserID, User.Password))
                {
                    this.Session[Constants.UserSessionKey] = userDetail;
                    FormsAuthentication.SetAuthCookie(User.UserID, User.RememberMe);                    
                    ModelState.Clear();
                    User.UserID = User.Password = string.Empty;

                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Incorrect Credentials.");
                }

            }
            return View(User);
        }

        public async Task<ActionResult> Logout() 
        {
            FormsAuthentication.SignOut();
            this.Session[Constants.UserSessionKey] = null;
            return await Task.Run(() =>
            {
                return RedirectToAction("Home", "Home", new { area = "" });
            });
        }
    }
}