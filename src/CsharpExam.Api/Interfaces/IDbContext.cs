namespace CsharpExam.Api.Interfaces
{
    using CsharpExam.Api.Entities;

    public interface IDbContext
    {
        ISet<OrderModel> Orders { get; set; }

        void AddOrder(OrderModel order);

        void RemoveOrder(OrderModel order);

        void UpdateOrder(OrderModel order);

        OrderModel GetOrderById(int Id);

        IEnumerable<OrderModel> GetOrders();

        void SaveChanges();

        void DeleteChanges();


    }
}