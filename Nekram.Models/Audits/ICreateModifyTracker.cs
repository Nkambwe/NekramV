using System;

namespace Nekram.Models.Audits {

    /// <summary> 
    /// Defines an interface for objects whose creation and modified 
    /// dates are kept track of automatically. 
    /// </summary> 

    public interface ICreateModifyTracker {
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
