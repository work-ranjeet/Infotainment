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

using Infotainment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using PCL.DBHelper;


namespace Infotainment.Data.Controls
{
    public class AdvertismentBL : IDisposable
    {
        public static AdvertismentBL Instance
        {
            get { return new AdvertismentBL(); }
        }

        #region Auto Generated Code - Update

        public void Update( ref DBHelper dbInstance,  IAdvertisment Advertisment)
        {
            try
            {
                AdvertismentDB.Instance.Update(ref dbInstance, Advertisment);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            finally
            {
            }
        }
        #endregion

        #region Auto Generated Code - Delete

        public void Delete(System.String AdvertismentID)
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
        public IAdvertisment Select(string AdvertismentId)
        {

            IAdvertisment result = AdvertismentDB.Instance.Select(AdvertismentId);

            return result;
        }
        public List<IAdvertisment> SelectAll(AdvertismentType addType)
        {
            var result = new List<IAdvertisment>();

            result = AdvertismentDB.Instance.SelectAll((int)addType);

            return result;
        }

        public IEnumerable<IAdvertisment> SelectActive(AdvertismentType addType)
        {
            var result = AdvertismentDB.Instance.SelectAll((int)addType);

            return result.FindAll(v => v.IsActive == 1 && v.IsApproved == 1);
        }
        #endregion

        #region Memory
        private bool disposed = false;
        ~AdvertismentBL()
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


