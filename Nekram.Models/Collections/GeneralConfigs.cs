using System.Collections.Generic;
using Nekram.Models.Application;

namespace Nekram.Models.Collections {
    public class GeneralConfigs : NvCollection<Branch> {

        public GeneralConfigs() { }

        public GeneralConfigs(IList<Branch> newcollection)
            : base(newcollection) { }

        public GeneralConfigs(NvCollection<Branch> newcollection)
            : base(newcollection) { }

    }
}
