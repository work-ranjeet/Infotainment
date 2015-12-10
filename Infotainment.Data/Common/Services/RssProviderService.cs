using Infotainment.Data.Controls;
using Infotainment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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

        public IEnumerable<ITopNews> GetFirstTopNews()
        {
            try
            {
                var topNewsList = new List<ITopNews>();
                var xDocFirst = XDocument.Load(RssUrl.DanikJagaranTopNews);
                topNewsList.AddRange(TopNewsObject(xDocFirst, false));
                return topNewsList;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public IEnumerable<ITopNews> GetSecondTopNews()
        {
            try
            {
                var topNewsList = new List<ITopNews>();
                var xDocFirst = XDocument.Load(RssUrl.NawBharatTimesTopNews);
                topNewsList.AddRange(TopNewsObject(xDocFirst, false));
                return topNewsList;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public IEnumerable<ITopNews> GetTopNews()
        {
            try
            {
                List<ITopNews> topNewsList = new List<ITopNews>();
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

        private IEnumerable<ITopNews> TopNewsObject(XDocument xDoc, bool IsImgBreak)
        {
            try
            {


                ConcurrentBag<ITopNews> newsList = new ConcurrentBag<ITopNews>();
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
                            new TopNews
                            {
                                TopNewsID = item.guid,
                                DisplayOrder = 0,
                                Heading = item.Heading,
                                ImageUrl = imgUrl,
                                ShortDescription = ShortDesc,
                           //NewsDesc= val.NewsDescription,
                           DttmCreated = Convert.ToDateTime(item.PubDate)

                            });

                    });
                }

                return newsList.OrderByDescending(v => v.DttmCreated.Date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}


//  var client = new WebClient();
//             client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
//             var xmlData = client.DownloadString("http://www.gazzetta.it/rss/Calcio.xml");
// 
//             XDocument xml = XDocument.Parse(xmlData);
// 
//             var GazzettaUpdates = (from story in xml.Descendants("item")
//                              select new FeedGazzetta
//                              {
//                                  Title = ((string)story.Element("title")),
//                                  Link = ((string)story.Element("link")),
//                                  Description = ((string)story.Element("description")),
//                                  PubDate = ((string)story.Element("pubDate")),
//                                  Image = ((string)story.Element("enclosure").Attribute("url"))
//                              }).Take(10).ToList();
// 
//             return GazzettaUpdates;

//   internal Task<string> GetHttpResponseJson(string HttpContent, string UUID)
//         {
//             Task<string> response = null;
//             try
//             {
//                 var handler = new HttpClientHandler();
// 
//                 var client = new HttpClient(handler);
// 
//                 client.DefaultRequestHeaders.Add("Accept", "application/json");
// 
//                 client.DefaultRequestHeaders.Add("reutersuuid", UUID);
// 
//                 client.DefaultRequestHeaders.Add("X-Tr-Applicationid", "PrivateEquity");
// 
//                 // client.DefaultRequestHeaders.Add("Authorization", "Basic SGVtYW50LmNoaXRvZGl5YUB0aG9tc29ucmV1dGVycy5jb206U2VjcmV0MTI=");
// 
//                 HttpContent payLoadContent = new StringContent(HttpContent);
// 
//                 Task<HttpResponseMessage> ResponseMessage = client.PostAsync(GetServiceURL(UUID), payLoadContent);
// 
//                 var result = ResponseMessage.Result;
// 
//                 response = result.Content.ReadAsStringAsync();
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
// 
//             return response;
//         }


//  internal string GetFirmProfile(string parameters, IAppServerServices services)
//         {
//             try
//             {
//                 var param = JsonConvert.DeserializeObject<FirmParameter>(parameters);
// 
//                 string payload = PayloadInstance.FirmProfilePayload(param);
// 
//                 var response = GetHttpResponseJson(payload, services.UserContext.UUID);
// 
//                 return response.Result;
//             }
//             catch (Exception ex)
//             {
//                 services.Logger.LogError("An error has been occurred during loading PE Firm Profile{0}", ex);
//                 return ex.ToString();
//             }
//         }
