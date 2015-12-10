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
    public class InterNewsDB : DBInstanceAbstract, IDisposable
    {
        public static InterNewsDB Instance
        {
            get { return new InterNewsDB(); }
        }

        #region Auto Generated Code - Insert

        public void Insert(ref DBHelper dbInstance, IInterNews objinterNews, IImageDetail objImageDetail, IUsers user)
        {
            try
            {
                dbInstance.ClearAllParameters();
                dbInstance.AddInParameter("@EditorID", objinterNews.EditorID, DbType.String);
                dbInstance.AddInParameter("@DisplayOrder", objinterNews.DisplayOrder, DbType.Int32);
                dbInstance.AddInParameter("@Heading", objinterNews.Heading, DbType.String);
                dbInstance.AddInParameter("@ShortDescription", objinterNews.ShortDescription, DbType.String);
                dbInstance.AddInParameter("@NewsDescription", objinterNews.NewsDescription, DbType.String);
                dbInstance.AddInParameter("@LanguageID", objinterNews.LanguageID, DbType.Int32);
                dbInstance.AddInParameter("@CountryCode", " ", DbType.String);
                dbInstance.AddInParameter("@IsTopNews", objinterNews.IsTopNews, DbType.Int32);
                dbInstance.AddInParameter("@ImageUrl", objImageDetail.ImageUrl, DbType.String);
                dbInstance.AddInParameter("@Caption", objImageDetail.Caption, DbType.String);
                dbInstance.AddInParameter("@ImageType", objImageDetail.ImageType, DbType.Int32);
                dbInstance.AddInParameter("@IsFirst", objImageDetail.IsFirst, DbType.Int32);
                dbInstance.AddInParameter("@UserID", user.UserID, DbType.Int64);

                dbInstance.ExecuteNonQuery(ProcedureName.InsertInterNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Update
        public void GiveApproval(ref DBHelper dbHelper, IInterNews objNews, IUsers user)
        {
            try
            {
                dbHelper.ClearAllParameters();
                dbHelper.AddInParameter("@NewsID", objNews.NewsID, DbType.String);
                dbHelper.AddInParameter("@IsApproved", objNews.IsApproved, DbType.Int32);
                dbHelper.AddInParameter("@UserID", user.UserID, DbType.Int64);
                dbHelper.ExecuteNonQuery(ProcedureName.MakeApprovedInterNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void MakeActive(ref DBHelper dbHelper, IInterNews objNews, IUsers user)
        {
            try
            {
                dbHelper.ClearAllParameters();
                dbHelper.AddInParameter("@NewsID", objNews.NewsID, DbType.String);
                dbHelper.AddInParameter("@IsActive", objNews.IsActive, DbType.Int32);
                dbHelper.AddInParameter("@UserID", user.UserID, DbType.Int64);
                dbHelper.ExecuteNonQuery(ProcedureName.MakeActiveInterNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void Update(ref DBHelper dbHelper, IInterNews news, IImageDetail image, IUsers user)
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
                dbHelper.AddInParameter("@IsActive", news.IsActive, DbType.Int32);
                dbHelper.AddInParameter("@IsApproved", news.IsApproved, DbType.Int32);
                dbHelper.AddInParameter("@IsTopNews", news.IsTopNews, DbType.Int32);
                dbHelper.AddInParameter("@ImageUrl", image.ImageUrl, DbType.String);
                dbHelper.AddInParameter("@Caption", image.Caption, DbType.String);
                dbHelper.AddInParameter("@ImageType", image.ImageType, DbType.Int32);
                dbHelper.AddInParameter("@IsFirst", image.IsFirst, DbType.Int32);
                dbHelper.AddInParameter("@IsActieImage", image.IsActive, DbType.Int32);
                dbHelper.AddInParameter("@UserID", user.UserID, DbType.Int64);

                dbHelper.ExecuteNonQuery(ProcedureName.UpdateIntertNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Delete

        public void Delete(ref DBHelper dbHelper, System.Int64 TopNewsID)
        {
            try
            {
                throw new NotImplementedException();
                //string strQuery = String.Empty;
                //strQuery += "Delete from TopNews where TopNewsID = " + TopNewsID;
                //dbHelper.ExecuteNonQuery(strQuery);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        #endregion

        #region Auto Generated Code - Select
        public IInterNews Select(string NewsID)
        {
            IInterNews objNews = null;
            IDataReader objDataReader = null;
            var dbHelper = DBHelper.Instance;
            try
            {
                dbHelper.AddInParameter("@NewsID", NewsID, DbType.String);
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectInterNews, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    while (objDataReader.Read())
                    {
                        objNews = new InterNews();

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
                            objNews.IsApproved = objDataReader.GetInt32(7);

                        if (!objDataReader.IsDBNull(8))
                            objNews.IsActive = objDataReader.GetInt32(8);

                        if (!objDataReader.IsDBNull(9))
                            objNews.IsTopNews = objDataReader.GetInt32(9);

                        if (!objDataReader.IsDBNull(10))
                            objNews.DttmCreated = objDataReader.GetDateTime(10);

                        if (!objDataReader.IsDBNull(11))
                            objNews.DttmModified = objDataReader.GetDateTime(11);

                        if (!objDataReader.IsDBNull(12))
                            objNews.ImageUrl = objDataReader.GetString(12);

                        if (!objDataReader.IsDBNull(13))
                            objNews.ImageCaption = objDataReader.GetString(13);

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

        public List<IInterNews> SelectAllForList()
        {
            IDataReader objDataReader = null;
            List<IInterNews> objNewsList = null;
            IInterNews objNews = null;

            DBHelper dbHelper = new DBHelper();
            try
            {
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectAllInterForList, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IInterNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new InterNews();

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
                                objNews.IsApproved = objDataReader.GetInt32(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.IsActive = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsTopNews = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.DttmCreated = objDataReader.GetDateTime(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.DttmModified = objDataReader.GetDateTime(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.ImageUrl = objDataReader.GetString(12);

                            if (!objDataReader.IsDBNull(13))
                                objNews.ImageCaption = objDataReader.GetString(13);

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

        public List<IInterNews> SelectToApprove()
        {
            IDataReader objDataReader = null;
            List<IInterNews> objNewsList = null;
            IInterNews objNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectInterNewsToApprove, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IInterNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new InterNews();

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
                                objNews.IsApproved = objDataReader.GetInt32(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.IsActive = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsTopNews = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.DttmCreated = objDataReader.GetDateTime(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.DttmModified = objDataReader.GetDateTime(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.ImageUrl = objDataReader.GetString(12);

                            if (!objDataReader.IsDBNull(13))
                                objNews.ImageCaption = objDataReader.GetString(13);

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

        public List<IInterNews> SelectToActive()
        {
            IDataReader objDataReader = null;
            List<IInterNews> objNewsList = null;
            IInterNews objNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectInterNewsToActive, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IInterNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new InterNews();

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
                                objNews.IsApproved = objDataReader.GetInt32(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.IsActive = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsTopNews = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.DttmCreated = objDataReader.GetDateTime(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.DttmModified = objDataReader.GetDateTime(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.ImageUrl = objDataReader.GetString(12);

                            if (!objDataReader.IsDBNull(13))
                                objNews.ImageCaption = objDataReader.GetString(13);

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

        internal IEnumerable<IInterNews> Select20TopNews()
        {
            IDataReader objDataReader = null;
            List<IInterNews> objNewsList = null;
            IInterNews objNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.Select20InterNews, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IInterNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new InterNews();

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
                                objNews.IsApproved = objDataReader.GetInt32(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.IsActive = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsTopNews = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.DttmCreated = objDataReader.GetDateTime(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.DttmModified = objDataReader.GetDateTime(11);

                            if (!objDataReader.IsDBNull(12))
                                objNews.ImageUrl = objDataReader.GetString(12);

                            if (!objDataReader.IsDBNull(13))
                                objNews.ImageCaption = objDataReader.GetString(13);

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

        public List<IInterNews> Search(DateTime dateFrom, DateTime dateTo, string Heading)
        {
            IDataReader objDataReader = null;
            List<IInterNews> objNewsList = null;
            IInterNews objNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                dbHelper.AddInParameter("@DateFrom", dateFrom.ToString("yyyy-MM-dd"));
                dbHelper.AddInParameter("@DateTo", dateTo.ToString("yyyy-MM-dd"));
                dbHelper.AddInParameter("@Heading", "%" + Heading + "%", DbType.String);
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SearchInterNews, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objNewsList = new List<IInterNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objNews = new InterNews();

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
                                objNews.IsApproved = objDataReader.GetInt32(7);

                            if (!objDataReader.IsDBNull(8))
                                objNews.IsActive = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objNews.IsTopNews = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objNews.DttmCreated = objDataReader.GetDateTime(10);

                            if (!objDataReader.IsDBNull(11))
                                objNews.DttmModified = objDataReader.GetDateTime(11);

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
        ~InterNewsDB()
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


