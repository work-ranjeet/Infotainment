using Infotainment.Data;
using Infotainment.Data.Controls;
using Infotainment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Infotainment.Data.Entities.Common;
using Infotainment.Data.Controls.Common;

namespace Infotainment.Controllers
{
    public class StateNewsApiController : ApiController
    {

        [HttpGet]
        public IEnumerable<IStateCode> States()
        {
            var newsInstance = StateCodeBL.Instance;
            List<IStateCode> stateCodeForTab = new List<IStateCode>();
            try
            {
                var result = newsInstance.SelectStates();
                if (result != null)
                {
                    stateCodeForTab.AddRange(result.ToList().FindAll(v => v.IsTabSate == 1).OrderBy(v => v.DisplayOrder).ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stateCodeForTab; //.OrderByDescending(v => v.DttmCreated);
        }

        [HttpGet]
        public Dictionary<string, List<INews>> TopStateNews()
        {
            var newsInstance = StateNewsBL.Instance;
            var newsDicList = new Dictionary<string, List<INews>>();  // ConcurrentBag<INews>();
            try
            {
                var result = newsInstance.SelectStateNewsForApi();
                if (result != null)
                {
                    foreach (var key in result.Keys)
                    {
                        newsDicList.Add(key, new List<INews>());
                        var newsList = result[key].OrderByDescending(v => v.DttmCreated).ToList();
                        newsList.ForEach(val =>
                        {
                            newsDicList[key].Add(new News
                            {
                                NewsID = val.NewsID,
                                DisplayOrder = val.DisplayOrder,
                                StateCode = val.StateCode,
                                StateName = val.StateName,
                                Heading = val.Heading,
                                ImageUrl = val.ImageUrl,
                                ShortDesc = val.ShortDescription,
                                IsRss = val.IsRss,
                                //NewsDesc= val.NewsDescription,
                                DttmCreated = val.DttmCreated
                            });
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                newsInstance.Dispose();
            }

            return newsDicList; //.OrderByDescending(v => v.DttmCreated);
        }


        [HttpGet]
        public INews NewsDetail(string NewsId)
        {
            var newsInstance = InterNewsBL.Instance;
            INews news = null;
            try
            {
                var result = newsInstance.Select(NewsId);

                if (result.IsActive == 1 && result.IsApproved == 1)
                {
                    news = new News
                    {
                        NewsID = result.NewsID,
                        DisplayOrder = result.DisplayOrder,
                        Heading = result.Heading,
                        ImageUrl = result.ImageUrl,
                        ImageCaption = result.ImageCaption,
                        ShortDesc = result.ShortDescription,
                        NewsDesc = result.NewsDescription,
                        DttmCreated = result.DttmCreated,
                        IsRss = result.IsRss
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                newsInstance.Dispose();
            }

            return news;
        }


        [HttpGet]
        public IEnumerable<INews> NewsList(string StateCode, Int64 NextPage)
        {
            var newsInstance = StateNewsBL.Instance;
            ConcurrentBag<INews> newsList = new ConcurrentBag<INews>();
            try
            {
                var result = newsInstance.SelectForPartialNewsList(StateCode, NextPage);
                result.AsParallel().AsOrdered().ForAll(val =>
                {
                    newsList.Add(new News
                    {
                        NewsID = val.NewsID,
                        DisplayOrder = val.DisplayOrder,
                        Heading = val.Heading,
                        ImageUrl = val.ImageUrl,
                        EditorID = string.Empty,
                        EditorName = "",
                        ShortDesc = val.ShortDescription,
                        NewsDesc = val.NewsDescription,
                        DttmCreated = val.DttmCreated,
                        IsRss = val.IsRss
                    });

                });

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                newsInstance.Dispose();
            }

            return newsList.OrderByDescending(v => v.DttmCreated);
        }

    }
}
