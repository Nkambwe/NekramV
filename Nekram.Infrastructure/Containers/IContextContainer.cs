/* Interface  : IContextContainer
 * Description: Defines methods to create, store and clear objects from a storage container.
 * Create By  : Nkambwe Mark
 * Created On : 24-12-2019
 */

namespace Nekram.Infrastructure.Containers {

    public interface IContextContainer<T> {
        /// <summary>
        /// Returns an object from the container when it exists. Returns null otherwise.
        /// </summary>
        /// <param name="connectionstring">Optional connection string in case one is provided</param>
        /// <returns>The object from the container when it exists, null otherwise.</returns>
        T GetDataContext(string connectionstring = "");

        /// <summary>
        /// Stores the object in HttpContext.Current.Items.
        /// </summary>
        /// <param name="objectContext">The object to store.</param>
        void Store(T objectContext);

        /// <summary>
        /// Clears the object from the container.
        /// </summary>
        void Clear();
    }

}
