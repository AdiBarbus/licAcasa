using System.Linq;
using Interns.Core;

namespace Interns.DataAccessLayer.Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        /// <summary>
        ///     Gets a list of all T items
        /// </summary>
        /// <returns> 
        ///     Returns a list of all T items
        /// </returns>
        IQueryable<T> GetAll();

        /// <summary>
        ///     Gets the item with the specified id
        /// </summary>
        /// <returns> The item with the id passed as the parameter </returns>
        T GetById(object id);//Func<T, bool> where, params Expression<Func<T, object>>[] predicate);

        /// <summary>
        ///     Inserts a new object in the T table
        /// </summary>
        /// <param name="item"></param>
        void Insert(T item);

        /// <summary>
        ///     Deletes the item with the id passed as the parameter
        /// </summary>
        void Delete(T item);

        /// <summary>
        ///     Updates the item with the new value passed as the parameter
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
    }
}
