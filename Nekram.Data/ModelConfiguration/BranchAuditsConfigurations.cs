

using System.Data.Entity.ModelConfiguration;
using Nekram.Models.Audits;

namespace Nekram.Data.ModelConfiguration
{
    public class BranchAuditsConfigurations : EntityTypeConfiguration<BranchAudit>
    {
        /// <summary>
        /// Initializes a new instance of the BranchAuditsConfigurations class.
        /// </summary>
        public BranchAuditsConfigurations() {
            Property(a => a.OldLegalName).HasColumnName("olegal").HasMaxLength(80);
            Property(a => a.OldAddress).HasColumnName("oaddress").HasMaxLength(80);
            Property(a => a.OldCity).HasColumnName("ocity").HasMaxLength(20);
            Property(a => a.OldPostalAddress).HasColumnName("opostal").HasMaxLength(30);
            Property(a => a.OldEmail).HasColumnName("omail").HasMaxLength(50);
            Property(a => a.OldTelephone).HasColumnName("otel").HasMaxLength(15);
            Property(a => a.OldMobil).HasColumnName("omob").HasMaxLength(15);
            Property(a => a.OldCountry).HasColumnName("octry").HasMaxLength(80);
            Property(a => a.OldWebsite).HasColumnName("osite").HasMaxLength(180);
            Property(a => a.NewLegalName).HasColumnName("nlegal").HasMaxLength(80);
            Property(a => a.NewAddress).HasColumnName("naddress").HasMaxLength(80);
            Property(a => a.NewCity).HasColumnName("ncity").HasMaxLength(20);
            Property(a => a.NewPostalAddress).HasColumnName("npostal").HasMaxLength(30);
            Property(a => a.NewEmail).HasColumnName("nmail").HasMaxLength(50);
            Property(a => a.NewTelephone).HasColumnName("ntel").HasMaxLength(15);
            Property(a => a.NewMobil).HasColumnName("nmob").HasMaxLength(15);
            Property(a => a.NewCountry).HasColumnName("nctry").HasMaxLength(80);
            Property(a => a.NewWebsite).HasColumnName("nsite").HasMaxLength(180);
            Property(a => a.IsFlaged).HasColumnName("flag");
            Property(a => a.Created).HasColumnName("cdate");
            Property(a => a.Modified).HasColumnName("mdate");
            Property(a => a.ModifiedBy).HasColumnName("user").HasMaxLength(10);
            Property(a => a.AuthorizedBy).HasColumnName("auth").HasMaxLength(10);
            Property(a => a.Reason).HasColumnName("notes");
            HasRequired(a => a.Parent).WithMany(b => b.Audits).HasForeignKey(a=> a.BranchId);

        }
    }
}
