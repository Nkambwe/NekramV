/* Class      : ContextFactoryContainer
 * Description: A helper class to create application platform specific storage containers.
 * Create By  : Nkambwe Mark
 * Created On : 24-12-2019
 */

using System.Web;

namespace Nekram.Infrastructure.Containers {

    /// <summary>
    /// Application storage container
    /// </summary>
    /// <typeparam name="T">The type for which to create the container.</typeparam>
    public static class ContextFactoryContainer<T> where T : class {

        private static IContextContainer<T> _contextFactoryContainer;

        /// <summary>
        /// Creates a new container that uses HttpContext.Current.Items (when HttpContext.Current is not null) or Thread.Items.
        /// </summary>
        /// <returns>
        /// A Prema storage container to store objects.
        /// </returns>
        public static IContextContainer<T> CreateFactoryContainer() {

            if (_contextFactoryContainer == null) {

                if (HttpContext.Current == null)
                    _contextFactoryContainer = new ThreadContextContainer<T>();
                else
                    _contextFactoryContainer = new HttpContextContainer<T>();
            }
            return _contextFactoryContainer;
        }
    }

}
