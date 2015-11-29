using Infotainment.Data;
using Infotainment.Data.Controls;
using Infotainment.Data.Entities;
using Infotainment.Models.Entities;
using System;
using System.Collections.Concurrent;
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
        public IEnumerable<IAdvertisment> TopNewsAdvertisment()
        {
            var instance = AdvertismentBL.Instance;
            var advertismentList = new ConcurrentBag<IAdvertisment>();
            try
            {
                var result = instance.SelectActive(AdvertismentType.TopNewsAdd);
                result.AsParallel().AsOrdered().ForAll(addvertise =>
                {
                    advertismentList.Add(new Advertisment
                    {
                        AdvertismentID = addvertise.AdvertismentID,
                        DisplayOrder = addvertise.DisplayOrder,
                        Heading = addvertise.Heading,
                        ShortDesc = addvertise.ShortDesc,
                        WebUrl = addvertise.WebUrl,
                        WebLink = addvertise.WebLink,
                        ImgUrl = addvertise.ImgUrl
                    });
                });

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                instance.Dispose();
            }

            return advertismentList;
        }
    }
}
