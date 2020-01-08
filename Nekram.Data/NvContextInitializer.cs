using System.Data.Entity;

namespace Nekram.Data {
    public static class NvContextInitializer {
        /// <summary>
        /// Sets the IDatabaseInitializer for the application.
        /// </summary>
        /// <param name="shoudDropdb">When true, uses the DropCreateWhenChanged to recreate the database when necessary.
        /// Otherwise, database initialization is disabled by passing null to the SetInitializer method.
        /// </param>
        /// <param name="dropcreate">Instance of class that seeds data</param>
        public static void Init(bool shoudDropdb, DropCreateWhenChanged dropcreate = null) {
            if (shoudDropdb) {
                Database.SetInitializer(dropcreate);
                using (var db = new NvContext()) {
                    db.Database.Initialize(false);
                }
            } else {
                Database.SetInitializer<NvContext>(null);
            }
        }
    }

}
