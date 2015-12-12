using Infotainment.Data;
using Infotainment.Data.Controls;
using Infotainment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Controllers
{
    public class InternationalNewsController : Controller
    {
        public async Task<ActionResult> NewsList()
        {
            return await Task.Run(() =>
            {
                return View();
            });
        }

        public async Task<ActionResult> NewsDetail(string NewsId)
        {
            return await Task.Run(() =>
            {
                var newsInstance = InterNewsBL.Instance;
                INews news = null;
                try
                {
                    var result = newsInstance.Select(NewsId);
                    news = new News
                    {
                        NewsID = result.NewsID,
                        DisplayOrder = result.DisplayOrder,
                        Heading = result.Heading,
                        ImageUrl = result.ImageUrl,
                        ImageCaption = result.ImageCaption,
                        ShortDesc = result.ShortDescription,
                        NewsDesc = result.NewsDescription,
                        EditorID = string.Empty,
                        EditorName = "",
                        DttmCreated = result.DttmCreated
                    }; ;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    newsInstance.Dispose();
                }

                return View(news);
            });
        }
    }
}
