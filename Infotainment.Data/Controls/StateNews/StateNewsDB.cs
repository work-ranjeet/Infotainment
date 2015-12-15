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
using System.Data;
using PCL.DBHelper;
using System.Collections.Generic;
using Infotainment.Data.Common;
using Infotainment.Data.Entities;

namespace Infotainment.Data.Controls
{
    public class StateNewsDB : DBInstanceAbstract, IDisposable
    {
        public static StateNewsDB Instance
        {
            get { return new StateNewsDB(); }
        }

        #region Auto Generated Code - Insert

        internal void Insert(ref DBHelper dbInstance, IStateNews objNews, IImageDetail objImageDetail, IUsers user)
        {
            try
            {
                dbInstance.ClearAllParameters();
                dbInstance.AddInParameter("@EditorID", objNews.EditorID, DbType.String);
                dbInstance.AddInParameter("@DisplayOrder", objNews.DisplayOrder, DbType.Int32);
                dbInstance.AddInParameter("@Heading", objNews.Heading, DbType.String);
                dbInstance.AddInParameter("@ShortDescription", objNews.ShortDescription, DbType.String);
                dbInstance.AddInParameter("@NewsDescription", objNews.NewsDescription, DbType.String);
                dbInstance.AddInParameter("@LanguageID", objNews.LanguageID, DbType.Int32);
                dbInstance.AddInParameter("@StateCode", objNews.StateCode, DbType.String);
                dbInstance.AddInParameter("@IsTopNews", objNews.IsTopNews, DbType.Int32);
                dbInstance.AddInParameter("@ImageUrl", objImageDetail.ImageUrl, DbType.String);
                dbInstance.AddInParameter("@Caption", objImageDetail.Caption, DbType.String);
                dbInstance.AddInParameter("@CaptionLink", objImageDetail.CaptionLink, DbType.String);
                dbInstance.AddInParameter("@ImageType", objImageDetail.ImageType, DbType.Int32);
                dbInstance.AddInParameter("@IsFirst", objImageDetail.IsFirst, DbType.Int32);
                dbInstance.AddInParameter("@UserID", user.UserID, DbType.Int64);

                dbInstance.ExecuteNonQuery(ProcedureName.InsertStateNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Update
        internal void GiveApproval(ref DBHelper dbHelper, IStateNews objNews, IUsers user)
        {
            try
            {
                dbHelper.ClearAllParameters();
                dbHelper.AddInParameter("@NewsID", objNews.NewsID, DbType.String);
                dbHelper.AddInParameter("@IsApproved", objNews.IsApproved, DbType.Int32);
                //dbHelper.AddInParameter("@StateCode", objNews.StateCode, DbType.String);
                dbHelper.AddInParameter("@UserID", user.UserID, DbType.Int64);
                dbHelper.ExecuteNonQuery(ProcedureName.MakeApprovedStateNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        internal void MakeActive(ref DBHelper dbHelper, IStateNews objNews, IUsers user)
        {
            try
            {
                dbHelper.ClearAllParameters();
                dbHelper.AddInParameter("@NewsID", objNews.NewsID, DbType.String);
                //dbHelper.AddInParameter("@StateCode", objNews.StateCode, DbType.String);
                dbHelper.AddInParameter("@IsActive", objNews.IsActive, DbType.Int32);
                dbHelper.AddInParameter("@UserID", user.UserID, DbType.Int64);
                dbHelper.ExecuteNonQuery(ProcedureName.MakeActiveStateNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        internal void Update(ref DBHelper dbHelper, IStateNews news, IImageDetail image, IUsers user)
        {
            try
            {
                dbHelper.ClearAllParameters();
                dbHelper.AddInParameter("@NewsID", news.NewsID, DbType.String);
                dbHelper.AddInParameter("@EditorID", news.EditorID, DbType.String);
                dbHelper.AddInParameter("@DisplayOrder", news.DisplayOrder, DbType.Int32);
                dbHelper.AddInParameter("@Heading", news.Heading, DbType.String);
                dbHelper.AddInParameter("@ShortDescription", news.ShortDescription, DbType.String);
                dbHelper.AddInParameter("@NewsDescription", news.NewsDescription, DbType.String);
                dbHelper.AddInParameter("@LanguageID", news.LanguageID, DbType.Int32);
                dbHelper.AddInParameter("@StateCode", news.StateCode, DbType.String);
                dbHelper.AddInParameter("@IsActive", news.IsActive, DbType.Int32);
                dbHelper.AddInParameter("@IsApproved", news.IsApproved, DbType.Int32);
                dbHelper.AddInParameter("@IsTopNews", news.IsTopNews, DbType.Int32);
                dbHelper.AddInParameter("@ImageUrl", image.ImageUrl, DbType.String);
                dbHelper.AddInParameter("@Caption", image.Caption, DbType.String);
                dbHelper.AddInParameter("@CaptionLink", image.Caption, DbType.String);
                dbHelper.AddInParameter("@ImageType", image.ImageType, DbType.Int32);
                dbHelper.AddInParameter("@IsFirst", image.IsFirst, DbType.Int32);
                dbHelper.AddInParameter("@IsActieImage", image.IsActive, DbType.Int32);
                dbHelper.AddInParameter("@UserID", user.UserID, DbType.Int64);

                dbHelper.ExecuteNonQuery(ProcedureName.UpdateStateNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Delete

        internal void Delete(ref DBHelper dbHelper, System.Int64 NewsID)
        {
            try
            {
                throw new NotImplementedException();
                //string strQuery = String.Empty;
                //strQuery += "Delete from TopNews where TopNewsID = " + NewsID;
                //dbHelper.ExecuteNonQuery(strQuery);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        #endregion

        #region Auto Generated Code - Select
        internal IStateNews Select(string NewsID)
        {
            IStateNews objNews = null;
            IDataReader objDataReader = null;
            var dbHelper = DBHelper.Instance;
            try
            {
                dbHelper.AddInParameter("@NewsID", NewsID, DbType.String);
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectStateNews, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    while (objDataReader.Read())
                    {
                        objNews = new StateNews();

                        if (!objDataReader.IsDBNull(0))
                            objNews.NewsID = objDataReader.GetString(0);

                        if (!objDataReader.IsDBNull(1))
                            objNews.EditorID = objDataReader.GetString(1);

                        if (!objDataReader.IsDBNull(2))
                            objNews.DisplayOrder = objDataReader.GetInt32(2);

                        if (!objDataReader.IsDBNull(3))
                            objNews.Heading = objDataReader.GetString(3);

                        if (!objDataReader.IsDBNull(4))
                            objNews.ShortDescription = objDataReader.GetString(4);

                        if (!objDataReader.IsDBNull(5))
                            objNews.NewsDescription = objDataReader.GetString(5);

                        if (!objDataReader.IsDBNull(6))
                            objNews.LanguageID = objDataReader.GetInt32(6);

                        if (!objDataReader.IsDBNull(7))
                            objNews.StateCode = objDataReader.GetString(7);

                        if (!objDataReader.IsDBNull(8))
                            objNews.IsApproved = objDataReader.GetInt32(8);

                        if (!objDataReader.IsDBNull(9))
                            objNews.IsActive = objDataReader.GetInt32(9);

                        if (!objDataReader.IsDBNull(10))
                            objNews.IsTopNews = objDataReader.GetInt32(10);

                        if (!objDataReader.IsDBNull(11))
                            objNews.DttmCreated = objDataReader.GetDateTime(11);

                        if (!objDataReader.IsDBNull(12))
                            objNews.DttmModified = objDataReader.GetDateTime(12);

                        if (!objDataReader.IsDBNull(13))
                            objNews.ImageUrl = objDataReader.GetString(13);

                        if (!objDataReader.IsDBNull(14))
                            objNews.ImageCaption = objDataReader.GetString(14);

                        if (!objDataReader.IsDBNull(15))
                            objNews.ImageCaptionLink = objDataReader.GetString(15);

                    }
                }

                if (!objDataReader.IsClosed)
                    objDataReader.Close();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                dbHelper.ClearAllParameters();
                dbHelper.CloseConnection();
                dbHelper.Dispose();
            }

            return objNews;
        }

        // need to write
        internal List<IStateNews> SelectForPartialNewsList(string StateCode, int PageNumber)
        {
            IDataReader objDataReader = null;
            List<IStateNews> objNewsList = null;
            IStateNews objNews = null;

            DBHelper dbHelper = new DBHelper();
            try
            {
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectAllInterForList, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IStateNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new StateNews();

                            if (!objDataReader.IsDBNull(0))
                                objNews.NewsID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objNews.EditorID = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objNews.DisplayOrder = objDataReader.GetInt32(2);

                            if (!objDataReader.IsDBNull(3))
                                objNews.Heading = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objNews.ShortDescription = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objNews.NewsDescription = objDataReader.GetString(5);

                            if (!objDataReader.IsDBNull(6))
                                objNews.LanguageID = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objNews.StateCode = objDataReader.GetString(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.IsApproved = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsActive = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.IsTopNews = objDataReader.GetInt32(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.DttmCreated = objDataReader.GetDateTime(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.DttmModified = objDataReader.GetDateTime(12);

                            if (!objDataReader.IsDBNull(13))
                                objNews.ImageUrl = objDataReader.GetString(13);

                            if (!objDataReader.IsDBNull(14))
                                objNews.ImageCaption = objDataReader.GetString(14);

                            if (!objDataReader.IsDBNull(15))
                                objNews.ImageCaptionLink = objDataReader.GetString(15);

                            objNewsList.Add(objNews);
                        }

                    }
                    while (objDataReader.NextResult());
                }

                if (!objDataReader.IsClosed)
                    objDataReader.Close();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                dbHelper.ClearAllParameters();
                dbHelper.CloseConnection();
                dbHelper.Dispose();
            }

            return objNewsList;
        }

        internal List<IStateNews> SelectToApprove()
        {
            IDataReader objDataReader = null;
            List<IStateNews> objNewsList = null;
            IStateNews objNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {                
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectStateNewsToApprove, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IStateNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new StateNews();

                            if (!objDataReader.IsDBNull(0))
                                objNews.NewsID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objNews.EditorID = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objNews.DisplayOrder = objDataReader.GetInt32(2);

                            if (!objDataReader.IsDBNull(3))
                                objNews.Heading = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objNews.ShortDescription = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objNews.NewsDescription = objDataReader.GetString(5);

                            if (!objDataReader.IsDBNull(6))
                                objNews.LanguageID = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objNews.StateCode = objDataReader.GetString(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.StateName = objDataReader.GetString(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsApproved = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.IsActive = objDataReader.GetInt32(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.IsTopNews = objDataReader.GetInt32(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.DttmCreated = objDataReader.GetDateTime(12);

                            if (!objDataReader.IsDBNull(13))
                                objNews.DttmModified = objDataReader.GetDateTime(13);

                            if (!objDataReader.IsDBNull(14))
                                objNews.ImageUrl = objDataReader.GetString(14);

                            if (!objDataReader.IsDBNull(15))
                                objNews.ImageCaption = objDataReader.GetString(15);

                            if (!objDataReader.IsDBNull(16))
                                objNews.ImageCaptionLink = objDataReader.GetString(16);

                            objNewsList.Add(objNews);
                        }

                    }
                    while (objDataReader.NextResult());
                }

                if (!objDataReader.IsClosed)
                    objDataReader.Close();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                dbHelper.ClearAllParameters();
                dbHelper.CloseConnection();
                dbHelper.Dispose();
            }

            return objNewsList;
        }

        internal List<IStateNews> SelectToActive()
        {
            IDataReader objDataReader = null;
            List<IStateNews> objNewsList = null;
            IStateNews objNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectStateNewsToActive, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IStateNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new StateNews();

                            if (!objDataReader.IsDBNull(0))
                                objNews.NewsID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objNews.EditorID = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objNews.DisplayOrder = objDataReader.GetInt32(2);

                            if (!objDataReader.IsDBNull(3))
                                objNews.Heading = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objNews.ShortDescription = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objNews.NewsDescription = objDataReader.GetString(5);

                            if (!objDataReader.IsDBNull(6))
                                objNews.LanguageID = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objNews.StateCode = objDataReader.GetString(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.StateName = objDataReader.GetString(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsApproved = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.IsActive = objDataReader.GetInt32(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.IsTopNews = objDataReader.GetInt32(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.DttmCreated = objDataReader.GetDateTime(12);

                            if (!objDataReader.IsDBNull(13))
                                objNews.DttmModified = objDataReader.GetDateTime(13);

                            if (!objDataReader.IsDBNull(14))
                                objNews.ImageUrl = objDataReader.GetString(14);

                            if (!objDataReader.IsDBNull(15))
                                objNews.ImageCaption = objDataReader.GetString(15);

                            if (!objDataReader.IsDBNull(16))
                                objNews.ImageCaptionLink = objDataReader.GetString(16);

                            objNewsList.Add(objNews);
                        }

                    }
                    while (objDataReader.NextResult());
                }

                if (!objDataReader.IsClosed)
                    objDataReader.Close();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                dbHelper.ClearAllParameters();
                dbHelper.CloseConnection();
                dbHelper.Dispose();
            }

            return objNewsList;
        }

        internal IEnumerable<IStateNews> SelectStateNewsForApi(string StateCode)
        {
            IDataReader objDataReader = null;
            List<IStateNews> objNewsList = null;
            IStateNews objNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                dbHelper.AddInParameter("@StateCode", StateCode, DbType.String);
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectStateNewsForApi, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IStateNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new StateNews();

                            if (!objDataReader.IsDBNull(0))
                                objNews.NewsID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objNews.EditorID = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objNews.DisplayOrder = objDataReader.GetInt32(2);

                            if (!objDataReader.IsDBNull(3))
                                objNews.Heading = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objNews.ShortDescription = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objNews.NewsDescription = objDataReader.GetString(5);

                            if (!objDataReader.IsDBNull(6))
                                objNews.LanguageID = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objNews.StateCode = objDataReader.GetString(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.IsApproved = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsActive = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.IsTopNews = objDataReader.GetInt32(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.DttmCreated = objDataReader.GetDateTime(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.DttmModified = objDataReader.GetDateTime(12);

                            if (!objDataReader.IsDBNull(13))
                                objNews.ImageUrl = objDataReader.GetString(13);

                            if (!objDataReader.IsDBNull(14))
                                objNews.ImageCaption = objDataReader.GetString(14);

                            if (!objDataReader.IsDBNull(15))
                                objNews.ImageCaptionLink = objDataReader.GetString(15);

                            objNewsList.Add(objNews);
                        }

                    }
                    while (objDataReader.NextResult());
                }

                if (!objDataReader.IsClosed)
                    objDataReader.Close();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                dbHelper.ClearAllParameters();
                dbHelper.CloseConnection();
                dbHelper.Dispose();
            }

            return objNewsList.FindAll(v => v.DttmCreated.Date == DateTime.Now.Date || v.DttmCreated.Date.AddDays(-1) == DateTime.Now.Date.AddDays(-1)); ;
        }

        internal List<IStateNews> Search(DateTime dateFrom, DateTime dateTo, string Heading, string StateCode)
        {
            IDataReader objDataReader = null;
            List<IStateNews> objNewsList = null;
            IStateNews objNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                dbHelper.AddInParameter("@DateFrom", dateFrom.ToString("yyyy-MM-dd"));
                dbHelper.AddInParameter("@DateTo", dateTo.ToString("yyyy-MM-dd"));
                dbHelper.AddInParameter("@Heading", "%" + Heading + "%", DbType.String);
                dbHelper.AddInParameter("@StateCode", StateCode, DbType.String);
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SearchStateNews, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IStateNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new StateNews();

                            if (!objDataReader.IsDBNull(0))
                                objNews.NewsID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objNews.EditorID = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objNews.DisplayOrder = objDataReader.GetInt32(2);

                            if (!objDataReader.IsDBNull(3))
                                objNews.Heading = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objNews.ShortDescription = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objNews.NewsDescription = objDataReader.GetString(5);

                            if (!objDataReader.IsDBNull(6))
                                objNews.LanguageID = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objNews.StateCode = objDataReader.GetString(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.IsApproved = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsActive = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.IsTopNews = objDataReader.GetInt32(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.DttmCreated = objDataReader.GetDateTime(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.DttmModified = objDataReader.GetDateTime(12);

                            objNewsList.Add(objNews); 
                        }

                    }
                    while (objDataReader.NextResult());
                }

                if (!objDataReader.IsClosed)
                    objDataReader.Close();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
                dbHelper.ClearAllParameters();
                dbHelper.CloseConnection();
                dbHelper.Dispose();
            }

            return objNewsList;
        }
        #endregion      

        #region Memory
        private bool disposed = false;
        ~StateNewsDB()
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


