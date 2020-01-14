using System.Data.Entity.ModelConfiguration;
using Nekram.Models.Application;

namespace Nekram.Data.ModelConfiguration {
    public class UserPrefConfiguration
        : EntityTypeConfiguration<NvUserPreference> {

        public UserPrefConfiguration() {
            ToTable("userpref");
            HasRequired(p => p.Owner).WithOptional(u => u.Preferences);
        }
    }
}
