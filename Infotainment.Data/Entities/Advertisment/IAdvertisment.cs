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


namespace Infotainment.Data.Entities
{
    public interface IAdvertisment
    {
        System.String AdvertismentID
        {
            get;
            set;
        }

        System.Int32 DisplayOrder
        {
            get;
            set;
        }

        System.String Heading
        {
            get;
            set;
        }

        System.String WebUrl
        {
            get;
            set;
        }

        System.String ShortDesc
        {
            get;
            set;
        }

        System.String ImgUrl
        {
            get;
            set;
        }
        System.Int32 AdvertismentType
        {
            get;
            set;
        }

        System.Int32 Position
        {
            get;
            set;
        }

        System.Int32 IsApproved
        {
            get;
            set;
        }

        System.Int32 IsActive
        {
            get;
            set;
        }

        System.DateTime DttmCreated
        {
            get;
            set;
        }

        System.DateTime DttmModified
        {
            get;
            set;
        }
    }
}


