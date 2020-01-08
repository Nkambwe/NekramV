
using System.Collections.Generic;
using Nekram.Infrastructure;
using Nekram.Models.Application;

namespace Nekram.Models.RepositoryInterfaces {
    public interface IBranchRepository 
        :IRepository<Branch, int>{

        IEnumerable<Branch> FindByAlias(string alias);
    }
}
