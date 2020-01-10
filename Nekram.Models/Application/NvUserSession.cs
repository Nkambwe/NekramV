using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;

namespace Nekram.Models.Application {

    public class NvUserSession : EntityObject<int>, IOwned<NvUser> {

        public int UserId { get; set; }
        public string UserCode { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionStart { get; set; }
        public string SessionEnd { get; set; }
        public int Duration { get; set; }
        public string WorkStation { get; set; }
        public virtual NvUser Owner { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {

            if (string.IsNullOrWhiteSpace(UserCode))
                yield return new ValidationResult("User code is required", new[] { "UserCode" });

            if (SessionDate > DateTime.Now)
                yield return new ValidationResult("Invalid session date; must be between today or any day before today", new[] { "SessionDate" });

            if (Owner == null)
                yield return new ValidationResult("Session is not attatched to a user.", new[] {"Owner"});
        }

        public override string ToString() {
            return $"{UserCode}-{SessionDate}";
        }

    }
}
