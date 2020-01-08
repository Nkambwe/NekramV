using System.Data.Entity;

namespace Nekram.Data {

    public class DropCreateWhenChanged
        : DropCreateDatabaseIfModelChanges<NvContext> {

        /// <summary>
        /// Creates a required system data
        /// </summary>
        /// <param name="context">The context to which the new seed data is added.</param>
        protected override void Seed(NvContext context)
        {
            
        }
    }

}
