
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;
using Nekram.Models.Application;

namespace Nekram.Models.Audits {

    public class BranchAudit : EntityObject<int>, ICreateModifyTracker {
        public int BranchId { get; set; }
        public string OldLegalName { get; set; }
        public string OldAlias { get; set; }
        public string OldAddress { get; set; }
        public string OldCity { get; set; }
        public string OldPostalAddress { get; set; }
        public string OldEmail { get; set; }
        public string OldTelephone { get; set; }
        public string OldMobil { get; set; }
        public string OldLogo { get; set; }
        public string OldWebsite { get; set; }
        public string OldCountry { get; set; }
        public string NewLegalName { get; set; }
        public string NewAlias { get; set; }
        public string NewAddress { get; set; }
        public string NewCity { get; set; }
        public string NewPostalAddress { get; set; }
        public string NewEmail { get; set; }
        public string NewTelephone { get; set; }
        public string NewMobil { get; set; }
        public string NewLogo { get; set; }
        public string NewWebsite { get; set; }
        public string NewCountry { get; set; }
        public bool IsFlaged { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string AuthorizedBy { get; set; }
        public string Reason { get; set; }

        public virtual Branch Parent { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (string.IsNullOrWhiteSpace(OldLegalName))
                yield return new ValidationResult("Company's legal name is required", new[] { "LegalName" });

            if (string.IsNullOrWhiteSpace(OldAddress))
                yield return new ValidationResult("Company's Address is required.", new[] { "Address" });

            if (string.IsNullOrWhiteSpace(OldPostalAddress))
                yield return new ValidationResult("Company's postal address is required.", new[] { "PostalAddress" });

            if (string.IsNullOrWhiteSpace(OldTelephone))
                yield return new ValidationResult("Company's contact number is required", new[] { "Telephone" });

        }

    }
}
