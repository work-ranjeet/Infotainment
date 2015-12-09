#region Copyright(c) 2015-2020. All Rights Reserved 
/*****************************************************************************
**                                                                          **
**                                                                          **
**                  WARNING --- TRADE SECRET --- WARNING                    **
**                                                                          **
**  This computer program is protected by copyright law and international   **
**  treaties. Unauthorized or distribution of this program, or any portion  **
**  of it may result in severe civil and criminal penalties, and will be    **
**  prosecuted to the maximum extent possible under the law.		           **
**                                                                          **
**                                                                          **
******************************************************************************
*
* Developed By: Oct-11-15, Ranjeet
*****************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PCL.DBHelper;
using System.Web;
using Infotainment.Data.Entities;
using Infotainment.Data.Common.Services;

namespace Infotainment.Data.Controls
{
    public class TopNewsBL : IDisposable
    {
        public static TopNewsBL Instance
        {
            get { return new TopNewsBL(); }
        }

        #region Auto Generated Code - Insert
        public void Insert(ITopNews objTopNews, IImageDetail objImageDetail, IUsers user)
        {
            try
            {
                var objdbhelper = new DBHelper();
                var objTopNewsDB = new TopNewsDB();
                objTopNews.EditorID = "1";
                objTopNews.DisplayOrder = 1;
                objTopNews.IsActive = 0;
                objTopNews.IsApproved = 0;
                objTopNews.LanguageID = 1;

                objImageDetail.IsActive = 0;
                objImageDetail.IsFirst = 1;


                objTopNewsDB.Insert(ref objdbhelper, objTopNews, objImageDetail, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region /// Update News
        public void GiveApproval(ITopNews topNews, IUsers user)
        {
            var objdbhelper = new DBHelper();
            try
            {
                TopNewsDB.Instance.GiveApproval(ref objdbhelper, topNews, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void MakeActive(ITopNews topNews, IUsers user)
        {
            var objdbhelper = new DBHelper();
            try
            {
                TopNewsDB.Instance.MakeActive(ref objdbhelper, topNews, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void GiveApprovalFor(IList<ITopNews> topNewsList, IUsers user)
        {
            var dbhelper = new DBHelper();
            dbhelper.BeginTransaction();

            try
            {
                topNewsList.ToList().ForEach(item => TopNewsDB.Instance.GiveApproval(ref dbhelper, item, user));

                dbhelper.CommitTransaction();
            }
            catch (Exception objExp)
            {
                dbhelper.RollbackTransaction();
                throw objExp;
            }
        }
        public void MakeActiveFor(IList<ITopNews> topNewsList, IUsers user)
        {
            var dbhelper = new DBHelper();
            dbhelper.BeginTransaction();

            try
            {
                topNewsList.ToList().ForEach(item => TopNewsDB.Instance.MakeActive(ref dbhelper, item, user));

                dbhelper.CommitTransaction();
            }
            catch (Exception objExp)
            {
                dbhelper.RollbackTransaction();
                throw objExp;
            }
        }

        public void UpdateNews(ref DBHelper dbHelper, ITopNews news, IImageDetail image, IUsers user)
        {
            try
            {
                news.EditorID = news.EditorID == null ? String.Empty : news.EditorID;
                TopNewsDB.Instance.Update(ref dbHelper, news, image, user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Auto Generated Code - Select
        public async Task<ITopNews> Select(string NewsID)
        {
            return await Task.Run(() =>
            {
                return TopNewsDB.Instance.Select(NewsID);
            });
        }

        public IEnumerable<ITopNews> SelectAll(NewsType newsType, Int64? NextPageValue)
        {
            List<ITopNews> list = null;
            try
            {
                switch (newsType)
                {
                    case NewsType.TopNews:
                        list = TopNewsDB.Instance.SelectAll(NextPageValue);
                        break;

                    default:
                        throw new NotImplementedException();

                }
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.OrderByDescending( v => v.DttmCreated);
        }

        public IEnumerable<ITopNews> SelectAll(DateTime dateFrom, DateTime dateTo, string Heading)
        {
            IEnumerable<ITopNews> list = null;
            try
            {
                var objTopNewsDB = new TopNewsDB();
                list = objTopNewsDB.Search(dateFrom, dateTo, Heading);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list;
        }

        public IEnumerable<ITopNews> SelectTopNewsForApproval()
        {
            IEnumerable<ITopNews> list = null;
            try
            {
                var objTopNewsDB = new TopNewsDB();
                list = objTopNewsDB.SelectTopNewsForActivate();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().FindAll(v => v.IsApproved == 0).OrderByDescending(v => v.DttmModified);
        }

        public IEnumerable<ITopNews> SelectTopNewsForActivate()
        {
            IEnumerable<ITopNews> list = null;
            try
            {
                var objTopNewsDB = new TopNewsDB();
                list = objTopNewsDB.SelectTopNewsForActivate();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().FindAll(v => v.IsActive == 0 && v.IsApproved == 1).OrderByDescending(v => v.DttmModified);
        }

        public IEnumerable<ITopNews> Select20TopNews(int topNumber)
        {
            var top20 = TopNewsDB.Instance.Select20TopNews();

            return (top20.ToList().FindAll(v => !string.IsNullOrEmpty(v.ImageUrl))).Take(topNumber);
        }

        public IEnumerable<ITopNews> SelectFirst10TopNews()
        {
            int newsCount = 10;
            var top20 = TopNewsDB.Instance.Select20TopNews().OrderByDescending(v => v.DttmCreated).Take(newsCount).ToList();
            if (top20.Count < newsCount)
            {
                var remainNews = 10 - top20.Count;
                if (remainNews > 0)
                {
                    var topRssNews = RssProviderService.Instance.GetFirstTopNews();
                    if (topRssNews != null && topRssNews.Count() > 0)
                    {
                        int newsCounter = 0;
                        foreach (var val in topRssNews.OrderByDescending(v => v.DttmCreated))
                        {
                            if (newsCounter++ >= remainNews)
                                break;

                            val.IsRss = true;
                            top20.Add(val);
                        }
                    }
                }
            }

            return top20.Take(newsCount);
        }

        public IEnumerable<ITopNews> SelectRest10TopNews()
        {
            int newsCount = 10;
            var top20 = TopNewsDB.Instance.Select20TopNews().OrderByDescending(v => v.DttmCreated).Skip(10).Take(newsCount).ToList();
            if (top20.Count < newsCount)
            {
                var remainNews = 10 - top20.Count;
                if (remainNews > 0)
                {
                    var topRssNews = RssProviderService.Instance.GetSecondTopNews();
                    if (topRssNews != null && topRssNews.Count() > 0)
                    {
                        int newsCounter = 0;
                        foreach (var val in topRssNews)
                        {
                            if (newsCounter++ >= remainNews)
                                break;

                            val.IsRss = true;
                            top20.Add(val);
                        }
                    }
                }
            }

            return top20.Take(newsCount);
        }

        public IEnumerable<ITopNews> SelectTodayTopNews()
        {
            var top20 = TopNewsDB.Instance.Select20TopNews();

            return (top20.ToList().FindAll(v => !string.IsNullOrEmpty(v.ImageUrl) && v.DttmCreated.Date == DateTime.Now.Date)).Take(20);
        }
       
        #endregion

        #region Memory
        private bool disposed = false;
        ~TopNewsBL()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }


                disposed = true;
            }
        }
        #endregion

    }
}


