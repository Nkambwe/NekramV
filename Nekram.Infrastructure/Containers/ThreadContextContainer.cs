using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Threading;


namespace Nekram.Infrastructure.Containers {

    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    public class ThreadContextContainer<T> : IContextContainer<T> where T : class {

        protected static readonly Hashtable StoredContexts = new Hashtable();

        /// <summary>
        /// Returns an object from the container when it exists. Returns null otherwise.
        /// </summary>
        /// <param name="connectionstring">Optional connection string</param>
        /// <returns>The object from the container when it exists, null otherwise.</returns>
        public T GetDataContext(string connectionstring = "") {
            T context = null;

            if (StoredContexts.Contains(GetThreadName())) {
                context = (T)StoredContexts[GetThreadName()];
            }
            return context;
        }

        /// <summary>
        /// Stores the object in the hashtable indexed by the thread's name.
        /// </summary>
        /// <param name="objectContext">The object to store.</param>
        public void Store(T objectContext) {

            if (StoredContexts.Contains(GetThreadName())) {
                StoredContexts[GetThreadName()] = objectContext;
            } else {
                StoredContexts.Add(GetThreadName(), objectContext);
            }
        }

        /// <summary>
        /// Clears the object from the container.
        /// </summary>
        public void Clear() {
            if (StoredContexts.Contains(GetThreadName())) {
                StoredContexts[GetThreadName()] = null;
            }
        }

        private static string GetThreadName() {

            if (string.IsNullOrEmpty(Thread.CurrentThread.Name)) {
                Thread.CurrentThread.Name = Guid.NewGuid().ToString();
            }

            return Thread.CurrentThread.Name;
        }
    }

}
