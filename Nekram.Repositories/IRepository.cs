/* Class      : IRepository
 * Description: Defines various methods for working with data in the system.
 * Create By  : Nkambwe Mark
 * Created On : 24-12-2019
 */


using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Nekram.Repositories {
    // ReSharper disable once InconsistentNaming
    public interface IRepository<T, K> where T : class {

        /// <summary>
        /// Find entity based on parameter
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <param name="error">Error Message in case something goes wrong</param>
        /// <returns></returns>
        T FindById(int id, out string error);

        /// <summary>
        /// Finds an item by its unique ID.
        /// </summary>
        /// <param name="error">Error Message in case something goes wrong</param>
        /// <param name="id">The unique ID of the item in the database.</param>
        /// <param name="filter">An expression of additional properties to eager load. For example: m => m.Payments, m => m.Dues.</param>
        /// <returns>The requested item when found, or null otherwise.</returns>
        T FindById(out string error, K id, params Expression<Func<T, object>>[] filter);

        /// <summary>
        /// Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="error">Error Message in case something goes wrong</param>
        /// <param name="filter">An expression of additional properties to eager load. For example: m => m.Payments, m => m.Dues.</param>
        /// <returns>An IQueryable of the requested type T.</returns>
        IQueryable<T> FindAll(out string error, params Expression<Func<T, object>>[] filter);

        /// <summary>
        /// Returns an IQueryable of items of type T.
        /// </summary>
        /// <param name="error">Error Message in case something goes wrong</param>
        /// <param name="predicate">A predicate to limit the items being returned.</param>
        /// <param name="filter">An expression of additional properties to eager load. For example: m => m.Payments, m => m.Dues.</param>
        /// <returns>An IEnumerable of the requested type T.</returns>
        IEnumerable<T> FindAll(out string error, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] filter);

        /// <summary>
        /// Adds an entity to the underlying collection.
        /// </summary>
        /// <param name="entity">The entity that should be added.</param>
        /// <param name="error">Error Message in case something goes wrong</param>
        void Add(T entity, out string error);

        /// <summary>
        /// Removes an entity from the underlying collection.
        /// </summary>
        /// <param name="entity">The entity that should be removed.</param>
        /// <param name="error">Error Message in case something goes wrong</param>
        void Remove(T entity, out string error);

        /// <summary>
        /// Removes an entity from the underlying collection.
        /// </summary>
        /// <param name="id">The ID of the entity that should be removed.</param>
        /// <param name="error">Error Message in case something goes wrong</param>
        void Remove(K id, out string error);
    }
}
