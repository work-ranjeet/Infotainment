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
* Developed By: Oct-14-15, Ranjeet
*****************************************************************************/
#endregion

using System;
using System.Data;
using PCL.DBHelper;
using Infotainment.Data.Common;
using Infotainment.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infotainment.Data.Controls
{
    public class UsersDB : IDisposable
    {
        public static UsersDB Instance
        {
            get { return new UsersDB(); }
        }
        public UsersDB()
        {
        }

        #region Auto Generated Code - Insert

        public void InsertLoginDetail(Int64 UserID)
        {
            try
            {
                var dbInstance = DBHelper.Instance;
                dbInstance.AddInParameter("@UserID", UserID, DbType.Int64);

                dbInstance.ExecuteNonQuery(ProcedureName.InsertUserLoginDetails, CommandType.StoredProcedure);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Update

        public void UpdateLoginDetail(Int64 UserID)
        {
            try
            {
                try
                {
                    var dbInstance = DBHelper.Instance;
                    dbInstance.AddInParameter("@UserID", UserID, DbType.Int64);

                    dbInstance.ExecuteNonQuery(ProcedureName.UpdateLogOut, CommandType.StoredProcedure);
                }
                catch (Exception objExp)
                {
                    throw objExp;
                }
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Delete

        public void Delete(ref DBHelper dbHelper, System.Int64 UserID)
        {
            try
            {

            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        #region Auto Generated Code - Select

        public async Task<IUsers> Select(string Email)
        {
            return await Task.Run(() =>
            {
                IDataReader objDataReader = null;
                Users objUsers = null;
                try
                {
                    var dbHelper = DBHelper.Instance;
                    dbHelper.AddInParameter("@EmailID", Email, DbType.String);
                    objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectUser, CommandType.StoredProcedure);
                    if (objDataReader != null)
                    {
                        if (objDataReader.Read())
                        {
                            objUsers = new Users();

                            if (!objDataReader.IsDBNull(0))
                                objUsers.UserID = objDataReader.GetInt64(0);

                            if (!objDataReader.IsDBNull(1))
                                objUsers.FName = objDataReader.GetString(1);

                            if (!objDataReader.IsDBNull(2))
                                objUsers.MName = objDataReader.GetString(2);

                            if (!objDataReader.IsDBNull(3))
                                objUsers.LName = objDataReader.GetString(3);

                            if (!objDataReader.IsDBNull(4))
                                objUsers.Gender = objDataReader.GetString(4);

                            if (!objDataReader.IsDBNull(5))
                                objUsers.Dob = objDataReader.GetDateTime(5);

                            if (!objDataReader.IsDBNull(6))
                                objUsers.Age = objDataReader.GetInt32(6);

                            if (!objDataReader.IsDBNull(7))
                                objUsers.MariedSatus = objDataReader.GetInt16(7);

                            if (!objDataReader.IsDBNull(8))
                                objUsers.IsActive = objDataReader.GetInt16(8);

                            if (!objDataReader.IsDBNull(9))
                                objUsers.IsNew = objDataReader.GetInt16(9);

                            if (!objDataReader.IsDBNull(10))
                                objUsers.EmailID = objDataReader.GetString(10);

                            if (!objDataReader.IsDBNull(11))
                                objUsers.Email = objDataReader.GetString(11);

                            if (!objDataReader.IsDBNull(12))
                                objUsers.AddressID = objDataReader.GetString(12);

                            if (!objDataReader.IsDBNull(13))
                                objUsers.MobileNo = objDataReader.GetString(13);

                            if (!objDataReader.IsDBNull(14))
                                objUsers.Password = objDataReader.GetString(14);

                            if (!objDataReader.IsDBNull(15))
                                objUsers.DttmCreated = objDataReader.GetDateTime(15);

                            if (!objDataReader.IsDBNull(16))
                                objUsers.DttmModified = objDataReader.GetDateTime(16);

                        }
                    }
                    if (!objDataReader.IsClosed)
                        objDataReader.Close();
                }
                catch (Exception objExp)
                {
                    throw objExp;
                }

                return objUsers;
            });
        }        

        public async Task<IEnumerable<UserGroup>> SelectUserGroup(Int64 UserID)
        {
            return await Task.Run(() =>
            {
                IDataReader objDataReader = null;
                List<UserGroup> objUserGroupList = null;
                UserGroup objUserGroup = null;

                var dbHelper = DBHelper.Instance;
                try
                {
                    dbHelper.AddInParameter("@UserID", UserID, DbType.Int64);
                    objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectUserGroup, CommandType.StoredProcedure);

                    if (objDataReader != null)
                    {
                        objUserGroupList = new List<UserGroup>();
                        do
                        {
                            while (objDataReader.Read())
                            {
                                objUserGroup = new UserGroup();

                                if (!objDataReader.IsDBNull(0))
                                    objUserGroup.GroupID = objDataReader.GetInt32(0);

                                if (!objDataReader.IsDBNull(1))
                                    objUserGroup.GroupType = objDataReader.GetString(1);

                                if (!objDataReader.IsDBNull(2))
                                    objUserGroup.GroupDetails = objDataReader.GetString(2);

                                if (!objDataReader.IsDBNull(3))
                                    objUserGroup.IsActive = objDataReader.GetInt16(3);

                                if (!objDataReader.IsDBNull(4))
                                    objUserGroup.DttmCreate = objDataReader.GetDateTime(4);

                                if (!objDataReader.IsDBNull(5))
                                    objUserGroup.DttmModified = objDataReader.GetDateTime(5);


                                objUserGroupList.Add(objUserGroup);
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

                return objUserGroupList;
            });
        }
        #endregion

        #region Memory
        private bool disposed = false;
        ~UsersDB()
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


