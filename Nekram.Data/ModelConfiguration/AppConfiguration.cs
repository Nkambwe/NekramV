using System.Data.Entity.ModelConfiguration;
using Nekram.Models.Application;

namespace Nekram.Data.ModelConfiguration {
    public class AppConfiguration : EntityTypeConfiguration<Appconfig> {

        /// <summary>
        /// Initializes a new instance of the BranchConfigurations class.
        /// </summary>
        public AppConfiguration() {
            ToTable("Branch");
            Property(a => a.ApplicationName).HasMaxLength(120);
            Property(a => a.Version).HasColumnName("vnum").IsRequired().HasMaxLength(80);
            Property(a => a.Type).HasColumnName("vname").IsRequired();
            Property(a => a.Modules).HasColumnName("modules").IsRequired().HasMaxLength(80);
            Property(a => a.Theme).HasColumnName("theme").IsRequired().HasMaxLength(80);
        }
    }
}
