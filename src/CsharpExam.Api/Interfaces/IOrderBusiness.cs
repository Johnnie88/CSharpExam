namespace CsharpExam.Api.Interfaces
{
    using CsharpExam.Api.Entities;

    public interface IOrderBusiness
    {
        Task<OrderModel> GetOrderByIdAsync(int Id);

    }
}
