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

        #region /// Top News
        public IEnumerable<ITopNews> GetFirstTopNews()
        {
            try
            {
                var topNewsList = new List<ITopNews>();
                var xDocFirst = XDocument.Load(RssUrl.DanikJagaranTopNews);
                topNewsList.AddRange(NewsObject(xDocFirst, false));
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
                topNewsList.AddRange(NewsObject(xDocFirst, false));
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

                topNewsList.AddRange(NewsObject(xDocFirst, false));
                topNewsList.AddRange(NewsObject(xDocSecond, true));


                return topNewsList;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region /// International News
        public IEnumerable<IInterNews> GetInternationalNews()
        {
            try
            {
                var topNewsList = new List<IInterNews>();
                var xDocFirst = XDocument.Load(RssUrl.DanikJagaranInternationalNews);
                topNewsList.AddRange(InterNewsObject(xDocFirst, false));
                return topNewsList;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region /// State News
        public IEnumerable<IStateNews> GetStateRssNews(string StateCode)
        {
            var newsList = new ConcurrentBag<IStateNews>();
            var stateObj = RssUrl.Instance.GetState(StateCode);
            if (stateObj != null)
            {
                var urlList = stateObj.DistRssUrl;

                int taskCounter = 0;
                Task<ConcurrentBag<IStateNews>>[] tasks = new Task<ConcurrentBag<IStateNews>>[urlList.Count()];
                urlList.ToList().ForEach(url => tasks[taskCounter++] = Task.Factory.StartNew(() => StateNewsList(url, false)));
                Task.WaitAll(tasks);

                tasks.ToList().ForEach(result =>
                {
                    var resultList = result.Result;
                    resultList.ToList().ForEach(news => newsList.Add(news));

                });
            }

            return newsList;
        }
        #endregion

        private IEnumerable<ITopNews> NewsObject(XDocument xDoc, bool IsImgBreak)
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

        private IEnumerable<IInterNews> InterNewsObject(XDocument xDoc, bool IsImgBreak)
        {
            try
            {
                ConcurrentBag<IInterNews> newsList = new ConcurrentBag<IInterNews>();
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
                            new InterNews
                            {
                                NewsID = item.guid,
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

        private ConcurrentBag<IStateNews> StateNewsList(string Url, bool IsImgBreak)
        {
            try
            {
                ConcurrentBag<IStateNews> newsList = new ConcurrentBag<IStateNews>();
                var xDoc = XDocument.Load(Url);
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
                                var imgurl = arr[0].Split('=');

                                imgUrl = imgurl.Length > 1 ? imgurl[1] : " ";
                            }
                            if (IsImgBreak && !string.IsNullOrEmpty(imgUrl))
                            {
                                imgUrl = imgUrl.Replace('"', ' ').Replace('"', ' ').Remove(imgUrl.LastIndexOf('/'), 1);
                            }
                        }
                        newsList.Add(
                            new StateNews
                            {
                                NewsID = item.guid,
                                DisplayOrder = 0,
                                Heading = item.Heading,
                                ImageUrl = imgUrl,
                                ShortDescription = ShortDesc,
                                //NewsDesc= val.NewsDescription,
                                DttmCreated = Convert.ToDateTime(item.PubDate),
                                IsRss = true

                            });

                    });
                }

                return newsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

