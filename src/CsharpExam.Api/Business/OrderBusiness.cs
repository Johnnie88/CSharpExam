namespace CsharpExam.Api.Business
{
    using System.Threading.Tasks;
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;

    public class OrderBusiness : IOrderBusiness
    {
        /// <summary>
        /// Gets the order by id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<OrderModel> GetOrderByIdAsync(int Id)
        {
            try
            {
                var result = await Task.FromResult(new OrderModel
                {
                    Id = Id,
                    TotalAmount = 100
                });

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
