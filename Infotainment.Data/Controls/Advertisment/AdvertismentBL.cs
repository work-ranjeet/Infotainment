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
    public class AdvertismentBL 
    {
        public static AdvertismentBL Instance
        {
            get { return new AdvertismentBL(); }
        }

        #region Auto Generated Code - Update

        public void Update(Advertisment objAdvertisment)
        {
            try
            {

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

        public List<IAdvertisment> SelectAll(AdvertismentType addType)
        {
            var result = new List<IAdvertisment>();

            result = AdvertismentDB.Instance.SelectAll((int)addType);

            return result;
        }
        #endregion

    }
}


