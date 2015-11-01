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

namespace Infotainment.Data.Controls
{
    public class TopNewsDB : DBInstanceAbstract, IDisposable
    {
        public static TopNewsDB Instance
        {
            get { return new TopNewsDB(); }
        }

        #region Auto Generated Code - Insert

        public void Insert(ref DBHelper dbInstance, ITopNews objTopNews, IImageDetail objImageDetail)
        {
            try
            {
                dbInstance.AddInParameter("@EditorID", objTopNews.EditorID, DbType.String);
                dbInstance.AddInParameter("@DisplayOrder", objTopNews.DisplayOrder, DbType.Int32);
                dbInstance.AddInParameter("@Heading", objTopNews.Heading, DbType.String);
                dbInstance.AddInParameter("@ShortDescription", objTopNews.ShortDescription, DbType.String);
                dbInstance.AddInParameter("@NewsDescription", objTopNews.ShortDescription, DbType.String);
                dbInstance.AddInParameter("@LanguageID", objTopNews.LanguageID, DbType.Int32);
                dbInstance.AddInParameter("@ImageUrl", objImageDetail.ImageUrl, DbType.String);
                dbInstance.AddInParameter("@ImageType", objImageDetail.ImageType, DbType.Int32);
                dbInstance.AddInParameter("@IsNewsImage", objImageDetail.IsNewsImage, DbType.Int32);

                dbInstance.ExecuteNonQuery(ProcedureName.InsertLatestNews, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Update
        public void GiveApproval(ref DBHelper dbHelper, ITopNews objTopNews)
        {
            try
            {
                dbHelper.ExecuteNonQuery("Update TopNews set IsApproved= " + objTopNews.IsApproved + " where TopNewsID = '" + objTopNews.TopNewsID + "'");
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void MakeActive(ref DBHelper dbHelper, ITopNews objTopNews)
        {
            try
            {
                dbHelper.ExecuteNonQuery("Update TopNews set IsActive= " + objTopNews.IsActive + " where TopNewsID = '" + objTopNews.TopNewsID + "'");
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }

        public void Update(ref DBHelper dbHelper, TopNews objTopNews)
        {
            try
            {
                string strQuery = String.Empty;
                strQuery += "Update TopNews set TopNewsID= " + objTopNews.TopNewsID + ", DisplayOrder= " + objTopNews.DisplayOrder + ", Heading= '";
                strQuery += objTopNews.Heading + "', ShortDescription= '" + objTopNews.ShortDescription + "', NewsDescription= '" + objTopNews.NewsDescription + "', ";
                strQuery += "LanguageID= " + objTopNews.LanguageID + ", IsActive= " + objTopNews.IsActive + ", ";
                strQuery += "DttmModified= '" + objTopNews.DttmModified + "',  where TopNewsID = " + objTopNews.TopNewsID;

                dbHelper.ExecuteNonQuery(strQuery);
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
                string strQuery = String.Empty;
                strQuery += "Delete from TopNews where TopNewsID = " + TopNewsID;
                dbHelper.ExecuteNonQuery(strQuery);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Select
        public ITopNews Select()
        {
            ITopNews objTopNews = null;
            IDataReader objDataReader = null;
            var dbHelper = DBHelper.Instance;
            try
            {
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectAllTopNews, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    while (objDataReader.Read())
                    {
                        objTopNews = new TopNews();

                        if (!objDataReader.IsDBNull(0))
                            objTopNews.TopNewsID = objDataReader.GetString(0);

                        if (!objDataReader.IsDBNull(1))
                            objTopNews.EditorID = objDataReader.GetString(1);

                        if (!objDataReader.IsDBNull(2))
                            objTopNews.DisplayOrder = objDataReader.GetInt32(2);

                        if (!objDataReader.IsDBNull(3))
                            objTopNews.Heading = objDataReader.GetString(3);

                        if (!objDataReader.IsDBNull(4))
                            objTopNews.ShortDescription = objDataReader.GetString(4);

                        if (!objDataReader.IsDBNull(5))
                            objTopNews.NewsDescription = objDataReader.GetString(5);

                        if (!objDataReader.IsDBNull(6))
                            objTopNews.LanguageID = objDataReader.GetInt32(6);
                        
                        if (!objDataReader.IsDBNull(7))
                            objTopNews.IsApproved = objDataReader.GetInt32(7);

                        if (!objDataReader.IsDBNull(8))
                            objTopNews.IsActive = objDataReader.GetInt32(8);

                        if (!objDataReader.IsDBNull(9))
                            objTopNews.DttmCreated = objDataReader.GetDateTime(9);

                        if (!objDataReader.IsDBNull(10))
                            objTopNews.DttmModified = objDataReader.GetDateTime(10);

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

            return objTopNews;
        }

        public List<ITopNews> SelectAllTopNews()
        {
            IDataReader objDataReader = null;
            List<ITopNews> objTopNewsList = null;
            ITopNews objTopNews = null;

            DBHelper dbHelper = new DBHelper();
            try
            {
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectAllTopNews, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objTopNewsList = new List<ITopNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objTopNews = new TopNews();

                            if (!objDataReader.IsDBNull(0))
                                objTopNews.TopNewsID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objTopNews.EditorID = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objTopNews.DisplayOrder = objDataReader.GetInt32(2);

                            if (!objDataReader.IsDBNull(3))
                                objTopNews.Heading = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objTopNews.ShortDescription = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objTopNews.NewsDescription = objDataReader.GetString(5);

                            if (!objDataReader.IsDBNull(6))
                                objTopNews.LanguageID = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objTopNews.IsApproved = objDataReader.GetInt32(7);

                            if (!objDataReader.IsDBNull(8))
                                objTopNews.IsActive = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objTopNews.DttmCreated = objDataReader.GetDateTime(9);

                            if (!objDataReader.IsDBNull(10))
                                objTopNews.DttmModified = objDataReader.GetDateTime(10);

                            objTopNewsList.Add(objTopNews);
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

            return objTopNewsList;
        }

        public List<ITopNews> Search(DateTime dateFrom, DateTime dateTo, string Heading)
        {
            IDataReader objDataReader = null;
            List<ITopNews> objTopNewsList = null;
            ITopNews objTopNews = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                dbHelper.AddInParameter("@DateFrom", dateFrom, DbType.DateTime);
                dbHelper.AddInParameter("@DateTo", dateTo, DbType.DateTime);
                dbHelper.AddInParameter("@Heading", "%" + Heading + "%", DbType.String);
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SearchNews, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objTopNewsList = new List<ITopNews>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objTopNews = new TopNews();

                            if (!objDataReader.IsDBNull(0))
                                objTopNews.TopNewsID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objTopNews.EditorID = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objTopNews.DisplayOrder = objDataReader.GetInt32(2);

                            if (!objDataReader.IsDBNull(3))
                                objTopNews.Heading = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objTopNews.ShortDescription = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objTopNews.NewsDescription = objDataReader.GetString(5);

                            if (!objDataReader.IsDBNull(6))
                                objTopNews.LanguageID = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objTopNews.IsApproved = objDataReader.GetInt32(7);

                            if (!objDataReader.IsDBNull(8))
                                objTopNews.IsActive = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objTopNews.DttmCreated = objDataReader.GetDateTime(9);

                            if (!objDataReader.IsDBNull(10))
                                objTopNews.DttmModified = objDataReader.GetDateTime(10);

                            objTopNewsList.Add(objTopNews);
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

            return objTopNewsList;
        }
        #endregion

        #region SetectImage Details
        public IEnumerable<IImageDetail> SelectImageList(string NewsID)
        {
            IDataReader objDataReader = null;
            List<IImageDetail> objImageDetailList = null;
            IImageDetail objImageDetail = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                dbHelper.AddInParameter("@NewsID", NewsID, DbType.String);
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectTopNewsForUpdate, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objImageDetailList = new List<IImageDetail>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objImageDetail = new ImageDetail();

                            if (!objDataReader.IsDBNull(0))
                                objImageDetail.ImageID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objImageDetail.ImageUrl = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objImageDetail.ImageType = objDataReader.GetInt32(2);

                            if (!objDataReader.IsDBNull(3))
                                objImageDetail.IsFirst = objDataReader.GetInt32(3);

                            if (!objDataReader.IsDBNull(4))
                                objImageDetail.IsActive = objDataReader.GetInt32(4);

                            if (!objDataReader.IsDBNull(5))
                                objImageDetail.DttmCreated = objDataReader.GetDateTime(5);

                            if (!objDataReader.IsDBNull(6))
                                objImageDetail.DttmModified = objDataReader.GetDateTime(6);


                            objImageDetailList.Add(objImageDetail);
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

            return objImageDetailList;
        }
        #endregion

        #region Memory
        private bool disposed = false;
        ~TopNewsDB()
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


