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
* Developed By: Nov-15-15, Ranjeet
*****************************************************************************/
#endregion

using System;
using System.Data;
using PCL.DBHelper;
using Infotainment.Data.Entities;
using System.Collections.Generic;
using Infotainment.Data.Common;

namespace Infotainment.Data.Controls
{
    public class AdvertismentDB
    {
        public static AdvertismentDB Instance
        {
            get { return new AdvertismentDB(); }
        }

        #region Auto Generated Code - Insert

        public void Insert(ref DBHelper dbInstance, IAdvertisment objAdvertisment)
        {
            try
            {
                dbInstance.AddInParameter("@DisplayOrder", objAdvertisment.DisplayOrder, DbType.Int32);
                dbInstance.AddInParameter("@Heading", objAdvertisment.Heading, DbType.String);
                dbInstance.AddInParameter("@WebUrl", objAdvertisment.WebUrl, DbType.String);
                dbInstance.AddInParameter("@ShortDesc", objAdvertisment.ShortDesc, DbType.String);
                dbInstance.AddInParameter("@ImgUrl", objAdvertisment.ImgUrl, DbType.String);
                dbInstance.AddInParameter("@AdvertismentType", objAdvertisment.AdvertismentType, DbType.Int32);
                dbInstance.AddInParameter("@Position", objAdvertisment.Position, DbType.Int32);

                dbInstance.ExecuteNonQuery(ProcedureName.InsertAdvertisment, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Update

        public void Update(ref DBHelper dbInstance, IAdvertisment objAdvertisment)
        {
            try
            {
                dbInstance.AddInParameter("@AdvertismentID", objAdvertisment.AdvertismentID, DbType.String);
                dbInstance.AddInParameter("@DisplayOrder", objAdvertisment.DisplayOrder, DbType.Int32);
                dbInstance.AddInParameter("@Heading", objAdvertisment.Heading, DbType.String);
                dbInstance.AddInParameter("@WebUrl", objAdvertisment.WebUrl, DbType.String);
                dbInstance.AddInParameter("@ShortDesc", objAdvertisment.ShortDesc, DbType.String);
                dbInstance.AddInParameter("@ImgUrl", objAdvertisment.ImgUrl, DbType.String);
                dbInstance.AddInParameter("@AdvertismentType", objAdvertisment.AdvertismentType, DbType.Int32);
                dbInstance.AddInParameter("@Position", objAdvertisment.Position, DbType.Int32);
                dbInstance.AddInParameter("@IsApproved", objAdvertisment.IsApproved, DbType.Int32);
                dbInstance.AddInParameter("@IsActive", objAdvertisment.IsActive, DbType.Int32);


            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Delete

        public void Delete(ref DBHelper dbInstance, System.String AdvertismentID)
        {
            try
            {
                dbInstance.AddInParameter("@AdvertismentID", AdvertismentID, DbType.String);
                dbInstance.ExecuteNonQuery(ProcedureName.DeleteAdvertisment, CommandType.StoredProcedure);

            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Select

        public List<IAdvertisment> SelectAll(System.Int32 AdvertismentType, System.Int32 IsActive = -1, System.Int32 IsApproved = -1)
        {
            IDataReader objDataReader = null;
            List<IAdvertisment> objAdvertismentList = null;
            IAdvertisment objAdvertisment = null;

            DBHelper dbInstance = DBHelper.Instance;
            try
            {
                dbInstance.AddInParameter("@AddType", AdvertismentType, DbType.Int32);
                dbInstance.AddInParameter("@IsActive", IsActive, DbType.Int32);
                dbInstance.AddInParameter("@IsApproved", IsApproved, DbType.Int32);

                objDataReader = dbInstance.ExecuteDataReader(ProcedureName.SelectAdvertisment, CommandType.StoredProcedure);

                if (objDataReader != null)
                {
                    objAdvertismentList = new List<IAdvertisment>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            objAdvertisment = new Advertisment();

                            if (!objDataReader.IsDBNull(0))
                                objAdvertisment.AdvertismentID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objAdvertisment.DisplayOrder = objDataReader.GetInt32(1);

                            if (!objDataReader.IsDBNull(2))
                                objAdvertisment.Heading = objDataReader.GetString(2);

                            if (!objDataReader.IsDBNull(3))
                                objAdvertisment.WebUrl = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objAdvertisment.ShortDesc = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objAdvertisment.ImgUrl = objDataReader.GetString(5);

                            if (!objDataReader.IsDBNull(6))
                                objAdvertisment.AdvertismentType = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objAdvertisment.Position = objDataReader.GetInt32(7);

                            if (!objDataReader.IsDBNull(8))
                                objAdvertisment.IsApproved = objDataReader.GetInt32(8);

                            if (!objDataReader.IsDBNull(9))
                                objAdvertisment.IsActive = objDataReader.GetInt32(9);

                            if (!objDataReader.IsDBNull(10))
                                objAdvertisment.DttmCreated = objDataReader.GetDateTime(10);

                            if (!objDataReader.IsDBNull(11))
                                objAdvertisment.DttmModified = objDataReader.GetDateTime(11);

                            objAdvertismentList.Add(objAdvertisment);
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
                dbInstance.ClearAllParameters();
                dbInstance.CloseConnection();
                dbInstance.Dispose();
            }

            return objAdvertismentList;

        }
        #endregion

    }
}


