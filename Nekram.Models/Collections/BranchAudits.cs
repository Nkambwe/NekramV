using System.Collections.Generic;
using Nekram.Models.Audits;

namespace Nekram.Models.Collections {

    public class BranchAudits : NvCollection<BranchAudit> {

        public BranchAudits() { }

        public BranchAudits(IList<BranchAudit> newcollection)
            : base(newcollection) { }

        public BranchAudits(NvCollection<BranchAudit> newcollection)
            : base(newcollection) { }

    }
}
