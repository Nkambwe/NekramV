

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;

namespace Nekram.Models.Application {
    public class Tax : EntityObject<int>, IOwned<Branch> {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Tin { get; set; }
        public int Rate { get; set; }
        public virtual Branch Owner { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("Name of tax is required.", new[] { "Name" });

            if (string.IsNullOrWhiteSpace(Tin))
                yield return new ValidationResult("Tax TIN number is required.", new[] { "Tin" });

            if (string.IsNullOrWhiteSpace(Tin))
                yield return new ValidationResult("Tax rate is required.", new[] { "Rate" });

        }
    }
}
