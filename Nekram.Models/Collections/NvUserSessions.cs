using System.Collections.Generic;
using Nekram.Models.Application;

namespace Nekram.Models.Collections {
    public class NvUserSessions : NvCollection<NvUserSession> {
        public NvUserSessions() { }

        public NvUserSessions(IList<NvUserSession> newcollection)
            : base(newcollection) { }

        public NvUserSessions(NvCollection<NvUserSession> newcollection)
            : base(newcollection) { }
    }
}
