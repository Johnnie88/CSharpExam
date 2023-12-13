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
    }
}
