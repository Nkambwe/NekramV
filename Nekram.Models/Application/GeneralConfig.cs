

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;

namespace Nekram.Models.Application {

    public class GeneralConfig : EntityObject<int>, IOwned<Branch> {

        public string ConfigName { get; set; } //MinPassLength, PassPattern, LogAchivePeriod
        public string ConfigValue { get; set; }//{Min(8)}, {Regex for password}, {30}
        public Branch Owner { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (string.IsNullOrWhiteSpace(ConfigName))
                yield return new ValidationResult("Congiguration description is required.", new[] { "ConfigName" });

            if (string.IsNullOrWhiteSpace(ConfigValue))
                yield return new ValidationResult("Congiguration value is required.", new[] { "ConfigValue" });

            if (Owner == null) {
                yield return new ValidationResult("Add the branch this congiguration belongs to", new[] { "Owner" });
            }
        }

    }
}
