using Infotainment.Data.Common;
using Infotainment.Data.Entities.Common;
using PCL.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Data.Controls.Common
{
    public class StateCodeBL
    {
        public static StateCodeBL Instance
        {
            get
            {
                return new StateCodeBL();
            }
        }

        public IEnumerable<IStateCode> SelectStates()
        {
            return StateCodeDB.Instance.SelectStates();
        }
    }

    public class StateCodeDB
    {

        public static StateCodeDB Instance
        {
            get
            {
                return new StateCodeDB();
            }
        }
        public IEnumerable<IStateCode> SelectStates()
        {
            IDataReader objDataReader = null;
            List<IStateCode> objImageDetailList = null;
            IStateCode obj = null;

            var dbHelper = DBHelper.Instance;
            try
            {
                objDataReader = dbHelper.ExecuteDataReader("SELECT StateCode, StateName FROM StateCode ORDER BY StateName", CommandType.Text);

                if (objDataReader != null)
                {
                    objImageDetailList = new List<IStateCode>();
                    do
                    {
                        while (objDataReader.Read())
                        {
                            obj = new StateCode();

                            if (!objDataReader.IsDBNull(0))
                                obj.Code = objDataReader.GetString(0);

                            if (!objDataReader.IsDBNull(1))
                                obj.Name = objDataReader.GetString(1);


                            objImageDetailList.Add(obj);
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
    }
}
