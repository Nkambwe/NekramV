

using System.Collections.Generic;
using Nekram.Models.Application;

namespace Nekram.Models.Collections {
    public class Branches: NvCollection<BranchBase> {

        public Branches() { }

        public Branches(IList<BranchBase> newcollection)
            : base(newcollection) { }

        public Branches(NvCollection<BranchBase> newcollection)
            : base(newcollection) { }

    }
}
