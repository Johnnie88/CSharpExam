namespace CsharpExam.Api.ControllersTests
{
    using CsharpExam.Api.Business;
    using CsharpExam.Api.Controllers;
    using CsharpExam.Api.Interfaces;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;

    /// <summary>
    /// Order controller tests.
    /// </summary>
    [TestFixture()]
    public class OrderControllerTests
    {
        private ILogger<OrderController> _logger;
        private IOrderBusiness _orderBusiness;

        public OrderControllerTests(
            IOrderBusiness orderBusiness,
            ILogger<OrderController> logger)
        {
            _orderBusiness = orderBusiness;
            _logger = logger;
        }

        /// <summary>
        /// GetOrderByIdAsync retrieves order by id.
        /// </summary>
        [Test()]
        public async Task GetOrderByIdAsync_RetrievesOrderById()
        {
           // Arrange
           _orderBusiness = new OrderBusiness();
           var controller = new OrderController(_logger, _orderBusiness);

           // Act
           var result = await controller.GetOrderByIdAsync(1);

           // Assert
           Assert.AreEqual("Order 1", result.Value);
       }
    }
}