using Infotainment.Data.Controls;
using Infotainment.Data.Entities;
using Infotainment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Infotainment.Controllers
{
    public class AdvertismentApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<IAdvertisment> TopNews()
        {
            var newsInstance = TopNewsBL.Instance;
            List<IAdvertisment> advertismentList = new List<IAdvertisment>();
            try
            {
                var result = newsInstance.SelectFirst10TopNews();
                result.AsParallel().AsOrdered().ForAll(val =>
                {
                    newsList.Add(new News
                    {
                        NewsID = val.TopNewsID,
                        DisplayOrder = val.DisplayOrder,
                        Heading = val.Heading,
                        ImageUrl = val.ImageUrl,
                        ShortDesc = val.ShortDescription,
                        NewsDesc= val.NewsDescription
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
                    newsList.Add(new News
                    {
                        NewsID = val.TopNewsID,
                        DisplayOrder = val.DisplayOrder,
                        Heading = val.Heading,
                        ImageUrl = val.ImageUrl,
                        ShortDesc = val.ShortDescription,
                        NewsDesc = val.NewsDescription
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

            return newsList;
        }


    }
}
