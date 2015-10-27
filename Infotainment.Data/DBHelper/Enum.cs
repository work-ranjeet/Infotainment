using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PCL.DBHelper;

namespace PCL.DBHelper
{
    /// <summary>
    /// DBName is an enumerated type
    /// </summary>
    public enum DBName
    {
        /// <summary>
        /// For MicroSoft SQL
        /// </summary>
        MSSQL,

        /// <summary>
        /// For Oracle DataBase
        /// </summary>
        Oracle,

        /// <summary>
        /// For Open dataBase connectivity
        /// </summary>
        ODBC,

        /// <summary>
        /// For Object Linking and Embedding, Database
        /// </summary>
        Oledb,

        /// <summary>
        /// For MySql DataBase
        /// </summary>
        MySql
    }
}
