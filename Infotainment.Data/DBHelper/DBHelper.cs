

namespace PCL.DBHelper
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// Public DBHelper Class that inherits IDBHelper interface.
    /// </summary>
    /// <remarks></remarks>
    public class DBHelper : IDBHelper
    {
        #region /// Object declaration

        /// <summary>
        /// Declaration of DataSet
        /// </summary>
        private DataSet objResultDataSet = null;

        /// <summary>
        /// It is  common interface of factory pattren 
        /// </summary>
        private DbDataAdapter objDbDataAdapter;

        /// <summary>
        /// Declaration of DbConnection
        /// </summary>
        private DbConnection objDBConnection;

        /// <summary>
        /// Declaration of DbCommand
        /// </summary>
        private DbCommand objDBCommand;

        /// <summary>
        /// Declaration of DbProviderFactory
        /// </summary>
        private DbProviderFactory objDBProviderFactory = null;

        /// <summary>
        /// Declaration of DbParameterCollection
        /// </summary>
        private DbParameterCollection objDbParameterCollection;

        /// <summary>
        /// It will store Output Parameter.
        /// </summary>
        private Hashtable objDbOutParameterHashtable = null;
        #endregion

        #region Properties

        public static DBHelper Instance
        {
            get { return new DBHelper(); }
        }       

        public static DBHelper InstanceInitialiger(string ConnectionStringName)
        {           
            return new DBHelper(ConnectionStringName);
        }

        public DbConnection Connection
        {
            get
            {
                return this.objDBConnection;
            }
        }

        #endregion

        #region ///Constructor

        /// <summary>
        /// Initializes a new instance of the DBHelper class. It Executes the instance of the class.
        /// It Executes the ProviderName from the config file and Creats a copy instance.
        /// </summary>
        public DBHelper()
        {
            Initialiger();
        }

        public DBHelper(string ConnectionStringName)
        {
            Initialiger(ConnectionStringName);
        }
        #endregion


        #region ///IUtilities Members       

        private void Initialiger(string ConnectionStringName = "ConnectionString")
        {
            try
            {
                ////Executeting an instance of  DBProviderSingleton Class
                DBProviderSingleton objDBProviderSingleton = DBProviderSingleton.Instance(ConnectionStringName);

                string strProviderName = objDBProviderSingleton.ProviderName.Trim(); ////Assining ProviderName
                if (!string.IsNullOrEmpty(strProviderName))
                {
                    switch (strProviderName.Trim())
                    {
                        case "System.Data.SqlClient":
                            this.objDBProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");   ////Creating an instance of SQL
                            break;

                        case "System.Data.OleDb":
                            this.objDBProviderFactory = DbProviderFactories.GetFactory("System.Data.OleDb");   ////Creating an instance of OleDb
                            break;

                        case "System.Data.Odbc":
                            this.objDBProviderFactory = DbProviderFactories.GetFactory("System.Data.Odbc");    ////Creating an instance of Odbc
                            break;

                        case "System.Data.OracleClient":
                            this.objDBProviderFactory = DbProviderFactories.GetFactory("System.Data.OracleClient");     ////Creating an instance of Oracle
                            break;

                        default:
                            this.objDBProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");   ////Creating an instance of SQL
                            break;
                    }
                }

                this.objDBConnection = this.objDBProviderFactory.CreateConnection();   ////It returns connection from DbProviderFactory.
                this.objDBCommand = this.objDBProviderFactory.CreateCommand();        ////Creating an instance from DbProviderFactory.
                this.objDBConnection.ConnectionString = objDBProviderSingleton.ConnectionString.Trim(); ////Assining Connection String
                this.objDBCommand.Connection = this.objDBConnection;
            }
            catch (Exception objEx)
            {
                throw new Exception("Error on initializing connection.", objEx);
            }
        }

        #region ///DataSet

        /// <summary>
        /// This function Executes the data set from the database after executing the Query.
        /// </summary>
        /// <param name="strQuery">The  query.</param>
        /// <returns>Return Dataset</returns>
        /// <example>
        public DataSet ExecuteDataSet(string strQuery)
        {
            try
            {
                return this.ExecuteDataSet(strQuery, CommandType.Text);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// It performs the DB operation and fetches the data from the database with the help of DataSet.
        /// </summary>
        /// <param name="strStoredProcedureName">Name of the stored procedure.</param>
        /// <param name="objCommandType">Type of the CommandType.</param>
        /// <returns>Return DataSet</returns>
        public DataSet ExecuteDataSet(string strStoredProcedureName, CommandType objCommandType)
        {
            try
            {
                this.OpenConnection();
                this.objDbDataAdapter = this.objDBProviderFactory.CreateDataAdapter();    //// Creating data adapter.  
                this.objDBCommand.CommandText = strStoredProcedureName;          //// It may be an query and SP name 
                this.objDBCommand.CommandType = objCommandType;    //// Type of command 
                this.objDbDataAdapter.SelectCommand = this.objDBCommand;  //// Going to selete data from database

                this.objResultDataSet = new DataSet();
                this.objDbDataAdapter.Fill(this.objResultDataSet);

                return this.objResultDataSet;
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while performing ExecuteDataSet on " + strStoredProcedureName, objEx); 
            }
            finally
            {
                this.objDbParameterCollection = this.objDBCommand.Parameters;
                this.CloseConnection();
            }
        }

        /// <summary>
        /// It performs the DB operation and fetches the data from the database with the help of DataSet and
        /// assign first outparameter value in objName.
        /// <param name="strStoredProcedureName">Name of the stored procedure.</param>
        /// <param name="objCommandType">Type of the CommandType.</param>
        /// <param name="ref of an object">Name of the obj.</param>
        /// <returns>Return DataSet</returns>
        public DataSet ExecuteDataSet(string strStoredProcedureName, CommandType objCommandType, ref object objName)
        {
            try
            {
                this.objResultDataSet = this.ExecuteDataSet(strStoredProcedureName, objCommandType);
                foreach (DbParameter dbpDBParameter in this.objDbParameterCollection)
                {
                    if (dbpDBParameter.Value != null && dbpDBParameter.Direction == ParameterDirection.Output)
                    {
                        objName = (object)dbpDBParameter.Value;
                        break;
                    }
                }

                return this.objResultDataSet;
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while performing ExecuteDataSet on " + strStoredProcedureName, objEx); 
            }
        }
        #endregion

        #region ///IDataReader
        /// <summary>
        /// Executes the DataReader.  
        /// </summary>
        /// <param name="strQuery">The query.</param>
        /// <returns>Return IDataReader</returns>
        public IDataReader ExecuteDataReader(string strQuery)
        {
            try
            {
                return this.ExecuteDataReader(strQuery, CommandType.Text);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// It executes the Query/Stored Procedure and Executes the data from the database to data reader.
        /// </summary>
        /// <param name="strStoredProcedureName">Name of the STR stored procedure.</param>
        /// <param name="objCommandType">Type of the obj command.</param>
        /// <returns>Return IDataReader</returns>
        public IDataReader ExecuteDataReader(string strStoredProcedureName, CommandType objCommandType)
        {
            try
            {
                this.OpenConnection();
                this.objDBCommand.CommandType = objCommandType;    ////Type of command 
                this.objDBCommand.CommandText = strStoredProcedureName;  ////It may be an query and SP name 

                return this.objDBCommand.ExecuteReader();
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while performing ExecuteDataReader operation on " + strStoredProcedureName, objEx);
            }
            finally
            {
                this.objDbParameterCollection = this.objDBCommand.Parameters;
            }
        }
        #endregion

        #region ///ExecuteScalar
        /// <summary>
        /// This function Executes the query and returns the first column of the first row in the result
        /// </summary>
        /// <param name="strQuery">The STR query.</param>
        /// <returns>Return object</returns>
        public object ExecuteScalar(string strQuery)
        {
            try
            {
                return this.ExecuteScalar(strQuery, CommandType.Text);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Executes the query as well as storeprocedure and returns the first column of the first row in the result.
        /// All other columns and rows are ignored.
        /// </summary>
        /// <param name="strStoredProcedureName">Name of the STR stored procedure.</param>
        /// <param name="objCommandType">Type of the obj command.</param>
        /// <returns>Return object</returns>
        public object ExecuteScalar(string strStoredProcedureName, CommandType objCommandType)
        {
            object objReturnValue = null;

            try
            {
                this.OpenConnection();
                this.objDBCommand.CommandText = strStoredProcedureName;
                this.objDBCommand.CommandType = objCommandType;
                objReturnValue = this.objDBCommand.ExecuteScalar();

                return objReturnValue;
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            finally
            {
                this.objDbParameterCollection = this.objDBCommand.Parameters;
                this.CloseConnection();
            }
        }
        #endregion

        #region ///ExecuteNonQuery

        /// <summary>
        /// It executes statements but it will return a value specifing how many rows affected by the Command.
        /// </summary>
        /// <param name="strQuery">The query.</param>
        /// <returns>Return int</returns>
        public int ExecuteNonQuery(string strQuery)
        {
            try
            {
                return this.ExecuteNonQuery(strQuery, CommandType.Text);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Executes the StoredProcedure and returns the number of eaffected row..
        /// </summary>
        /// <param name="strStoredProcedureName">Name of the STR stored procedure.</param>
        /// <param name="objCommandType">Type of the obj command.</param>
        /// <returns>return number of effeted row</returns>
        public int ExecuteNonQuery(string strStoredProcedureName, CommandType objCommandType)
        {
            try
            {
                this.OpenConnection();
                this.objDBCommand.CommandText = strStoredProcedureName;
                this.objDBCommand.CommandType = objCommandType;

                return this.objDBCommand.ExecuteNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while performing ExcuteQuery operation on " + strStoredProcedureName, objEx);
            }
            finally
            {
                this.objDbParameterCollection = this.objDBCommand.Parameters;
                this.CloseConnection();
            }
        }

        #endregion

        #region ///Transaction

        /// <summary>
        /// Begin a transaction using the BeginTransaction method in current connection object.
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                this.OpenConnection();
                this.objDBCommand.Transaction = this.objDBConnection.BeginTransaction();
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while initializing Transaction ", objEx);
            }
        }

        /// <summary>
        /// Begins the transaction.
        /// The beginTransaction() method marks the beginning of a new explicit transaction in the current connection with IsolationLevel.
        /// </summary>
        /// <param name="isoLevel">The iso level.</param>
        public void BeginTransaction(IsolationLevel isoLevel)
        {
            try
            {
                this.OpenConnection();
                this.objDBCommand.Transaction = this.objDBConnection.BeginTransaction(isoLevel);
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while initializing Transaction ", objEx);
            }
        }

        /// <summary>
        /// This function is committs the transaction and saves the data permanently into database
        /// on the successfull completion of all the transactions.
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                if (this.objDBCommand.Transaction != null)
                {
                    this.objDBCommand.Transaction.Commit();
                }

                if (this.objDBConnection.State == System.Data.ConnectionState.Open)
                {
                    this.objDBConnection.Close();
                }
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while initializing Transaction ", objEx);
            }
        }

        /// <summary>
        /// This method ends the active transaction by rolling back any changes made to the database associated with the current connection.
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                this.objDBCommand.Transaction.Rollback();

                if (this.objDBConnection.State == System.Data.ConnectionState.Open)
                {
                    this.objDBConnection.Close();
                }
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while performing RollbackTransaction operation. ", objEx);
            }
        }

        #endregion

        #region ///Parameter

        /// <summary>
        /// Using this function we can add input parameter.
        /// </summary>
        /// <param name="strParameterName">Name of the parameter.</param>
        /// <param name="objParameterValue">The parameter value.</param>
        /// <returns>Return The index of the DbParameter object in the collection.</returns>
        public int AddInParameter(string strParameterName, object objParameterValue)
        {
            try
            {
                 return this.AddInParameter(strParameterName, objParameterValue, DbType.String);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Using this function we can add input parameter.
        /// In this function we are creating a parameter and adding it in the command.
        /// </summary>
        /// <param name="strParameterName">Name of the STR parameter.</param>
        /// <param name="objParameterValue">The obj parameter value.</param>
        /// <param name="objDbType">Type of the obj db.</param>
        /// <returns>Return The index of the DbParameter object in the collection.</returns>
        public int AddInParameter(string strParameterName, object objParameterValue, DbType objDbType)
        {
            try
            {
                if (objDbType == DbType.DateTime)
                {
                    objDbType = DbType.String;
                    objParameterValue = (object)Convert.ToDateTime(objParameterValue).ToShortDateString();
                }

                DbParameter dbpDbParameter = this.objDBProviderFactory.CreateParameter();
                dbpDbParameter.Direction = ParameterDirection.Input;
                dbpDbParameter.ParameterName = strParameterName.Trim();
                dbpDbParameter.DbType = objDbType;
                dbpDbParameter.Value = objParameterValue;

                return this.objDBCommand.Parameters.Add(dbpDbParameter);
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while adding parameter " + strParameterName + ". ", objEx);
            }
        }

        /// <summary>
        /// Using this function we can add out parameter name, DB type and size.
        /// </summary>
        /// <param name="strParameterName">Name of the parameter.</param>
        /// <param name="objDBType">Type of the obj DB.</param>
        /// <returns>
        /// Return The index of the DbParameter object in the collection.
        /// </returns>
        public int AddOutParameter(string strParameterName, DbType objDBType)
        {
            try
            {
                return this.AddOutParameter(strParameterName, objDBType, 500);
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// It adds the parameter with its type and its size.
        /// </summary>
        /// <param name="strParameterName">Name of the parameter.</param>
        /// <param name="objDBType">Type of the obj DB.</param>
        /// <param name="intParameterSize">Size of the int parameter.</param>
        /// <returns>
        /// Return The index of the DbParameter object in the collection.
        /// </returns>
        public int AddOutParameter(string strParameterName, DbType objDBType, int intParameterSize)
        {
            try
            {
                if (this.objDbOutParameterHashtable == null)
                {
                    this.objDbOutParameterHashtable = new Hashtable();
                }
                else
                {
                    this.objDbOutParameterHashtable.Clear();
                }

                this.objDbOutParameterHashtable.Add(strParameterName.Trim(), string.Empty);

                DbParameter pdpOutDbParameter = this.objDBProviderFactory.CreateParameter();
                pdpOutDbParameter.ParameterName = strParameterName;
                pdpOutDbParameter.DbType = objDBType;
                pdpOutDbParameter.Size = intParameterSize;
                pdpOutDbParameter.Direction = ParameterDirection.Output;

                return this.objDBCommand.Parameters.Add(pdpOutDbParameter);
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while adding Out Parameter " + strParameterName, objEx);
            }
        }

        /// <summary>
        /// It returns the out parameter value which is stored in the Hashtable.
        /// </summary>
        /// <returns>Return HashTable</returns>
        public Hashtable ExecuteOutParameterValue()
        {
            string strParameterName = string.Empty;

            try
            {
                if (this.objDbOutParameterHashtable != null && this.objDbOutParameterHashtable.Count > 0)
                {
                    foreach (DbParameter dbp in this.objDbParameterCollection)
                    {
                        if (dbp.Value != null && (dbp.Direction == ParameterDirection.Output || dbp.Direction == ParameterDirection.ReturnValue))
                        {
                            if (this.objDbOutParameterHashtable.ContainsKey(dbp.ParameterName))
                            {
                                this.objDbOutParameterHashtable.Remove(dbp.ParameterName);
                                this.objDbOutParameterHashtable.Add(dbp.ParameterName, dbp.Value);
                            }
                        }
                    }

                    return this.objDbOutParameterHashtable;
                }

                return null;
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while Reading Value of OutParameter " + strParameterName, objEx);
            }
        }

        /// <summary>
        /// Executes the out parameter value after execution of SP, resultant data will be recieved in Out Parameter.
        /// </summary>
        /// <param name="strParameterName">Name of the STR parameter.</param>
        /// <returns>Return Object</returns>
        public object ExecuteOutParameterValue(string strParameterName)
        {
            try
            {
                object objValue = null;
                foreach (DbParameter dbpParameter in this.objDbParameterCollection)
                {
                    if (dbpParameter.Value != null && (dbpParameter.Direction == ParameterDirection.Output || dbpParameter.Direction == ParameterDirection.ReturnValue))
                    {
                        if (string.Equals(dbpParameter.ParameterName, strParameterName))
                        {
                            objValue = (object)dbpParameter.Value;
                        }
                    }
                }

                return objValue;
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while Reading Value of OutParameter " + strParameterName, objEx);
            }
        }

        /// <summary>
        /// Clears all parameters.
        /// </summary>
        public void  ClearAllParameters()
        {
            try
            {
                objDBCommand.Parameters.Clear();
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while performing operation on ClearAllParameters", objEx);
            }
        }

        #endregion

        #region ///Connection

        /// <summary>
        /// It Opens the connection with the database.
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                if (this.objDBConnection == null)
                {
                    throw new Exception("DB not initialized properly.");
                }

                if (this.objDBConnection.State == System.Data.ConnectionState.Closed || this.objDBConnection.State == System.Data.ConnectionState.Broken)
                {
                    this.objDBConnection.Open();
                }
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while opening connection. Check connection string or database driver.", objEx);
            }
        }

        /// <summary>
        /// It Closes the connection with the database .
        /// </summary>
        private void CloseConnection()
        {
            try
            {
                if (this.objDBConnection == null)
                {
                    throw new Exception("DB not initialized properly.");
                }

                if (this.objDBCommand.Transaction == null && this.objDBConnection.State == System.Data.ConnectionState.Open)
                {
                    this.objDBConnection.Close();
                }
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while closing connection.", objEx);
            }
        }

        #endregion
       
        #endregion
    }
}
