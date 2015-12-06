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
                var xDocFirst = new XDocument();
                var xDocSecond = new XDocument();

                Task<XDocument>[] tasks = new Task<XDocument>[2];
                tasks[0] = Task.Factory.StartNew(() => XDocument.Load(RssUrl.DanikJagaranTopNews));
                tasks[1] = Task.Factory.StartNew(() => XDocument.Load(RssUrl.NawBharatTimesTopNews));
                Task.WaitAll(tasks);

                xDocFirst = tasks[0].Result;
                xDocSecond = tasks[1].Result;

                topNewsList.AddRange(TopNewsObject(xDocFirst, false));
                topNewsList.AddRange(TopNewsObject(xDocSecond, true));


                return topNewsList;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private IEnumerable<INews> TopNewsObject(XDocument xDoc, bool IsImgBreak)
        {
            List<INews> newsList = new List<INews>();
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
                //items.ToList().ForEach(item =>
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
                       if (IsImgBreak && !string.IsNullOrEmpty(imgUrl))
                       {
                           imgUrl = imgUrl.Replace('"', ' ').Replace('"', ' ').Remove(imgUrl.LastIndexOf('/'), 1);
                       }
                   }
                   newsList.Add(
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

            return newsList.OrderByDescending( v => v.DttmCreated.Date);
        }

    }
}
