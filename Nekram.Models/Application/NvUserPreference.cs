using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;

namespace Nekram.Models.Application {
    public class NvUserPreference : EntityObject<int>, IOwned<NvUser> {

        public string Avator { get; set; }
        public Theme Theme { get; set; }
        public NvUser Owner { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (Owner == null)
                yield return new ValidationResult("No user attatched to these preferences", new[] { "Owner" });
        }

    }
}
