
using System;
using Nekram.Infrastructure;
using Nekram.Models.Audits;
using Nekram.Models.Collections;

namespace Nekram.Models.Application {
    public abstract class BranchBase : EntityObject<int>, ICreateModifyTracker {
        public int ParentId { get; set; }
        public abstract bool IsParent { get; set; }
        public abstract string LegalName { get; set; }
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
        public bool IsMain { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}
