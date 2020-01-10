/*Class       : LogActivity
 * Description: Class list activities that fraud prone
                and should log user activities on such activites.
                For example, Payments, Change of work station, Item returns etc.
*/

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;

namespace Nekram.Models.Audits {
    public class LogActivity: EntityObject<int> {
        public string ActivityName { get; set; }
        public bool ShouldLog { get; set; }
        public virtual List<NvUserLog> Logs { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (string.IsNullOrWhiteSpace(ActivityName))
                yield return new ValidationResult("Log activity name is required", new[] { "ActivityName" });
        }
    }
}
