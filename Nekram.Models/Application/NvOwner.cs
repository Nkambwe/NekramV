/*Class: NvOwner
 * Description: This class represents the company object of the company using the software
 * and is directly linked to the configuration file.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;
using Nekram.Models.Audits;

namespace Nekram.Models.Application {

    public class NvOwner : EntityObject < int >, ICreateModifyTracker {

        public string LegalName { get; set; }
        public string Alias { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalAddress { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Mobil { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public bool IsValid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual Appconfig Configurations { get; set; }
        public virtual ICollection<NvOwnerAudit> Modifications { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)  {
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
