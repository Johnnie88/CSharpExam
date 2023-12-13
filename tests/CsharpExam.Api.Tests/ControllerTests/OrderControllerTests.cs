namespace CsharpExam.Api.ControllersTests
{
    using CsharpExam.Api.Controllers;
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;
    using Dapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class OrderControllerTests
    {
        private Mock<IOrderBusiness> orderBusinessMock =
            new Mock<IOrderBusiness>();
        private OrderController orderController;
        private Mock<ILogger<OrderController>> loggerMock =
            new Mock<ILogger<OrderController>>();

        [TestInitialize]
        public async Task Setup()
        {
            orderBusinessMock = new Mock<IOrderBusiness>();
            loggerMock = new Mock<ILogger<OrderController>>();
            orderController = new OrderController(loggerMock.Object, orderBusinessMock.Object);
        }

        /// <summary>
        /// Defines the GetOrderByIdAsyncTest.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetOrderByIdAsyncTest()
        {
            // Arrange
            int orderId = 1;
            decimal totalAmount = 100;

            var expectedOrder = new OrderModel { Id = orderId, TotalAmount = totalAmount };

            await DeleteOrderDataBaseAsync();

            await AddOrderDataBaseAsync();

            orderBusinessMock.Setup(b => b.GetOrderByIdAsync(orderId)).ReturnsAsync(expectedOrder);

            // Act
            var result = await orderController.GetOrderByIdAsync(orderId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.IsTrue((result.Result as OkObjectResult).Value is OrderModel);
            Assert.AreEqual((result.Result as OkObjectResult).StatusCode, 200);
            Assert.AreEqual(((result.Result as OkObjectResult).Value as OrderModel).Id, orderId);
            Assert.AreEqual(((result.Result as OkObjectResult).Value as OrderModel).TotalAmount, totalAmount);
        }

        private async Task AddOrderDataBaseAsync()
        {
            var order = new OrderModel
            {
                Id = 1,
                TotalAmount = 100
            };

            var connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=order;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SET IDENTITY_INSERT [Order] ON; INSERT INTO [Order] (Id, TotalAmount) VALUES (@Id, @TotalAmount); SET IDENTITY_INSERT [Order] OFF;";

                await connection.ExecuteAsync(query, order);
            }
        }

        private async Task DeleteOrderDataBaseAsync()
        {
            var connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=order;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM [Order] WHERE Id = 1";

                await connection.ExecuteAsync(query);
            }
        }
    }
}