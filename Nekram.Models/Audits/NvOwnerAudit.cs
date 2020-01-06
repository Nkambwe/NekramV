
using System;
using System.Collections.Generic;
using Nekram.Models.Application;

namespace Nekram.Models.Audits {

    public class NvOwnerAudit {

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
        public bool IsFlaged { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string Reason { get; set; }
        public string AuthorizedBy { get; set; }

        public virtual NvOwner Company { get; set; }
    }
}
