using System.Linq.Expressions;
using Core.Models;

namespace Data.Interfaces {
    /// <summary>
    /// Basic operations with data in Database
    /// </summary>
    /// <typeparam name="T">Class of database entity</typeparam>
    public interface IRepository<T> where T : AbstractModel{

        /// <summary>
        /// Getting Data from database
        /// </summary>
        /// <returns>All objects of required type from database</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Getting Data from database with specified condition
        /// </summary>
        /// <param name="expression">conditions for requested data</param>
        /// <returns>Objects, which satisfy conditions</returns>
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        
        /// <summary>
        /// Getting Object with specified Id
        /// </summary>
        /// <param name="id">Id of requested object</param>
        /// <returns>Object with specified Id</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Add New Entity to database.
        /// </summary>
        /// <param name="item">Entity which should be added to database</param>
        /// <returns>Created entity</returns>
        Task<T> CreateAsync(T item);

        /// <summary>
        /// Delete entity with specified Id from Database
        /// </summary>
        /// <param name="id">Id of entity which should be deleted</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Check if entity with specified Id exist in database
        /// </summary>
        /// <param name="id">Id of entity to check</param>
        /// <returns>True if entity exists in database, false otherwise</returns>
        Task<bool> ExistsAsync(Guid id);

        /// <summary>
        /// Saves Changes made to database;
        /// </summary>
        Task SaveChangesAsync();
    }
}
