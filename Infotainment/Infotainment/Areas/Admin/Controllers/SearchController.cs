using Infotainment.Areas.Admin.Models;
using Infotainment.Data.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Infotainment.Filter;

namespace Infotainment.Areas.Admin.Controllers
{
    [Autherisation]
    public class SearchController : Controller
    {
        public async Task<ActionResult> MainNewsSearch()
        {
            return await Task.Run(() =>
            {
                var result = TopNewsBL.Instance.SelectAll(DateTime.Now.AddDays(-1), DateTime.Now, string.Empty);
                var viewModel = new TopNewsListFilter
                {
                    DateFrom = DateTime.Now.AddDays(-1),
                    DateTo = DateTime.Now,
                    IsActive = false,
                    IsApproved = false,
                    Header = string.Empty
                };

                viewModel.TopNewsList = new ConcurrentBag<ITopNews>();
                result.ToList().AsParallel().ForAll(news => viewModel.TopNewsList.Add(news));

                return View(viewModel);
            });
        }


        [HttpPost]
        public async Task<ActionResult> MainNewsSearch(TopNewsListFilter criteria)
        {
            return await Task.Run(() =>
            {
                var result = TopNewsBL.Instance.SelectAll(criteria.DateFrom, criteria.DateTo, criteria.Header);

                if (criteria.IsActive)
                {
                    result = result.ToList().FindAll(news => news.IsActive == 1);
                }

                if (criteria.IsApproved)
                {
                    result = result.ToList().FindAll(news => news.IsApproved == 1);
                }

                criteria.TopNewsList = new ConcurrentBag<ITopNews>();
                result.ToList().AsParallel().ForAll(news => criteria.TopNewsList.Add(news));

                return View(criteria);
            });
        }
    }
}