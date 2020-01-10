using System.Collections.Generic;
using Nekram.Models.Application;

namespace Nekram.Models.Collections {
    public class NvUsers : NvCollection<NvUser> {

        public NvUsers() { }

        public NvUsers(IList<NvUser> newcollection)
            : base(newcollection) { }

        public NvUsers(NvCollection<NvUser> newcollection)
            : base(newcollection) { }

    }
}
