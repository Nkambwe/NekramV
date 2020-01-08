﻿/* Class      : NvContext
 * Description: This is the main DbContext to work with data in the database.
 * Create By  : Nkambwe Mark
 * Created On : 24-12-2019
 */

using System;
using System.Data;
using System.Data.Entity;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration.Conventions;
using Nekram.Data.ModelConfiguration;
using Nekram.Models.Application;
using Nekram.Models.Audits;

namespace Nekram.Data {

    public class NvContext : DbContext {

        private readonly string _connectionstring;

        /// <summary>
        /// Provides access to the collection of members in the system.
        /// </summary>
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchAudit> Audits { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public NvContext()
            : base("NekramvDb") {

            Configuration.LazyLoadingEnabled = false;

        }

        /// <summary>
        /// Constructor with connection string parameter
        /// </summary>
        /// <param name="connectionstring"></param>
        public NvContext(string connectionstring)
            : base(connectionstring) {
            _connectionstring = connectionstring;
        }

        #region Server Management

        /// <summary>
        /// Get a list of accessible sql servers
        /// </summary>
        /// <param name="servername">Server name</param>
        /// <param name="instance">Server Instance</param>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns></returns>
        public Dictionary<string, string> GetServerInfor(string servername, string instance, out string error) {
            error = string.Empty;
            var serverinfor = new Dictionary<string, string>();

            try {
                var dtsource = SqlDataSourceEnumerator.Instance;
                var servers = dtsource.GetDataSources();


                foreach (DataRow r in servers.Rows) {

                    if ((string)r["ServerName"] == servername.Trim() && (string)r["InstanceName"] == instance.Trim()) {

                        serverinfor.Add("Name", (string)r["ServerName"]);
                        serverinfor.Add("Instance", (string)r["InstanceName"]);
                        serverinfor.Add("Clustered", (string)r["IsClustered"]);
                        serverinfor.Add("Version", (string)r["Version"]);

                        break;
                    }
                }

            } catch (Exception ex) {
                error = ex.InnerException?
                            .InnerException != null ?
                    ex.InnerException.InnerException.Message : ex.Message;
            }

            return serverinfor;

        }

        /// <summary>
        /// Get a list of accessible sql servers
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public List<string> GetServerNames(out string error) {

            error = string.Empty;
            var servers = new List<string>();

            try {
                var instance = SqlDataSourceEnumerator.Instance;
                var serverslist = instance.GetDataSources();

                foreach (DataRow r in serverslist.Rows) {
                    var servername = $"{r["ServerName"]}\\{r["InstanceName"]}";

                    if (!servers.Contains(servername.Trim()))
                        servers.Add(servername);
                }

            } catch (Exception ex) {
                error = ex.InnerException?
                            .InnerException != null ?
                    ex.InnerException.InnerException.Message : ex.Message;
            }

            return servers;

        }

        /// <summary>
        /// Get a list of accessible sql servers
        /// </summary>
        /// <param name="servername">Server name</param>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns></returns>
        public List<string> GetServerInstances(string servername, out string error) {

            error = string.Empty;
            var instances = new List<string>();

            try {
                var instance = SqlDataSourceEnumerator.Instance;
                var serverslist = instance.GetDataSources();

                foreach (DataRow r in serverslist.Rows) {

                    if ((string)r["ServerName"] == servername) {
                        var instname = r["InstanceName"].ToString();

                        if (!instances.Contains(instname.Trim()))
                            instances.Add(instname);
                    }

                }

            } catch (Exception ex) {
                error = ex.InnerException?
                            .InnerException != null ?
                    ex.InnerException.InnerException.Message : ex.Message;
            }

            return instances;

        }

        /// <summary>
        /// Get a list databases on this server instance
        /// </summary>
        /// <param name="servername">Server name</param>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns></returns>
        public List<string> GetDatabases(string servername, out string error) {
            error = string.Empty;
            var databases = new List<string>();

            try {

                var connectString = $"Data Source={servername};Integrated Security=True;Initial Catalog=master";

                using (var connection = new SqlConnection(connectString)) {
                    // Open connection
                    connection.Open();

                    //Get databases names in server in a datareader 
                    const string query = "SELECT [Name] FROM SYS.DATABASES;";

                    using (var command = new SqlCommand(query, connection)) {

                        using (var reader = command.ExecuteReader()) {

                            while (reader.Read()) {
                                var db = reader[0].ToString();
                                if (!databases.Contains(db))
                                    databases.Add(db);
                            }
                        }
                    }
                }

            } catch (Exception ex) {
                error = ex.InnerException?
                            .InnerException != null ?
                    ex.InnerException.InnerException.Message : ex.Message;
            }

            return databases;
        }

        /// <summary>
        /// Test database connection
        /// </summary>
        /// <param name="error">ConnectionError</param>
        /// <returns></returns>
        public bool TestConnection(out string error) {

            error = string.Empty;
            var connection = new SqlConnection(_connectionstring);

            try {
                connection.Open();
                return true;
            } catch (SqlException ex) {

                error = ex.InnerException?.InnerException != null ? $"{ex.InnerException?.InnerException?.Message}" : $"{ex.Message}";
                return false;

            } finally {
                connection.Close();
            }
        }

        /// <summary>
        /// Retrieve informantion about user connection
        /// </summary>
        /// <param name="error">Error message in case it occurs</param>
        /// <returns></returns>
        public Dictionary<string, string> ConnectionInfor(out string error) {
            var infor = new Dictionary<string, string>();
            error = string.Empty;
            var connection = new SqlConnection(_connectionstring);
            try {
                connection.Open();

                infor.Clear();
                infor.Add(@"Database", connection.Database);
                infor.Add(@"Server", connection.DataSource);
                infor.Add(@"ServerVersion", connection.ServerVersion);
                infor.Add(@"ConnectionState", connection.State.ToString());
                infor.Add(@"WorkStation", connection.WorkstationId);

            } catch (SqlException ex) {
                error = ex.InnerException?.InnerException != null ? $"{ex.InnerException?.InnerException?.Message}" : $"{ex.Message}";
            } finally {
                connection.Close();
            }

            return infor;
        }

        #endregion

        /// <summary>
        /// Context configurations and settings
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new BranchConfigurations());
            modelBuilder.Configurations.Add(new BranchAuditsConfigurations());
        }
    }
}
