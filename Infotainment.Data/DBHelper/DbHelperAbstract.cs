using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCL.DBHelper;

namespace Infotainment.Data
{
    public class DBInstanceAbstract
    {
        public IDBHelper DBInstance
        {
            get
            {
                return new DBHelper();
            }
        }
    }
}
