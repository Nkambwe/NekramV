using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Nekram.Infrastructure;

namespace Nekram.Repositories {
    public class Repository<T> : IRepository<T, int>, IDisposable where T : EntityObject<int> {

        /// <summary>
        /// Finds an item by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the item in the database.</param>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns>The requested item when found, or null otherwise.</returns>
        public T FindById(int id, out string error) {
            error = string.Empty;
            T t = null;
            try {
                var items = ContextFactory.GetDataContext().Set<T>();
                t = items.Find(id);
            } catch (Exception ex) {
                error = ex.InnerException?.InnerException?.Message;
            }

            return t;
        }

        /// <summary>
        /// Finds an item by its unique ID.
        /// </summary>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <param name="id">The unique ID of the item in the database.</param>
        /// <param name="filter">An expression of additional properties to eager load. For example: m => m.Payments, m => m.Products.</param>
        /// <returns>The requested item when found, or null otherwise.</returns>
        public T FindById(out string error, int id, params Expression<Func<T, object>>[] filter) {
            return FindAll(out error, filter).SingleOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <returns>An IQueryable of the requested type T.</returns>
        public IQueryable<T> FindAll(out string error) {
            error = string.Empty;
            IQueryable<T> t = null;
            try {
                var items = ContextFactory.GetDataContext().Set<T>();
                t = items.AsQueryable();
            } catch (Exception ex) {
                error = ex.InnerException?.InnerException?.Message;
            }

            return t;
        }

        /// <summary>
        /// Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <param name="filter">An expression of additional properties to eager load. For example: m => m.Payments, m => m.Products.</param>
        /// <returns>An IQueryable of the requested type T.</returns>
        public IQueryable<T> FindAll(out string error, params Expression<Func<T, object>>[] filter) {

            error = string.Empty;

            IQueryable<T> items = null;
            try {
                items = ContextFactory.GetDataContext().Set<T>();

                if (filter != null)
                    items = filter.Aggregate(items, (current, property) => current.Include(property));

            } catch (Exception ex) {
                error = ex.InnerException?.InnerException?.Message;
            }

            return items;
        }

        /// <summary>
        /// Returns an IQueryable of items of type T.
        /// </summary>
        /// <param name="error">Error message in case something goes wrong</param>
        /// <param name="predicate">A predicate to limit the items being returned.</param>
        /// <param name="filter">An expression of additional properties to eager load. For example: m => m.Payments, m => m.Products.</param>
        /// <returns>An IEnumerable of the requested type T.</returns>
        public IEnumerable<T> FindAll(out string error, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] filter) {

            error = string.Empty;

            IQueryable<T> items = null;

            try {
                items = ContextFactory.GetDataContext().Set<T>();

                if (filter != null) {
                    var collection = filter.Aggregate(items,
                        (current, property) => current.Include(property));
                    items = collection.Where(predicate);
                }

            } catch (Exception ex) {
                error = ex.InnerException?.InnerException?.Message;
            }

            return items;
        }

        /// <summary>
        /// Adds an entity to the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be added.</param>
        /// <param name="error">Error message in case something goes wrong</param>
        public void Add(T entity, out string error) {
            error = string.Empty;

            try {
                ContextFactory.GetDataContext().Set<T>().Add(entity);
            } catch (Exception ex) {
                error = ex.InnerException?.InnerException?.Message;
            }
        }

        /// <summary>
        /// Removes an entity from the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be removed.</param>
        /// <param name="error">Error message in case something goes wrong</param>
        public void Remove(T entity, out string error) {
            error = string.Empty;

            try {
                ContextFactory.GetDataContext().Set<T>().Remove(entity);
            } catch (Exception ex) {
                error = ex.InnerException?.InnerException?.Message;
            }
        }

        /// <summary>
        /// Removes an entity from the underlying DbContext.
        /// </summary>
        /// <param name="id">The ID of the entity that should be removed.</param>
        /// <param name="error">Error message in case something goes wrong</param>
        public void Remove(int id, out string error) {

            var t = FindById(id, out error);
            if (t != null)
                Remove(t, out error);
        }

        /// <summary>
        /// Disposes the underlying data context.
        /// </summary>
        public void Dispose() {
            if (ContextFactory.GetDataContext() != null)
                ContextFactory.GetDataContext().Dispose();
        }
    }
}
