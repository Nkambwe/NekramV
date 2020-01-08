using System;
using System.Collections.Generic;

namespace Nekram.Infrastructure {

    public interface IUnitOfWork : IDisposable {

        /// <summary>
        /// Database connection status
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        bool IsConnected(out string error);

        /// <summary>
        /// Collection of connection infor
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        Dictionary<string, string> ConnectionInfor(out string error);

        /// <summary>
        /// Get a list of accessible sql servers
        /// </summary>
        /// <param name="servername">Server name</param>
        /// <param name="instance">Server Instance</param>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns></returns>
        Dictionary<string, string> GetServerInfor(string servername, string instance, out string error);

        /// <summary>
        /// Get a list of accessible sql servers
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        List<string> GetServerNames(out string error);

        /// <summary>
        /// Get a list of accessible sql servers
        /// </summary>
        /// <param name="name">Server name</param>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns></returns>
        List<string> GetServerInstances(string name, out string error);

        /// <summary>
        /// Get a list databases on this server instance
        /// </summary>
        /// <param name="servername">Server name</param>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns></returns>
        List<string> GetDatabases(string servername, out string error);

        /// <summary>
        /// Commits the changes to the underlying data store. 
        /// </summary>
        /// <param name="reset">When true, clears out the data context afterwards.</param>
        /// <param name="error">Error in case something goes wrong</param>
        void Commit(bool reset, out string error);

        /// <summary>
        /// Undoes all changes to the entities in the model.
        /// </summary>
        void Undo();
    }
}
