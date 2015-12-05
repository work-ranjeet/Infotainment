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

        public IEnumerable<INews> GetTopNews()
        {
            try
            {
                List<INews> topNewsList = new List<INews>();
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssUrl.DanikJagaranTopNews);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 Heading = x.Element("title").Value,
                                 Link = x.Element("link").Value,
                                 ShortDesc = x.Element("description").Value,
                                 PubDate = x.Element("pubDate").Value,
                                 guid = x.Element("guid").Value
                             });

                if (items != null)
                {
                    items.AsParallel().AsOrdered().ForAll(item =>
                   {
                       string ShortDesc = item.ShortDesc;
                       string imgUrl = string.Empty;
                       string desc = ShortDesc;
                       if (desc.Contains('>'))
                       {
                           var arr = desc.Split('>');
                           if (arr.Length > 1)
                           {
                               ShortDesc = arr[1];
                               imgUrl = arr[0].Split('=')[1];
                           }
                       }
                       topNewsList.Add(
                           new News
                           {
                               NewsID = item.guid,
                               DisplayOrder = 0,
                               Heading = item.Heading,
                               ImageUrl = imgUrl,
                               ShortDesc = ShortDesc,
                               //NewsDesc= val.NewsDescription,
                               DttmCreated = Convert.ToDateTime(item.PubDate)

                           });

                   });
                }

                return topNewsList;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public IEnumerable<INews> GetTopNewsHeader()
        {
            try
            {
                List<INews> topNewsList = new List<INews>();
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssUrl.BhaskarTopNews);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 Heading = x.Element("title").Value,
                                 Link = x.Element("link").Value,
                                 ShortDesc = x.Element("description").Value,
                                 PubDate = x.Element("pubDate").Value,
                                 guid = x.Element("guid").Value
                             });

                if (items != null)
                {
                    items.AsParallel().AsOrdered().ForAll(item =>
                    {
                        string heading = item.Heading.Contains(':') ? item.Heading.Split(':')[1] : item.Heading;
                        string ShortDesc = item.ShortDesc.Replace("&nbsp;", " ").Replace("\n", "");
                        topNewsList.Add(
                            new News
                            {
                                NewsID = item.guid,
                                DisplayOrder = 0,
                                Heading = heading,
                                ImageUrl = String.Empty,
                                ShortDesc = ShortDesc,
                                //NewsDesc= val.NewsDescription,
                                DttmCreated = Convert.ToDateTime(item.PubDate)

                            });

                    });
                }

                return topNewsList;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
