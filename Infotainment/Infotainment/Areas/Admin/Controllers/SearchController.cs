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
                var viewModel = new MainNewsListFilter
                {
                    DateFrom = DateTime.Now.AddDays(-1),
                    DateTo = DateTime.Now,
                    IsActive = false,
                    IsApproved = false,
                    Header = string.Empty
                };

                viewModel.NewsList = new ConcurrentBag<ITopNews>();
                result.ToList().AsParallel().ForAll(news => viewModel.NewsList.Add(news));

                return View(viewModel);
            });
        }

        [HttpPost]
        public async Task<ActionResult> MainNewsSearch(MainNewsListFilter criteria)
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

                criteria.NewsList = new ConcurrentBag<ITopNews>();
                result.ToList().AsParallel().ForAll(news => criteria.NewsList.Add(news));

                return View(criteria);
            });
        }

        public async Task<ActionResult> InterNewsSearch()
        {
            return await Task.Run(() =>
            {
                var result = InterNewsBL.Instance.Search(DateTime.Now.AddDays(-1), DateTime.Now, string.Empty);
                var viewModel = new InterNewsListFilter
                {
                    DateFrom = DateTime.Now.AddDays(-1),
                    DateTo = DateTime.Now,
                    IsActive = false,
                    IsApproved = false,
                    Header = string.Empty
                };

                viewModel.NewsList = new ConcurrentBag<IInterNews>();
                result.ToList().AsParallel().ForAll(news => viewModel.NewsList.Add(news));

                return View(viewModel);
            });
        }

        [HttpPost]
        public async Task<ActionResult> InterNewsSearch(InterNewsListFilter criteria)
        {
            return await Task.Run(() =>
            {
                var result = InterNewsBL.Instance.Search(criteria.DateFrom, criteria.DateTo, criteria.Header);

                if (criteria.IsActive)
                {
                    result = result.ToList().FindAll(news => news.IsActive == 1);
                }

                if (criteria.IsApproved)
                {
                    result = result.ToList().FindAll(news => news.IsApproved == 1);
                }

                criteria.NewsList = new ConcurrentBag<IInterNews>();
                result.ToList().AsParallel().ForAll(news => criteria.NewsList.Add(news));

                return View(criteria);
            });
        }

        public async Task<ActionResult> StateNewsSearch()
        {
            return await Task.Run(() =>
            {
                var result = StateNewsBL.Instance.Search(DateTime.Now.AddDays(-1), DateTime.Now, string.Empty, null);
                var viewModel = new SearchNewsFilter
                {
                    DateFrom = DateTime.Now.AddDays(-1),
                    DateTo = DateTime.Now,
                    IsActive = false,
                    IsApproved = false,
                    Header = string.Empty,
                    StateCode = string.Empty
                };

                viewModel.NewsList = new ConcurrentBag<IStateNews>();
                result.ToList().AsParallel().ForAll(news => viewModel.NewsList.Add(news));

                return View(viewModel);
            });
        }

        [HttpPost]
        public async Task<ActionResult> StateNewsSearch(SearchNewsFilter criteria)
        {
            return await Task.Run(() =>
            {
                var result = StateNewsBL.Instance.Search(criteria.DateFrom, criteria.DateTo, criteria.Header, criteria.StateCode);

                if (criteria.IsActive)
                {
                    result = result.ToList().FindAll(news => news.IsActive == 1);
                }

                if (criteria.IsApproved)
                {
                    result = result.ToList().FindAll(news => news.IsApproved == 1);
                }

                criteria.NewsList = new ConcurrentBag<IStateNews>();
                result.ToList().AsParallel().ForAll(news => criteria.NewsList.Add(news));

                return View(criteria);
            });
        }
    }
}