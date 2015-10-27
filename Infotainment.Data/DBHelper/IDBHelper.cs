

namespace PCL.DBHelper
{
    /// <summary>
    /// DBHelper interface  
    /// </summary>
    public interface IDBHelper
    {
        /// <summary>
        /// This function Begins the transaction.
        /// The beginTransaction() method marks the beginning of a new explicit transaction in the current connection.
        /// </summary>
        /// <example >
        /// try
        /// {
        ///     DBHelper objDBHelper =new DBHelper();
        ///     objDBHelper.BeginTransaction(); //// Usage
        ///     try
        ///     {
        ///         DO DB operation.
        ///         objDBHelper .CommitTransaction();
        ///     }
        ///     catch(Exception objEx)
        ///     {
        ///         bjDBHelper.RollbackTransaction();
        ///         throw objEx;
        ///     }
        /// }
        /// catch(Exception objEx)
        /// {
        ///     throw objEx;
        /// }
        /// </example>
        void BeginTransaction();

        /// <summary>
        /// This function Rollbacks the transaction.
        /// This method ends the active transaction by rolling back any changes made to the database associated with the current connection.
        /// </summary>
        /// <example >
        /// try
        /// {
        ///     DBHelper objDBHelper =new DBHelper();
        ///     objDBHelper.BeginTransaction(); 
        ///     try
        ///     {
        ///         DO DB operation.
        ///         objDBHelper .CommitTransaction();
        ///     }
        ///     catch(Exception objEx)
        ///     {
        ///         objDBHelper.RollbackTransaction(); //// Usage
        ///         throw objEx;
        ///     }
        /// }
        /// catch(Exception objEx)
        /// {
        ///     throw objEx;
        /// }
        /// </example>
        void RollbackTransaction();

        /// <summary>
        /// Commits the transaction.
        /// CommitTransaction makes all data modifications performed since the start of the transaction. 
        /// </summary>
        /// <example>
        /// try
        /// {
        ///     DBHelper objDBHelper =new DBHelper();
        ///     objDBHelper.BeginTransaction(); 
        ///     try
        ///     {
        ///         DO DB operation.
        ///         objDBHelper.CommitTransaction();   //// Usage
        ///     }
        ///     catch(Exception objEx)
        ///     {
        ///         objDBHelper.RollbackTransaction(); 
        ///         throw objEx;
        ///     }
        /// }
        /// catch(Exception objEx)
        /// {
        ///     throw objEx;
        /// }
        /// </example>
        void CommitTransaction();

        /// <summary>
        /// Begins the transaction.
        /// The beginTransaction() method marks the beginning of a new explicit transaction in the current connection with IsolationLevel.
        /// </summary>
        /// <param name="isoLevel">The iso level.</param>
        /// <example>
        /// try
        /// {
        ///     DBHelper objDBHelper =new DBHelper();
        ///     objDBHelper.BeginTransaction(IsolationLevel.ReadCommited); //// Usage
        ///     try
        ///     {
        ///         .....DO some DB operation.
        ///         objDBHelper .CommitTransaction();   
        ///     }
        ///     catch(Exception objEx)
        ///     {
        ///         objDBHelper.RollbackTransaction(); 
        ///         throw objEx;
        ///     }
        /// }
        /// catch(Exception objEx)
        /// {
        ///     throw objEx;
        /// }
        /// </example>
        void BeginTransaction(System.Data.IsolationLevel isoLevel);

        /// <summary>
        /// Executes a SQL statement against a connection object.
        /// </summary>
        /// <param name="strQuery">The string Query.</param>
        /// <returns>return number of effeted row </returns>
        /// <example>
        /// try
        /// {
        ///    DBHelper objDBHelper = new DBHelper();
        ///    string  strQuery= "";
        ///    return objDBHElper.ExecuteQuery(sttrQuery);
        /// }
        /// catch(Exception e)
        /// {
        ///   throw e;
        /// }
        /// </example>
        int ExecuteNonQuery(string strQuery);

        /// <summary>
        /// Executes a SQL statement as well as storeprocedure against a connection object.
        /// </summary>
        /// <param name="strQuery">The string Query.</param>
        /// <param name="objCommandType">Type of the CommandType.</param>
        /// <returns>return number of effeted row</returns>
        /// <example>
        /// try
        /// {
        ///    DBHelper objDBHelper = new DBHelper();
        ///    return objDBHElper.ExecuteQuery(spName,CommandType.StoredProcedure);
        /// }
        /// catch(Exception e)
        /// {
        ///    throw e;
        /// }
        /// </example>
        int ExecuteNonQuery(string strQuery, System.Data.CommandType objCommandType);

        /// <summary>
        /// Executes the query and returns the first column of the first row in the result
        /// set returned by the query. All other columns and rows are ignored.
        /// </summary>
        /// <param name="strQuery">The STR query.</param>
        /// <returns>The first column of the first row in the result set.</returns>
        /// <example>
        /// try
        /// {
        ///    DBHelper objDBHelper = new DBHelper();
        ///    string  strQuery= "";
        ///    return objDBHElper.ExecuteScalar(sttrQuery);
        /// }
        /// catch(Exception e)
        /// {
        ///    throw e;
        /// }
        /// </example>
        object ExecuteScalar(string strQuery);

        /// <summary>
        /// Executes the query as well as storeprocedure and returns the first column of the first row in the result.
        /// set returned by the query. All other columns and rows are ignored.
        /// </summary>
        /// <param name="strStoredProcedureName">Name of the STR stored procedure.</param>
        /// <param name="objCommandType">Type of the obj command.</param>
        /// <returns>
        /// The first column of the first row in the result set.
        /// </returns>
        /// <example>
        /// try
        /// {
        ///     DBHelper objDBHelper = new DBHelper();
        ///     return objDBHElper.ExecuteScalar(spName,CommandType.StoredProcedure);
        /// }
        /// catch(Exception e)
        /// {
        ///    throw e;
        /// }
        /// </example>
        object ExecuteScalar(string strStoredProcedureName, System.Data.CommandType objCommandType);

        /// <summary>
        /// Executes the System.Data.Common.DbCommand.CommandText against the System.Data.Common.DbCommand.Connection,
        /// and returns an IDataReader.
        /// </summary>
        /// <param name="strQuery">The STR query.</param>
        /// <param name="objCommandType">Type of the obj command.</param>
        /// <returns>return IDataReader</returns>
        /// <example>
        /// try
        /// {
        ///     DBHelper objDBHelper = new DBHelper();
        ///     try
        ///     {
        ///         IDataReader objReader = objDBHelper.ExecuteDataReader(strProcedureName,CommandType);  
        ///         if(objReader != null)
        ///         {
        ///             while(objReader.Read())
        ///             {
        ///                ...Do Business Process  ...
        ///             }
        ///             objReader.Close();
        ///     }
        ///     catch(Exception objError)
        ///     {
        ///        throw objError;
        ///     }
        /// }
        /// catch(Exception objError)
        /// {
        ///     throw objError;
        /// }
        /// </example> 
        System.Data.IDataReader ExecuteDataReader(string strProcedureName, System.Data.CommandType objCommandType);

        /// <summary>
        /// Executes the System.Data.Common.DbCommand.CommandText against the System.Data.Common.DbCommand.Connection,
        /// and returns an IDataReader.
        /// </summary>
        /// <param name="strQuery">The STR query.</param>
        /// <returns>return IDataReader</returns>
        /// <example>
        /// try
        /// {
        ///    DBHelper objDBHelper = new DBHelper();
        ///    try
        ///    {
        ///      IDataReader objReader = objDBHelper.ExecuteDataReader(strQuery);
        ///      if(objReader != null)
        ///      {
        ///        while(objReader.Read())
        ///        {
        ///          ...Do Business Process  ...
        ///        }
        ///        objReader.Close();
        ///      }
        ///    catch(Exception objError)
        ///    {
        ///       throw objError;
        ///    }
        /// }
        /// catch(Exception objError)
        /// {
        ///    throw objError;
        /// }
        /// </example>
        System.Data.IDataReader ExecuteDataReader(string strQuery);

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// Returns a newly created data set consisting of a data table for each of the ranges specified by reference.
        /// </summary>
        /// <param name="strQuery">The STR query.</param>
        /// <returns>return DataSet</returns>
        /// <example>
        /// try
        /// {
        ///    DBHelper objDBHelper = new DBHelper();
        ///    DataSet dsObj = objDBHelper.ExecuteDataSet(Query);
        ///    return dsObj;
        /// }
        /// catch(Exception e)
        /// {
        ///   tyhrow e;
        /// }
        /// </example>
        System.Data.DataSet ExecuteDataSet(string strQuery);

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// Returns a newly created data set consisting of a data table for each of the ranges specified by reference.
        /// </summary>
        /// <param name="strQuery">The STR query.</param>
        /// <param name="objCommandType">Type of the obj command.</param>
        /// <returns>return DataSet</returns>
        /// <example>
        /// try
        /// {
        ///     DBHelper objDBHelper = new DBHelper();
        ///     DataSet dsObj = objDBHelper.ExecuteDataSet(Query,CommandType,StoreProcedure);
        ///     return dsObj;
        /// }
        /// catch(Exception e)
        /// {
        ///    tyhrow e;
        /// }
        /// </example>
        System.Data.DataSet ExecuteDataSet(string strQuery, System.Data.CommandType objCommandType);

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="strStoredProcedureName">Name of the STR stored procedure.</param>
        /// <param name="objCommandType">Type of the obj command.</param>
        /// <param name="objName">Name of the obj.</param>
        /// <returns></returns>
        System.Data.DataSet ExecuteDataSet(string strStoredProcedureName, System.Data.CommandType objCommandType, ref object objName);

        /// <summary>
        /// Adds a System.Data.Common.DbParameter item with the specified value to the
        /// System.Data.Common.DbParameterCollection.
        /// </summary>
        /// <param name="strParameterName">Name of the parameter.</param>
        /// <param name="objParameterValue">The obj parameter value.</param>
        /// <param name="objDbType">Type of the obj db.</param>
        /// <returns>The index of the System.Data.Common.DbParameter object in the collection.</returns>
        /// /// 
        /// <example>
        /// try
        /// {
        ///    DBHelper objDBHelper = new DBHelper();
        ///    objDBHelper.AddInParameter("@parameterName", objParameterValue,DbType.string);
        /// }
        /// catch(Exception e)
        /// {
        ///    tyhrow e;
        /// }
        /// </example>
        int AddInParameter(string strParameterName, object objParameterValue, System.Data.DbType objDbType);

        /// <summary>
        /// This function Adds the in parameter.
        /// </summary>
        /// <param name="strParameterName">Name of the parameter.</param>
        /// <param name="objParameterValue">The object parameter value.</param>
        /// <returns>The index of the System.Data.Common.DbParameter object in the collection.</returns>
        /// <example>
        /// try
        /// {
        ///     DBHelper objDBHelper = new DBHelper();
        ///     objDBHelper.AddInParameter("@parameterName", objParameterValue);
        /// }
        /// catch(Exception e)
        /// {
        ///     tyhrow e;
        /// }
        /// </example>
        int AddInParameter(string strParameterName, object objParameterValue);

        /// <summary>
        /// This function Adds the out parameter.
        /// </summary>
        /// <param name="strParameterName">Name of the STR parameter.</param>
        /// <param name="objDBType">Type of the obj DB.</param>
        /// <returns>
        /// The index of the System.Data.Common.DbParameter object in the collection.
        /// </returns>
        /// <example>
        /// try
        /// {
        /// DBHelper objDBHelper = new DBHelper();
        /// objDBHelper.AddOutParameter("@parameterName", objParameterValue, DbType.string);
        /// }
        /// catch(Exception e)
        /// {
        /// tyhrow e;
        /// }
        /// </example>
        int AddOutParameter(string strParameterName, System.Data.DbType objDBType);

        /// <summary>
        /// This function Adds the out parameter with parametersize.
        /// </summary>
        /// <param name="strParameterName">Name of the STR parameter.</param>
        /// <param name="objDBType">Type of the obj DB.</param>
        /// <param name="intParameterSize">Size of the int parameter.</param>
        /// <returns>
        /// The index of the System.Data.Common.DbParameter object in the collection.
        /// </returns>
        /// <example>
        /// try
        /// {
        /// DBHelper objDBHelper = new DBHelper();
        /// objDBHelper.AddOutParameter("@parameterName", 500);
        /// }
        /// catch(Exception e)
        /// {
        /// tyhrow e;
        /// }
        /// </example>
        int AddOutParameter(string strParameterName, System.Data.DbType objDBType, int intParameterSize);

        /// <summary>
        /// This function Executes the out parameter value.
        /// </summary>
        /// <param name="strParameterName">Name of parameter.</param>
        /// <returns>returns out parameter value in terms of object.</returns>
        /// <example>
        /// try
        /// {
        ///     DBHelper objDBHelper = new DBHelper();
        ///     ....After excution of Queery or Storeprocedure...
        ///     object obj = objDBHelper.ExecuteOutParameterValue("@ParameterName");
        /// }
        /// catch(Exception e)
        /// {
        ///     tyhrow e;
        /// }
        /// </example>
        object ExecuteOutParameterValue(string strParameterName);

        /// <summary>
        /// Represents a collection of key/value pairs that are organized based on the hash code of the key.
        /// </summary>
        /// <returns>This will return Hashtable</returns>
        /// <example>
        /// try
        /// {
        ///    DBHelper objDBHelper = new DBHelper();
        ///     ....After excution of Queery or Storeprocedure...
        ///     Hastable OutParamterValueHashTable = objDBHelper.ExecuteOutParameterValue();
        /// }
        /// catch(Exception e)
        /// {
        ///     tyhrow e;
        /// }
        /// </example>
        System.Collections.Hashtable ExecuteOutParameterValue();
    }
}
