
using System.Data.Entity.ModelConfiguration;
using Nekram.Models.Application;

namespace Nekram.Data.ModelConfiguration {

    public class BranchConfigurations : EntityTypeConfiguration<Branch> {

        /// <summary>
        /// Initializes a new instance of the BranchConfigurations class.
        /// </summary>
        public BranchConfigurations() {
            ToTable("Branch");
            Property(c => c.ParentId).IsOptional();
            Property(c => c.LegalName).IsRequired().HasMaxLength(80);
            Property(c => c.Address).IsRequired().HasMaxLength(80);
            Property(c => c.City).IsRequired().HasMaxLength(50);
            Property(c => c.PostalAddress).IsRequired().HasMaxLength(80);
            Property(c => c.Email).IsRequired().HasMaxLength(80);
            Property(c => c.Telephone).IsRequired().HasMaxLength(25);
            Property(c => c.Mobil).HasMaxLength(25);
            Property(c => c.Country).HasMaxLength(80);
            HasMany(c => c.Branches);
            HasMany(c => c.Configurations).WithRequired(a => a.Owner).HasForeignKey(a => a.BranchId);
            HasMany(c => c.Users).WithRequired(u => u.Owner).HasForeignKey(u => u.BranchId);
        }
    }
}
