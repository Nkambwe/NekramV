/* Class      : ContextFactory
 * Description: Manages instances of the NvContext and stores them in an appropriate storage container.
 * Notes      :
 *            When you call ContextFactory.GetDataContext(), the method first creates a new storage container
 *            by calling ContextFactoryContainer<NvContext>.CreateFactoryContainer().
 *            In a web project, this code returns an HttpContextContainer and in unit tests 
 *            (or other applications where HttpContextis not available), it returns a ThreadContextContainer.
 *            It then calls GetDataContext on the container. That method checks its underlying storage 
 *            mechanism to see if an instance of the NvContext exists and then returns it, 
 *            or it returns null. When the NvContext is null, a new instance is created and 
 *            then stored by calling Store on the container. Again, the respective context containers
 *            use their underlying storage mechanism to store the NvContext.	Finally, the 
 *            NvContext is returned to the calling code.
 * 
 * Create By  : Nkambwe Mark
 * Created On : 24-12-2019
 */

using Nekram.Data;
using Nekram.Infrastructure.Containers;

namespace Nekram.Repositories {
    public static class ContextFactory {

        /// <summary>
        /// Clears out the current Context.
        /// </summary>
        public static void Clear() {
            var contextContainer = ContextFactoryContainer<NvContext>.CreateFactoryContainer();
            contextContainer.Clear();
        }

        /// <summary>
        /// Retrieves an instance of NvContext from the appropriate storage container or
        /// creates a new instance and stores that in a container.
        /// </summary>
        /// <param name="connectionstring">Optional connection string</param>
        /// <returns>An instance of PremaContext.</returns>
        public static NvContext GetDataContext(string connectionstring = "") {
            var contextContainerFactory = ContextFactoryContainer<NvContext>.CreateFactoryContainer();
            var context = !string.IsNullOrEmpty(connectionstring)
                ? contextContainerFactory.GetDataContext(connectionstring)
                : contextContainerFactory.GetDataContext();

            if (context == null) {
                context = !string.IsNullOrEmpty(connectionstring)
                    ? new NvContext(connectionstring)
                    : new NvContext();
                contextContainerFactory.Store(context);
            }

            return context;
        }

    }
}
