using System.Collections.Generic;
using Nekram.Models.Application;

namespace Nekram.Models.Collections {
    public class Appconfigs : NvCollection<Branch> {

        public Appconfigs() { }

        public Appconfigs(IList<Branch> newcollection)
            : base(newcollection) { }

        public Appconfigs(NvCollection<Branch> newcollection)
            : base(newcollection) { }

    }
}
