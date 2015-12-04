using Infotainment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infotainment.Data.Common.Services
{
    public class RssProviderService
    {
        public static RssProviderService Instance
        {
            get
            {
                return new RssProviderService();
            }
        }

        public IEnumerable<INews> GetHindustanTopNews()
        {
            try
            {
                List<INews> topNewsList = new List<INews>();
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssUrl.LivehindustanTopNews);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 link = x.Element("link").Value,
                                 auther = x.Element("author").Value,
                                 pubDate = x.Element("pubDate").Value,
                                 guid = x.Element("guid").Value,
                                 thumbnail = x.Element("thumbnail").Value,
                                 smallimage = x.Element("smallimage").Value,
                                 bigimage = x.Element("bigimage").Value,
                             });

                if (items != null)
                {
                    items.AsParallel().AsOrdered().ForAll(item =>
                   {
                   //topNewsList.Add(
                   //    new News
                   //    {
                   //        NewsID = item.,
                   //        DisplayOrder = val.DisplayOrder,
                   //        Heading = val.Heading,
                   //        ImageUrl = val.ImageUrl,
                   //        ShortDesc = val.ShortDescription,
                   //        //NewsDesc= val.NewsDescription,
                   //        DttmCreated = val.DttmCreated

                   //    });

               });
                }

                return null;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
