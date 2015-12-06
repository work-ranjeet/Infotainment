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
using System.Xml.Linq;
using Infotainment.Data.Common.Services;

namespace Infotainment.Controllers
{
    public class MainNewsApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<INews> TopNews()
        {
            var newsInstance = TopNewsBL.Instance;
            ConcurrentBag<INews> newsList = new ConcurrentBag<INews>();
            try
            {
                var result = newsInstance.SelectFirst10TopNews();
                result.AsParallel().ForAll(val =>
                {
                    newsList.Add(new News
                    {
                        NewsID = val.TopNewsID,
                        DisplayOrder = val.DisplayOrder,
                        Heading = val.Heading,
                        ImageUrl = val.ImageUrl,
                        ShortDesc = val.ShortDescription,
                        //NewsDesc= val.NewsDescription,
                        DttmCreated = val.DttmCreated
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

        [HttpGet]
        public IEnumerable<INews> TopNewsHeader()
        {
            var newsInstance = TopNewsBL.Instance;
            ConcurrentBag<INews> newsList = new ConcurrentBag<INews>();
            try
            {
                var result = newsInstance.SelectRest10TopNews();
                result.AsParallel().ForAll(val =>
                {
                    newsList.Add(new News
                    {
                        NewsID = val.TopNewsID,
                        DisplayOrder = val.DisplayOrder,
                        Heading = val.Heading,
                        ImageUrl = val.ImageUrl,
                        ShortDesc = val.ShortDescription,
                        //NewsDesc = val.NewsDescription,
                        DttmCreated = val.DttmCreated
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

        [HttpGet]
        public IEnumerable<INews> RssTopNews()
        {
            var newsInstance = TopNewsBL.Instance;
            ConcurrentBag<INews> newsList = new ConcurrentBag<INews>();
            try
            {
                var topTodayNews = newsInstance.SelectTodayTopNews();
                if (topTodayNews.Count() > 0)
                {
                    topTodayNews.AsParallel().ForAll(val =>
                    {
                        newsList.Add(new News
                        {
                            NewsID = val.TopNewsID,
                            DisplayOrder = val.DisplayOrder,
                            Heading = val.Heading,
                            ImageUrl = val.ImageUrl,
                            ShortDesc = val.ShortDescription,
                            //NewsDesc= val.NewsDescription,
                            DttmCreated = val.DttmCreated,
                            IsRss = false
                        });

                    });
                }

                var remainNews = 20 - newsList.Count();
                if (remainNews > 0)
                {
                    var topRssNews = RssProviderService.Instance.GetTopNews();
                    if (topRssNews != null && topRssNews.Count() > 0)
                    {
                        int newsCounter = 0;
                        foreach (var val in topRssNews)
                        {
                            if (newsCounter++ >= remainNews)
                                break;

                            newsList.Add(new News
                            {
                                NewsID = val.NewsID,
                                DisplayOrder = val.DisplayOrder,
                                Heading = val.Heading,
                                ImageUrl = val.ImageUrl,
                                ShortDesc = val.ShortDesc,
                                //NewsDesc= val.NewsDescription,
                                DttmCreated = val.DttmCreated,
                                IsRss = true
                            });
                        }
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

            return newsList.OrderByDescending(v => v.DttmCreated);
        }


        [HttpGet]
        public INews NewsDetail(string NewsId)
        {
            var newsInstance = TopNewsBL.Instance;
            INews news = null;
            try
            {
                var result = newsInstance.Select(NewsId).Result;

                if (result.IsActive == 1 && result.IsApproved == 1)
                {
                    news = new News
                    {
                        NewsID = result.TopNewsID,
                        DisplayOrder = result.DisplayOrder,
                        Heading = result.Heading,
                        ImageUrl = result.ImageUrl,
                        ImageCaption = result.ImageCaption,
                        ShortDesc = result.ShortDescription,
                        NewsDesc = result.NewsDescription,
                        DttmCreated = result.DttmCreated
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
        public IEnumerable<INews> NewsList(Int64 NextPage)
        {
            var newsInstance = TopNewsBL.Instance;
            ConcurrentBag<INews> newsList = new ConcurrentBag<INews>();
            try
            {
                var result = newsInstance.SelectAll(NewsType.TopNews, NextPage);
                result.AsParallel().AsOrdered().ForAll(val =>
                {
                    if (val.IsActive == 1 && val.IsApproved == 1)
                    {
                        newsList.Add(new News
                        {
                            NewsID = val.TopNewsID,
                            DisplayOrder = val.DisplayOrder,
                            Heading = val.Heading,
                            ImageUrl = val.ImageUrl,
                            EditorID = string.Empty,
                            EditorName = "",
                            ShortDesc = val.ShortDescription,
                            NewsDesc = val.NewsDescription,
                            DttmCreated = val.DttmCreated
                        });
                    }
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
