

using System.Data.Entity.ModelConfiguration;
using Nekram.Models.Application;

namespace Nekram.Data.ModelConfiguration {
    public class UsersConfiguration
        : EntityTypeConfiguration<NvUser> {

        public UsersConfiguration() {
            ToTable("appuser");
            HasOptional(u => u.Preferences).WithRequired(p => p.Owner);
        }
    }
}
