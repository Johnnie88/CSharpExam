namespace CsharpExam.Api.DataBases
{
    using System.Collections.Generic;
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;

    public class DbContext : IDbContext
    {
        public ISet<OrderModel> Orders { get; set; }

        public DbContext()
        {
            Orders = new HashSet<OrderModel>();
        }

        public void AddOrder(OrderModel order)
        {
            Orders.Add(order);
        }

        public void RemoveOrder(OrderModel order)
        {

            Orders.Remove(order);
        }

        public void UpdateOrder(OrderModel order)
        {
            Orders.Remove(order);
            Orders.Add(order);
        }

        public OrderModel GetOrderById(int Id)
        {
            foreach (var order in Orders)
            {
                if (order.Id == Id)
                {
                    return order;
                }
            }

            return null;
        }

        public IEnumerable<OrderModel> GetOrders()
        {
            return Orders;
        }

        public void SaveChanges()
        {
            // Save changes to database
        }

        public void DeleteChanges()
        {
            Orders.Clear();
        }
    }
}
