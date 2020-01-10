
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;

namespace Nekram.Models.Application {
    public class LoginStation : EntityObject<int>, IOwned<NvUser> {

        public int UserId { get; set; }
        public string Computer { get; set; }//comId
        public string Station { get; set; }//stat
        public string MacAddress { get; set; }//mac
        public string Location { get; set; }//loc

        public virtual NvUser Owner { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {

            if (string.IsNullOrWhiteSpace(Station))
                yield return new ValidationResult("Station name is required", new[] { "Station" });

        }
    }
}
