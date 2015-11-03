using Infotainment.Data.Common;
using PCL.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Data.Controls
{
    public class ImageDetailDb
    {
        public static ImageDetailDb Instance
        {
            get { return new ImageDetailDb(); }
        }

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
                objDataReader = dbHelper.ExecuteDataReader(ProcedureName.UpdateTopNewsImageDetail, CommandType.StoredProcedure);

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
    }
}
