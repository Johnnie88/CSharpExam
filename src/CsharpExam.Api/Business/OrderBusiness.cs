namespace CsharpExam.Api.Business
{
    using System.Threading.Tasks;
    using CsharpExam.Api.DataBases;
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;

    /// <summary>
    /// Defines the <see cref="OrderBusiness" />.
    /// </summary>
    public class OrderBusiness : IOrderBusiness
    {
        /// <summary>
        /// Defines the _OrderRepository.
        /// </summary>
        private OrderRepository _OrderRepository;

        public OrderBusiness(OrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }

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
                var result = await _OrderRepository.GetAsync(Id);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
