namespace CsharpExam.Api.Controllers
{
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        private IOrderBusiness _IOrderBusiness;


        public OrderController(ILogger<OrderController> logger,
            IOrderBusiness orderBusiness)
        {
            _IOrderBusiness = orderBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(OrderModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderModel>> GetOrderByIdAsync(int Id)
        {
            _logger.LogInformation($"GetOrderByIdAsync {Id}");

            var result = await _IOrderBusiness.GetOrderByIdAsync(Id);

            return Ok($"Order {Id}");
        }
    }
}
