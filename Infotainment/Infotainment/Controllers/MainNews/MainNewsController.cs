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
    public class MainNewsController : Controller
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
                var newsInstance = TopNewsBL.Instance;
                INews news = null;
                try
                {
                    var result = newsInstance.Select(NewsId);
                    news = new News
                    {
                        NewsID = result.TopNewsID,
                        DisplayOrder = result.DisplayOrder,
                        Heading = result.Heading,
                        ImageUrl = result.ImageUrl,
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
