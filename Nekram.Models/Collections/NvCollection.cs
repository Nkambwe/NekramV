/* Class      :NvCollection
 * Description: Class servers as a base class for all collections in the application
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nekram.Models.Collections {
    public abstract class NvCollection < T > : Collection < T > {

        /// <summary>
        /// Default Constructor
        /// </summary>
        protected NvCollection()
            : base(new List<T>() ) {
            
        }

        protected NvCollection(IList<T> initialList)
            : base(initialList) {
            
        }

        protected NvCollection(NvCollection<T> newcollection)
            : base(newcollection) {
            
        }

        /// <summary>
        /// General sort method
        /// </summary>
        public void Sort() {
            var list = Items as List<T>;
            list?.Sort();
        }

        /// <summary>
        /// Sort a collection passed as an argument
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<T> comparer) {
            var list = Items as List<T>;
            list?.Sort(comparer);
        }

        public void AddRange(IEnumerable<T> collection) {

            if (collection == null) {
                throw new ArgumentNullException(nameof(collection), "The parameter collection is null.");
            }

            foreach (var item in collection) {
                Add(item);
            }
        }

    }
}
