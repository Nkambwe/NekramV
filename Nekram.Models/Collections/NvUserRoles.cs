using System.Collections.Generic;
using Nekram.Models.Application;

namespace Nekram.Models.Collections {
    public class NvUserRoles : NvCollection<NvUserRole> {

        public NvUserRoles() { }

        public NvUserRoles(IList<NvUserRole> newcollection)
            : base(newcollection) { }

        public NvUserRoles(NvCollection<NvUserRole> newcollection)
            : base(newcollection) { }

    }
}
