

using System.Collections.Generic;
using Nekram.Models.Application;

namespace Nekram.Models.Collections {
    public class Branches: NvCollection<Branch> {

        public Branches() { }

        public Branches(IList<Branch> newcollection)
            : base(newcollection) { }

        public Branches(NvCollection<Branch> newcollection)
            : base(newcollection) { }

    }
}
