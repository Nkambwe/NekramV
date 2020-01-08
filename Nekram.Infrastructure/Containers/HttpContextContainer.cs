/* Class      : HttpContextContainer
 * Description: A Helper class to store objects like a DataContext in the HttpContext.Current.Items collection.
 *              It is a concrete implementation of IContextFactoryContainer which stores the data context in 
 *              the HttpContext. This version is used in all web-related projects.
 * Create By  : Nkambwe Mark
 * Created On : 24-12-2019
 */

using System.Web;

namespace Nekram.Infrastructure.Containers {
    public class HttpContextContainer<T> : IContextContainer<T> where T : class {

        private const string DataContextKey = "NvContext";

        /// <summary>
        /// Returns an object from the container when it exists. Returns null otherwise.
        /// </summary>
        /// <param name="connectionstring">Optional connection string</param>
        /// <returns>The object from the container when it exists, null otherwise.</returns>
        public T GetDataContext(string connectionstring = "") {

            T objectContext = null;

            if (HttpContext.Current.Items.Contains(DataContextKey))
                objectContext = (T)HttpContext.Current.Items[DataContextKey];

            return objectContext;
        }

        /// <summary>
        /// Stores the object in HttpContext.Current.Items.
        /// </summary>
        /// <param name="context">The Context object to store.</param>
        public void Store(T context) {

            if (HttpContext.Current.Items.Contains(DataContextKey))
                HttpContext.Current.Items[DataContextKey] = context;
            else
                HttpContext.Current.Items.Add(DataContextKey, context);
        }

        /// <summary>
        /// Clears the object from the container.
        /// </summary>
        public void Clear() {

            if (HttpContext.Current.Items.Contains(DataContextKey))
                HttpContext.Current.Items[DataContextKey] = null;
        }
    }
}
