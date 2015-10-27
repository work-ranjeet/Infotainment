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

namespace Infotainment.Data.Controls
{
    public class TopNewsBL //: ITopNews
    {
        #region Auto Generated Code - Insert

        public void Insert(ITopNews objTopNews, IImageDetail objImageDetail)
        {
            try
            {
                var objdbhelper = new DBHelper();
                var objTopNewsDB = new TopNewsDB();
                objTopNews.EditorID = "1";
                objTopNews.DisplayOrder = 1;
                objTopNews.IsActive = 0;
                objTopNews.IsApproved = 0;
                objTopNews.LanguageID = 1;

                objImageDetail.IsActive = 0;
                objImageDetail.IsNewsImage = 1;


                objTopNewsDB.Insert(ref objdbhelper, objTopNews, objImageDetail);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
        }
        #endregion

        //#region Auto Generated Code - Update

        //public void Update(ITopNews objTopNews)
        //{
        //    try
        //    {
        //        DBHelper objdbhelper = new DBHelper();

        //        TopNewsDB objTopNewsDB = new TopNewsDB();

        //        try
        //        {
        //            objTopNewsDB.Update(ref objdbhelper, objTopNews);
        //        }
        //        catch (Exception objExp)
        //        {
        //            throw objExp;
        //        }
        //    }
        //    catch (Exception objExp)
        //    {
        //        throw objExp;
        //    }
        //    finally
        //    {
        //    }
        //}
        //#endregion

        //#region Auto Generated Code - Delete

        //public void Delete(System.Int64 TopNewsID)
        //{
        //    DBHelper objdbhelper = new DBHelper();

        //    TopNewsDB objTopNewsDB = new TopNewsDB();

        //    try
        //    {
        //        objTopNewsDB.Delete(ref objdbhelper, TopNewsID);

        //    }
        //    catch (Exception objExp)
        //    {
        //        throw objExp;
        //    }

        //}
        //#endregion

        #region Auto Generated Code - Select

        public IEnumerable<ITopNews> SelectAll(DateTime dateFrom, DateTime dateTo, int IsActive, int IsApproved, string Heading)
        {
            //DateTime dateFrom, DateTime dateTo, int IsActive = 0, int IsApproved = 0, string Heading = null
            IEnumerable<ITopNews> list = null;
            try
            {
                var objTopNewsDB = new TopNewsDB();
                list = objTopNewsDB.SelectAll(dateFrom, dateTo, IsActive, IsApproved, Heading);
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list;
        }

        public IEnumerable<ITopNews> SelectTopeNewsForApproval()
        {
            IEnumerable<ITopNews> list = null;
            try
            {
                var objTopNewsDB = new TopNewsDB();
                list = objTopNewsDB.SelectAllTopNews();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().FindAll(v => v.IsApproved == 0).OrderBy(v => v.DttmModified);
        }

        public IEnumerable<ITopNews> SelectTopeNewsForActivate()
        {
            IEnumerable<ITopNews> list = null;
            try
            {
                var objTopNewsDB = new TopNewsDB();
                list = objTopNewsDB.SelectAllTopNews();
            }
            catch (Exception objExp)
            {
                throw objExp;
            }
            return list.ToList().FindAll(v => v.IsActive == 0).OrderBy(v => v.DttmModified);
        }
        #endregion

    }
}


