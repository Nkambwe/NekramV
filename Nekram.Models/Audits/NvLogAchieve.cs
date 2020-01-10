using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;
using Nekram.Models.Application;

namespace Nekram.Models.Audits {
    public class NvLogAchieve : EntityObject<int>, IOwned<NvUser> {

        public int UserId { get; set; }
        public int LogactId { get; set; }
        public string Description { get; set; }
        public string WorkStation { get; set; }
        public DateTime LogDate { get; set; }
        public virtual NvUser Owner { get; set; }
        public virtual List<LogActivity> Activity { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {

            if (string.IsNullOrWhiteSpace(Description))
                yield return new ValidationResult("Log Achieve description is required to register a log.", new[] { "Description" });

            if (LogDate > DateTime.Now)
                yield return new ValidationResult("Log Achieve date should be any date before today and 1900", new[] { "LogDate" });

            if (Activity == null)
                yield return new ValidationResult("Log Achieve activity is required for saving log information.", new[] { "Activity" });
        }
    }
}
