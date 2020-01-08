/* Class      : IUnitOfWorkFactory
 * Description: Creates new instances of a unit of Work.
 * Create By  : Nkambwe Mark
 * Created On : 24-12-2019
 */

namespace Nekram.Infrastructure {

    public interface IUnitOfWorkFactory {
        /// <summary>
        /// Creates a new instance of a unit of work
        /// </summary>
        IUnitOfWork Create();

        /// <summary>
        /// Creates a new instance of a unit of work
        /// </summary>
        /// <param name="forceNew">When true, clears out any existing in-memory data storage / cache first.</param>
        IUnitOfWork Create(bool forceNew);
    }

}
