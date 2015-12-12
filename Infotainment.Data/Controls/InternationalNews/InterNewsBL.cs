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
    public class InterNewsBL : IDisposable
    {
        public static InterNewsBL Instance
        {
            get { return new InterNewsBL(); }
        }

        #region Auto Generated Code - Insert
        public void Insert(IInterNews objNews, IImageDetail objImageDetail, IUsers user)
        {
            try
            {
                var objdbhelper = new DBHelper();
                var objNewsDB = new InterNewsDB();
                objNews.EditorID = "1";
                objNews.DisplayOrder = 1;
                objNews.IsActive = 0;
                objNews.IsApproved = 0;
                objNews.LanguageID = 1;

                objImageDetail.IsActive = 0;
                objImageDetail.IsFirst = 1;


                objNewsDB.Insert(ref objdbhelper, objNews, objImageDetail, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region /// Update News
        public void GiveApproval(IInterNews news, IUsers user)
        {
            var objdbhelper = new DBHelper();
            try
            {
                InterNewsDB.Instance.GiveApproval(ref objdbhelper, news, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void MakeActive(IInterNews news, IUsers user)
        {
            var objdbhelper = new DBHelper();
            try
            {
                InterNewsDB.Instance.MakeActive(ref objdbhelper, news, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void GiveApprovalFor(IList<IInterNews> newsList, IUsers user)
        {
            var dbhelper = new DBHelper();
            dbhelper.BeginTransaction();

            try
            {
                newsList.ToList().ForEach(item => InterNewsDB.Instance.GiveApproval(ref dbhelper, item, user));

                dbhelper.CommitTransaction();
            }
            catch (Exception objExp)
            {
                dbhelper.RollbackTransaction();
                throw objExp;
            }
        }
        public void MakeActiveFor(IList<IInterNews> newsList, IUsers user)
        {
            var dbhelper = new DBHelper();
            dbhelper.BeginTransaction();

            try
            {
                newsList.ToList().ForEach(item => InterNewsDB.Instance.MakeActive(ref dbhelper, item, user));

                dbhelper.CommitTransaction();
            }
            catch (Exception objExp)
            {
                dbhelper.RollbackTransaction();
                throw objExp;
            }
        }

        public void UpdateNews(ref DBHelper dbHelper, IInterNews news, IImageDetail image, IUsers user)
        {
            try
            {
                news.EditorID = news.EditorID == null ? String.Empty : news.EditorID;
                InterNewsDB.Instance.Update(ref dbHelper, news, image, user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Auto Generated Code - Select
        public IInterNews Select(string NewsID)
        {
            return InterNewsDB.Instance.Select(NewsID);
        }

        public IEnumerable<IInterNews> SelectAllForList(NewsType newsType)
        {
            List<IInterNews> list = null;
            try
            {
                switch (newsType)
                {
                    case NewsType.TopNews:
                        list = InterNewsDB.Instance.SelectAllForList();
                        break;

                    default:
                        throw new NotImplementedException();

                }
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.OrderByDescending(v => v.DttmCreated);
        }

        public IEnumerable<IInterNews> Search(DateTime dateFrom, DateTime dateTo, string Heading)
        {
            IEnumerable<IInterNews> list = null;
            try
            {
                var objNewsDB = new InterNewsDB();
                list = objNewsDB.Search(dateFrom, dateTo, Heading);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list;
        }

        public IEnumerable<IInterNews> SelectToApprove()
        {
            IEnumerable<IInterNews> list = null;
            try
            {
                var objNewsDB = new InterNewsDB();
                list = objNewsDB.SelectToApprove();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().OrderByDescending(v => v.DttmModified);
        }

        public IEnumerable<IInterNews> SelectToActive()
        {
            IEnumerable<IInterNews> list = null;
            try
            {
                var objTopNewsDB = new InterNewsDB();
                list = objTopNewsDB.SelectToActive();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().OrderByDescending(v => v.DttmModified);
        }

        public IEnumerable<IInterNews> SelectTopNews()
        {
            try
            {
                int newsCount = 10;
                int remainNews = newsCount;
                List<IInterNews> newsList = new List<IInterNews>();
                var top20 = new InterNewsDB().Select20TopNews();
                if (top20 != null)
                {
                    newsList.AddRange(top20.OrderByDescending(v => v.DttmCreated).Take(newsCount).ToList());
                }

                if (newsList.Count < newsCount)
                {
                    remainNews = remainNews - newsList.Count;
                    if (remainNews > 0)
                    {
                        var topRssNews = new RssProviderService().GetInternationalNews();
                        if (topRssNews != null && topRssNews.Count() > 0)
                        {
                            int newsCounter = 0;
                            foreach (var val in topRssNews.OrderByDescending(v => v.DttmCreated))
                            {
                                if (newsCounter++ >= remainNews)
                                    break;

                                val.IsRss = true;
                                newsList.Add(val);
                            }
                        }
                    }
                }

                return newsList.Take(newsCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public IEnumerable<IInterNews> SelectFirst10News()
        //{
        //    try
        //    {
        //        int newsCount = 5;
        //        int remainNews = newsCount;
        //        List<IInterNews> newsList = new List<IInterNews>();
        //        var top20 = new InterNewsDB().Select20TopNews();
        //        if (top20 != null)
        //        {
        //            newsList.AddRange(top20.OrderByDescending(v => v.DttmCreated).Take(newsCount).ToList());
        //        }

        //        if (newsList.Count < newsCount)
        //        {
        //            remainNews = remainNews - newsList.Count;
        //            if (remainNews > 0)
        //            {
        //                //var topRssNews = new RssProviderService().GetFirstTopNews();
        //                //if (topRssNews != null && topRssNews.Count() > 0)
        //                //{
        //                //    int newsCounter = 0;
        //                //    foreach (var val in topRssNews.OrderByDescending(v => v.DttmCreated))
        //                //    {
        //                //        if (newsCounter++ >= remainNews)
        //                //            break;

        //                //        val.IsRss = true;
        //                //        newsList.Add(val);
        //                //    }
        //                //}
        //            }
        //        }

        //        return newsList.Take(newsCount);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public IEnumerable<IInterNews> SelectRest10TopNews()
        //{
        //    //var top20 = InterNewsDB.Instance.Select20TopNews();
        //    //return (top20.ToList().FindAll(v => !string.IsNullOrEmpty(v.ImageUrl))).Skip(7).Take(10);

        //    int newsCount = 10;
        //    int remainNews = newsCount;
        //    List<IInterNews> newsList = new List<IInterNews>();

        //    var top20 = InterNewsDB.Instance.Select20TopNews();
        //    if (top20 != null)
        //    {
        //        newsList.AddRange(top20.OrderByDescending(v => v.DttmCreated).Skip(10).Take(newsCount).ToList());
        //    }

        //    if (newsList.Count < newsCount)
        //    {
        //        remainNews = remainNews - newsList.Count;
        //        if (remainNews > 0)
        //        {
        //            //var topRssNews = RssProviderService.Instance.GetSecondTopNews();
        //            //if (topRssNews != null && topRssNews.Count() > 0)
        //            //{
        //            //    int newsCounter = 0;
        //            //    foreach (var val in topRssNews)
        //            //    {
        //            //        if (newsCounter++ >= remainNews)
        //            //            break;

        //            //        val.IsRss = true;
        //            //        newsList.Add(val);
        //            //    }
        //            //}
        //        }
        //    }

        //    return newsList.Take(newsCount);
        //}
        #endregion

        #region Memory
        private bool disposed = false;
        ~InterNewsBL()
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


