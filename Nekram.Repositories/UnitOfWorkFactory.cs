

using Nekram.Infrastructure;

namespace Nekram.Repositories {

    /// <summary>
    /// Creates new instances of an EF unit of Work.
    /// </summary>
    public class UnitOfWorkFactory :IUnitOfWorkFactory {

        /// <summary>
        /// Creates a new instance of an UnitOfWork.
        /// </summary>
        public IUnitOfWork Create() {
            return Create(false);
        }

        /// <summary>
        /// Creates a new instance of an UnitOfWork.
        /// </summary>
        /// <param name="isforced">When true, clears out any existing data context from the storage container.</param>
        public IUnitOfWork Create(bool isforced) {
            return new UnitOfWork(isforced);
        }
    }
}
