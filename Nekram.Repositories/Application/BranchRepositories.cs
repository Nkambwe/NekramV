
using System.Collections.Generic;
using System.Linq;
using Nekram.Models.Application;
using Nekram.Models.RepositoryInterfaces;

namespace Nekram.Repositories.Application {

    public class BranchRepositories
        :Repository<Branch>, IBranchRepository {

        /// <summary>
        /// Find branch by alias name
        /// </summary>
        /// <param name="alias">Short format of company name</param>
        /// <returns>
        /// Branch object
        /// </returns>
        public IEnumerable<Branch> FindByAlias(string alias) {

            return ContextFactory.GetDataContext().Set<Branch>().Where(
                x => x.Alias == alias).ToList();
        }
    }
}
