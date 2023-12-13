using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.APIs.Interfaces;

namespace src.APIs.Controllers

    [ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    private readonly IOrderBusiness _orderBusiness;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Returns the total amount of the order.
    /// </summary>
    /// <typeparam name="TotalAmount"></typeparam>
    /// <param name=""></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<TotalAmount> GetTotalAmountAsync(
        int id)
    {
        try
        {
            var result = await _orderBusiness.OrderResultAsync(id);

            

        }
        catch (System.Exception ex)
        {
            throw new System.Exception(ex.Message);
        }

        return null;
    }
    