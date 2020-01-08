﻿/*Class: NvOwner
 * Description: This class represents the company object of the company using the software
 * and is directly linked to the configuration file.
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Models.Collections;

namespace Nekram.Models.Application {

    public class NvOwner : BranchBase {
        private bool _isparent;

        public override bool IsParent {
            get { return _isparent; }
            set { _isparent = value; }
        }

        public override string LegalName { get; set; }
        public virtual Appconfig Configurations { get; set; }


        public NvOwner() {
            _isparent = true;
            Branches = new Branches();
            Audits = new BranchAudits();
        }

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
