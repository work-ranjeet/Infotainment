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
using Infotainment.Data.Entities.Common;
using Infotainment.Data.Controls.Common;

namespace Infotainment.Data.Controls
{
    public class StateNewsBL : IDisposable
    {
        public static StateNewsBL Instance
        {
            get { return new StateNewsBL(); }
        }

        #region Auto Generated Code - Insert
        public void Insert(ref DBHelper objdbhelper, IStateNews objNews, IImageDetail objImageDetail, IUsers user)
        {

            var objNewsDB = StateNewsDB.Instance;
            try
            {
                objNews.EditorID = "1";
                objNews.DisplayOrder = 1;
                objNews.IsActive = 0;
                objNews.IsApproved = 0;
                objNews.LanguageID = 1;
                //objNews.StateCode = "BR";

                objImageDetail.IsActive = 0;
                objImageDetail.IsFirst = 1;


                StateNewsDB.Instance.Insert(ref objdbhelper, objNews, objImageDetail, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                objdbhelper.Dispose();
                objNewsDB.Dispose();
            }
        }
        #endregion

        #region /// Update News
        public void GiveApproval(IStateNews news, IUsers user)
        {
            var objdbhelper = DBHelper.Instance;
            try
            {
                StateNewsDB.Instance.GiveApproval(ref objdbhelper, news, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                objdbhelper.Dispose();
            }
        }

        public void MakeActive(IStateNews news, IUsers user)
        {
            var objdbhelper = new DBHelper();
            try
            {
                StateNewsDB.Instance.MakeActive(ref objdbhelper, news, user);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                objdbhelper.Dispose();
            }
        }

        public void GiveApprovalFor(IList<IStateNews> newsList, IUsers user)
        {
            var dbhelper = DBHelper.Instance;
            dbhelper.BeginTransaction();

            try
            {
                newsList.ToList().ForEach(item => StateNewsDB.Instance.GiveApproval(ref dbhelper, item, user));

                dbhelper.CommitTransaction();
            }
            catch (Exception objExp)
            {
                dbhelper.RollbackTransaction();
                throw objExp;
            }
            finally
            {
                dbhelper.Dispose();
            }
        }
        public void MakeActiveFor(IList<IStateNews> newsList, IUsers user)
        {
            var dbhelper = DBHelper.Instance;
            dbhelper.BeginTransaction();

            try
            {
                newsList.ToList().ForEach(item => StateNewsDB.Instance.MakeActive(ref dbhelper, item, user));

                dbhelper.CommitTransaction();
            }
            catch (Exception objExp)
            {
                dbhelper.RollbackTransaction();
                throw objExp;
            }
            finally
            {
                dbhelper.Dispose();
            }
        }

        public void UpdateNews(ref DBHelper dbHelper, IStateNews news, IImageDetail image, IUsers user)
        {
            try
            {
                news.EditorID = news.EditorID == null ? String.Empty : news.EditorID;
                StateNewsDB.Instance.Update(ref dbHelper, news, image, user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Auto Generated Code - Select
        public IStateNews Select(string NewsID)
        {
            return StateNewsDB.Instance.Select(NewsID);
        }

        public IEnumerable<IStateNews> SelectForPartialNewsList(NewsType newsType)
        {
            List<IStateNews> list = null;
            try
            {
                switch (newsType)
                {
                    case NewsType.TopNews:
                        list = StateNewsDB.Instance.SelectForPartialNewsList("", 0);
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

        public IEnumerable<IStateNews> Search(DateTime dateFrom, DateTime dateTo, string Heading, string StateCode)
        {
            IEnumerable<IStateNews> list = null;
            try
            {
                list = StateNewsDB.Instance.Search(dateFrom, dateTo, Heading, StateCode);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list;
        }

        public IEnumerable<IStateNews> SelectToApprove()
        {
            IEnumerable<IStateNews> list = null;
            try
            {
                list = StateNewsDB.Instance.SelectToApprove();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().OrderByDescending(v => v.DttmModified);
        }

        public IEnumerable<IStateNews> SelectToActive()
        {
            IEnumerable<IStateNews> list = null;
            try
            {
                list = StateNewsDB.Instance.SelectToActive();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().OrderByDescending(v => v.DttmModified);
        }

        public IEnumerable<IStateNews> SelectStateNewsForApi()
        {
            try
            {
                int newsCount = 15;
                int remainNews = newsCount;
                List<IStateNews> newsList = new List<IStateNews>();

                Task<IEnumerable<IStateNews>> newsTask = Task.Factory.StartNew(() => StateNewsDB.Instance.SelectStateNewsForApi());
                Task<IEnumerable<IStateCode>> stateCodeTask = Task.Factory.StartNew(() => StateCodeBL.Instance.SelectStates());
                Task.WaitAll(newsTask, stateCodeTask);

                var statesNews = newsTask.Result; 
                if (statesNews != null && statesNews.Count() > 0)
                {
                    newsList.AddRange(statesNews);
                }

                var stateCodes = stateCodeTask.Result;
                if (stateCodes != null && stateCodes.Count() > 0)
                {
                    stateCodes.AsParallel().ForAll(sc =>
                    {
                        var stateNews = newsList.FindAll(n => !string.IsNullOrEmpty(n.StateCode) && n.StateCode.Trim() == sc.Code.Trim());
                        remainNews = stateNews != null && stateNews.Count > 0 ? newsCount - stateNews.Count : newsCount;
                        if (remainNews > 0)
                        {
                            var rssNews = RssProviderService.Instance.GetStateRssNews(sc.Code);
                            if (rssNews != null && rssNews.Count() > 0)
                            {
                                int newsCounter = 0;
                                foreach (var val in rssNews.OrderByDescending(v => v.DttmCreated))
                                {
                                    if (newsCounter++ >= remainNews)
                                        break;

                                    val.IsRss = true;
                                    val.StateCode = sc.Code;
                                    val.StateName = sc.NameHindi;
                                    newsList.Add(val);
                                }
                            }
                        }
                    });
                }

                return newsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region Memory
        private bool disposed = false;
        ~StateNewsBL()
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


