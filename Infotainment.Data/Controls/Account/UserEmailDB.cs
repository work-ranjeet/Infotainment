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

/// <summary>
/// 
/// </summary>
namespace Infotainment.Data.Controls
{
    public class UserEmailDB : IDisposable
    {
        public UserEmailDB()
        {
        }

        #region Auto Generated Code - Insert
        public void Insert(ref DBHelper dbHelper, UserEmail objUserEmail)
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

        #region Auto Generated Code - Update
        public void Update(ref DBHelper dbHelper, UserEmail objUserEmail)
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

        #region Auto Generated Code - Delete
        public void Delete(ref DBHelper dbHelper, System.String EmailID)
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
        public async Task<IUserEmail> Select(System.Int64 UserID)
        {
            return await Task.Run(() =>
            {
                IDataReader objDataReader = null;
                UserEmail objUserEmail = null;
                try
                {
                    var dbHelper = DBHelper.Instance;
                    dbHelper.AddInParameter("@UserID", UserID, DbType.Int64);
                    objDataReader = dbHelper.ExecuteDataReader(ProcedureName.SelectUserEmail, CommandType.StoredProcedure);
                    if (objDataReader != null)
                    {
                        if (objDataReader.Read())
                        {
                            objUserEmail = new UserEmail();

                            if (!objDataReader.IsDBNull(0))
                                objUserEmail.EmailID = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                objUserEmail.UserID = objDataReader.GetInt64(1);

                            if (!objDataReader.IsDBNull(2))
                                objUserEmail.Email = objDataReader.GetString(2);

                            if (!objDataReader.IsDBNull(3))
                                objUserEmail.IsActive = objDataReader.GetInt32(3);

                            if (!objDataReader.IsDBNull(4))
                                objUserEmail.IsVerified = objDataReader.GetInt32(4);

                            if (!objDataReader.IsDBNull(5))
                                objUserEmail.IsVerCodeSent = objDataReader.GetInt32(5);

                            if (!objDataReader.IsDBNull(6))
                                objUserEmail.VerificationCode = objDataReader.GetString(6);

                            if (!objDataReader.IsDBNull(7))
                                objUserEmail.DttmCreated = objDataReader.GetDateTime(7);

                            if (!objDataReader.IsDBNull(8))
                                objUserEmail.DttmModified = objDataReader.GetDateTime(8);

                        }
                    }
                    if (!objDataReader.IsClosed)
                        objDataReader.Close();
                }
                catch (Exception objExp)
                {
                    throw objExp;
                }

                return objUserEmail;
            });
        }
        #endregion

        #region Memory
        private bool disposed = false;
        ~UserEmailDB()
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


