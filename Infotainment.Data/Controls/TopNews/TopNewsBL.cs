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

namespace Infotainment.Data.Controls
{
    public class TopNewsBL : IDisposable
    {
        public static TopNewsBL Instance
        {
            get { return new TopNewsBL(); }
        }

        #region Auto Generated Code - Insert
        public void Insert(ITopNews objTopNews, IImageDetail objImageDetail)
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


                objTopNewsDB.Insert(ref objdbhelper, objTopNews, objImageDetail);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region /// Update News
        public void GiveApproval(ITopNews topNews)
        {
            var objdbhelper = new DBHelper();
            try
            {
                TopNewsDB.Instance.GiveApproval(ref objdbhelper, topNews);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void MakeActive(ITopNews topNews)
        {
            var objdbhelper = new DBHelper();
            try
            {
                TopNewsDB.Instance.MakeActive(ref objdbhelper, topNews);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void GiveApprovalFor(IList<ITopNews> topNewsList)
        {
            var dbhelper = new DBHelper();
            dbhelper.BeginTransaction();

            try
            {
                topNewsList.ToList().ForEach(item => TopNewsDB.Instance.GiveApproval(ref dbhelper, item));              

                dbhelper.CommitTransaction();
            }
            catch (Exception objExp)
            {
                dbhelper.RollbackTransaction();
                throw objExp;
            }
        }

        public void MakeActiveFor(IList<ITopNews> topNewsList)
        {
            var dbhelper = new DBHelper();
            dbhelper.BeginTransaction();

            try
            {
                topNewsList.ToList().ForEach(item => TopNewsDB.Instance.MakeActive(ref dbhelper, item));

                dbhelper.CommitTransaction();
            }
            catch (Exception objExp)
            {
                dbhelper.RollbackTransaction();
                throw objExp;
            }
        }

        #endregion

        #region Auto Generated Code - Select
        public ITopNews Select(string NewsID)
        {
            return null;
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

        public IEnumerable<ITopNews> SelectTopeNewsForApproval()
        {
            IEnumerable<ITopNews> list = null;
            try
            {
                var objTopNewsDB = new TopNewsDB();
                list = objTopNewsDB.SelectAllTopNews();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().FindAll(v => v.IsApproved == 0).OrderByDescending(v => v.DttmModified);
        }

        public IEnumerable<ITopNews> SelectTopeNewsForActivate()
        {
            IEnumerable<ITopNews> list = null;
            try
            {
                var objTopNewsDB = new TopNewsDB();
                list = objTopNewsDB.SelectAllTopNews();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().FindAll(v => v.IsActive == 0 && v.IsApproved == 1).OrderByDescending(v => v.DttmModified);
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


