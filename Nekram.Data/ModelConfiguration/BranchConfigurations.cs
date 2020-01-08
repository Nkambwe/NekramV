

using System.Data.Entity.ModelConfiguration;
using Nekram.Models.Application;

namespace Nekram.Data.ModelConfiguration {
    public class BranchConfigurations : EntityTypeConfiguration<Branch> {
        /// <summary>
        /// Initializes a new instance of the CompanyConfiguration class.
        /// </summary>
        public BranchConfigurations() {
            Property(c => c.LegalName).IsRequired().HasMaxLength(50);
            Property(c => c.Address).IsRequired().HasMaxLength(80);
            Property(c => c.City).IsRequired().HasMaxLength(20);
            Property(c => c.PostalAddress).IsRequired().HasMaxLength(30);
            Property(c => c.Email).IsRequired().HasMaxLength(50);
            Property(c => c.Telephone).IsRequired().HasMaxLength(15);
            Property(c => c.Mobil).HasMaxLength(15);
            Property(c => c.Country).HasMaxLength(80);
            HasMany(c => c.Audits).WithRequired(a => a.Parent).HasForeignKey(a => a.BranchId);
            HasMany(c => c.Branches).WithRequired(u => u.Parent).HasForeignKey(u => u.ParentId);

        }
    }
}
