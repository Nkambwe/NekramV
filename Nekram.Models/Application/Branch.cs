using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nekram.Models.Application {

    public class Branch: BranchBase {
        public override bool IsParent { get; set; }
        public override string LegalName { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (string.IsNullOrWhiteSpace(LegalName))
                yield return new ValidationResult("Company's legal name is required", new[] { "LegalName" });

            if (string.IsNullOrWhiteSpace(Address))
                yield return new ValidationResult("Company's Address is required.", new[] { "Address" });

            if (string.IsNullOrWhiteSpace(PostalAddress))
                yield return new ValidationResult("Company's postal address is required.", new[] { "PostalAddress" });

            if (string.IsNullOrWhiteSpace(Telephone))
                yield return new ValidationResult("Company's contact number is required", new[] { "Telephone" });

        }

    }
}
