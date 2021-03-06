﻿using Infotainment.Data;
using Infotainment.Data.Controls;
using Infotainment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Infotainment.Controllers
{
    public class InternationalNewsApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<INews> FirstNews()
        {
            var newsInstance = InterNewsBL.Instance;
            var newsList = new ConcurrentBag<INews>();
            try
            {
                var result = newsInstance.SelectTopNews();
                result.AsParallel().AsOrdered().ForAll(val =>
                {
                    newsList.Add(new News
                    {
                        NewsID = val.NewsID,
                        DisplayOrder = val.DisplayOrder,
                        Heading = val.Heading,
                        ImageUrl = val.ImageUrl,
                        ShortDesc = val.ShortDescription,
                        IsRss = val.IsRss,
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

        //[HttpGet]
        //public IEnumerable<INews> NewsHeader()
        //{
        //    var newsInstance = InterNewsBL.Instance;
        //    ConcurrentBag<INews> newsList = new ConcurrentBag<INews>();
        //    try
        //    {
        //        var result = newsInstance.SelectRest10TopNews();
        //        result.AsParallel().AsOrdered().ForAll(val =>
        //        {
        //            newsList.Add(new News
        //            {
        //                NewsID = val.NewsID,
        //                DisplayOrder = val.DisplayOrder,
        //                Heading = val.Heading,
        //                ImageUrl = val.ImageUrl,
        //                ShortDesc = val.ShortDescription,
        //                //NewsDesc = val.NewsDescription,
        //                DttmCreated = val.DttmCreated
        //            });
        //        });

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        newsInstance.Dispose();
        //    }

        //    return newsList.OrderByDescending(v => v.DttmCreated); 
        //}

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
        public IEnumerable<INews> NewsList(Int64 NextPage)
        {
            var newsInstance = InterNewsBL.Instance;
            ConcurrentBag<INews> newsList = new ConcurrentBag<INews>();
            try
            {
                var result = newsInstance.SelectAllForList(NextPage);
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
