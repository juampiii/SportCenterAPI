using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Represents a manager used to perform the diferent operations over the collection of T type in the Sport Center
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IManager<T> where T: class
    {
        /// <summary>
        /// Checks if the T type element exists
        /// </summary>
        /// <param name="id">The id of the element to Checks</param>
        /// <returns></returns>
        Task<bool> Exist(int id);

        /// <summary>
        /// Gets a list with all elements of T type from the Sport Center
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Gets the element with of T type with the requested Id from the Sport Center
        /// </summary>
        /// <param name="id">The id of the element to get</param>
        /// <returns>An element of T type with the requested Id</returns>
        Task<T> Get(int id);

        /// <summary>
        /// Delete the element of T type with the requested Id from the Sport Center
        /// </summary>
        /// <param name="id">The id of the element to delete</param>
        /// <returns>The element deleted</returns>
        Task<T> DeleteAsync(int id);

        /// <summary>
        /// Update the value of the element of T type with the requested Id from the Sport Center
        /// </summary>
        /// <param name="id">The id of the element to update</param>
        /// <param name="entity">The element updated element</param>
        /// <returns></returns>
        Task<T> Update(int id, T entity);

        /// <summary>
        /// Add a new element of T type to the Sport Center
        /// </summary>
        /// <param name="entity">The element to add</param>
        /// <returns>The added element</returns>
        Task<T> Add(T entity);
    }
}
