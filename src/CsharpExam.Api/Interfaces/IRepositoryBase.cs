namespace CsharpExam.Api.Interfaces
{
    /// <summary>
    /// The repository base.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> 
        where T : class
    {
        /// <summary>
        /// Gets the order by id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetAsync(int Id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Adds the specified order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task AddAsync(T order);

        /// <summary>
        /// Updates the specified order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task UpdateAsync(T order);

        /// <summary>
        /// Deletes the specified order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task DeleteAsync(T order);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
