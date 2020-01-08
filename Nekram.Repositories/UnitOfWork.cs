/* Class      : UnitOfWork
 * Description: Defines a Unit of Work using an Entity Framework DbContext under the hood.
 * Create By  : Nkambwe Mark
 * Created On : 24-12-2019
 */

using System;
using System.Collections.Generic;
using Nekram.Infrastructure;

namespace Nekram.Repositories {

    public class UnitOfWork : IUnitOfWork {
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="isnew">When true, clears out any existing data context first.</param>
        public UnitOfWork(bool isnew) {
            if (isnew) {
                ContextFactory.Clear();
            }
        }

        /// <summary>
        /// Get current database connection status
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool IsConnected(out string error) {
            return ContextFactory.GetDataContext().TestConnection(out error);
        }

        /// <summary>
        /// Get connection details for the current user
        /// </summary>
        /// <param name="error"></param>
        /// <returns>
        /// Details include Username, Workstation e.t.c.
        /// </returns>
        public Dictionary<string, string> ConnectionInfor(out string error) {
            return ContextFactory.GetDataContext().ConnectionInfor(out error);
        }

        /// <summary>
        /// Get server version and instance name
        /// </summary>
        /// <param name="servername">Server name</param>
        /// <param name="instance">Server Instance</param>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns></returns>
        public Dictionary<string, string> GetServerInfor(string servername, string instance, out string error) {
            return ContextFactory.GetDataContext().GetServerInfor(servername, instance, out error);
        }

        /// <summary>
        /// Get a list of all servers available on the network
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public List<string> GetServerNames(out string error) {
            return ContextFactory.GetDataContext().GetServerNames(out error);
        }

        /// <summary>
        /// Get a list of all server instances available on this server
        /// </summary>
        /// <param name="server">Server name</param>
        /// <param name="error">Error Message</param>
        /// <returns>
        /// </returns>
        public List<string> GetServerInstances(string server, out string error) {
            return ContextFactory.GetDataContext().GetServerInstances(server, out error);
        }

        /// <summary>
        /// Get a list of all databases available on this server instance
        /// </summary>
        /// <param name="servername"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public List<string> GetDatabases(string servername, out string error) {
            return ContextFactory.GetDataContext().GetDatabases(servername, out error);
        }

        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        /// <param name="reset">When true, clears out the data context afterwards.</param>
        /// <param name="error"></param>
        public void Commit(bool reset, out string error) {
            error = string.Empty;

            try {
                ContextFactory.GetDataContext().SaveChanges();
                if (reset) {
                    ContextFactory.Clear();
                }
            } catch (Exception ex) {
                error = ex.InnerException?.InnerException?.Message;
            }

        }

        /// <summary>
        /// Undoes changes to the current DbContext by removing it from the storage container.
        /// </summary>
        public void Undo() {
            ContextFactory.Clear();
        }

        /// <summary>
        /// Manual disposal of unit of work
        /// </summary>
        /// <param name="isManuallyDisposing"></param>
        protected virtual void Dispose(bool isManuallyDisposing) {
            if (!_disposed) {
                if (isManuallyDisposing)
                    ContextFactory.Clear();
            }

            _disposed = true;
        }

        /// <summary>
        /// Save changes before dispose of UOW
        /// </summary>
        public void Dispose() {
            ContextFactory.GetDataContext().SaveChanges();
        }

        ~UnitOfWork() {
            Dispose(false);
        }
    }

}
