using Infotainment.Data;
using Infotainment.Data.Controls;
using Infotainment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Infotainment.Controllers
{
    public class MainNewsApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<INews> TopNews()
        {
            var newsInstance = TopNewsBL.Instance;
            List<INews> newsList = new List<INews>();
            try
            {
                var result = newsInstance.SelectFirst10TopNews();
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
                            ShortDesc = val.ShortDescription,
                            //NewsDesc= val.NewsDescription,
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

            return newsList;
        }

        [HttpGet]
        public IEnumerable<INews> TopNewsHeader()
        {
            var newsInstance = TopNewsBL.Instance;
            List<INews> newsList = new List<INews>();
            try
            {
                var result = newsInstance.SelectRest10TopNews();
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
                            ShortDesc = val.ShortDescription,
                            //NewsDesc = val.NewsDescription,
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

            return newsList;
        }

        [HttpGet]
        public INews NewsDetail(string NewsId)
        {
            var newsInstance = TopNewsBL.Instance;
            INews news = null;
            try
            {
                var result = newsInstance.Select(NewsId);

                if (result.IsActive == 1 && result.IsApproved == 1)
                {
                    news = new News
                    {
                        NewsID = result.TopNewsID,
                        DisplayOrder = result.DisplayOrder,
                        Heading = result.Heading,
                        ImageUrl = result.ImageUrl,
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
        public IEnumerable<INews> NewsList()
        {
            var newsInstance = TopNewsBL.Instance;
            List<INews> newsList = new List<INews>();
            try
            {
                var result = newsInstance.SelectAll(NewsType.TopNews);
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

            return newsList;
        }

    }
}
