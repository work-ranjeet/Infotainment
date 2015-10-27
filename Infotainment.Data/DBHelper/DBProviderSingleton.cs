

namespace PCL.DBHelper
{
    using System;
    using System.Configuration;

    /// <summary>
    /// DBProviderSingleton is a singleton class that facilate to create only one instance of the class.
    /// </summary>
    public class DBProviderSingleton
    {
        #region ///Declaration

        /// <summary>
        /// Declaring an object for DBProviderSingleton Class and setting it to null.
        /// </summary>
        private static DBProviderSingleton objDBProviderSingleton = null;

        /// <summary>
        /// strProviderName holds the Provider Name of the database that is to be used.
        /// </summary>
        private string strProviderName = string.Empty;

        /// <summary>
        /// strConnectionString holds the Connection String for the corresponding Provider Name.
        /// </summary>
        private string strConnectionString = string.Empty;

        private string _connctionStringName = string.Empty;

        #endregion

        /// <summary>
        /// Prevents a default instance of the DBProviderSingleton Class.
        /// This constructor will read connectionstring as well as providername from web.config file.
        /// </summary>
        private DBProviderSingleton(string connectionStringName = "ConnectionString")
        {
            try
            {
                // Look for the name in the connectionStrings section.
                var  settings = ConfigurationManager.ConnectionStrings[connectionStringName];
                if (settings != null)
                {
                    this.strConnectionString = settings.ConnectionString;
                    this.strProviderName = settings.ProviderName;
                }
                else
                {
                    //Throw an error if connection string is not foung in web.config file.
                    if (string.IsNullOrEmpty(this.strConnectionString))
                    {
                        throw new Exception("Error while reading ConnectinString.");
                    }

                    //Throw an error if providername is not foung in web.config file.
                    if (string.IsNullOrEmpty(this.strProviderName))
                    {
                        throw new Exception("Error while reading ProviderName.");
                    }
                }

            }
            catch (Exception objEx)
            {
                throw objEx;
            }
        }

        /// <summary>
        /// Gets provider name when programmer call this property.
        /// </summary>
        /// <value>The name of the get provider.</value>
        public string ProviderName
        {
            get
            {
                try
                {
                    return objDBProviderSingleton.strProviderName;
                }
                catch (Exception objEx)
                {
                    throw new Exception("Error while performing GetProviderName operation.", objEx);
                }
            }
        }

        /// <summary>
        /// Gets ConnectionString when programmer call this property. 
        /// </summary>
        /// <value>The get connection string.</value>
        public string ConnectionString
        {
            get
            {
                try
                {
                    return objDBProviderSingleton.strConnectionString;
                }
                catch (Exception objEx)
                {
                    throw new Exception("Error while performing GetConnectionString operation.", objEx);
                }
            }
        }

        /// <summary>
        /// Gets the instance.
        /// When class is first accessed, GetInsatnce() creates relevant object instance and returns object identity to programmer. 
        /// On subsequent calls of getInstance(), no new instance is created, but identity of existing object is returned.
        /// </summary>
        /// <returns>return instance of DBProviderSingleton class</returns>
        public static DBProviderSingleton Instance(string connectionStringName)
        {
            try
            {
                if (objDBProviderSingleton == null)
                {
                    objDBProviderSingleton = new DBProviderSingleton(connectionStringName);
                }

                return objDBProviderSingleton;
            }
            catch (Exception objEx)
            {
                throw new Exception("Error while creating instance of DBProviderSingleton.", objEx);
            }
        }
    }
}

