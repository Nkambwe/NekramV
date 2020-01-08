using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;

namespace Nekram.Models.Application {

    public class Appconfig : ValueObject < Appconfig > {

        public string Theme { get; set; }
        public string Version { get; set; }
        public AppType Type { get; set; }
        public string Modules { get; set; }
        public string ApplicationName { get; set; }

        public bool IsNull {
            get {
                return (string.IsNullOrEmpty(Modules) &&
                        string.IsNullOrEmpty(ApplicationName) &&
                        string.IsNullOrEmpty(Version));
            }
        }

        public virtual Branch Company { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (string.IsNullOrWhiteSpace(Version))
                yield return new ValidationResult("Critical Error: Unknown application version.", new[] { "Version" });

            if (string.IsNullOrWhiteSpace(Modules))
                yield return new ValidationResult("Critical Error: A list of modules attatched to this company file are required.", new[] { "Modules" });

            if (string.IsNullOrWhiteSpace(ApplicationName))
                yield return new ValidationResult("Critical Error: Unknown application name.", new[] { "ApplicationName" });
        }

        public override string ToString() {
            return $"{ApplicationName} {Version}";
        }
    }
}
