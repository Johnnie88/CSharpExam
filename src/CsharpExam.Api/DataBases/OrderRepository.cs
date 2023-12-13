namespace CsharpExam.Api.DataBases
{
    using System.Threading.Tasks;
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    using Microsoft.Data.SqlClient;

    /// <summary>
    /// Defines the <see cref="OrderRepository" />.
    /// </summary>
    public class OrderRepository : IRepositoryBase<OrderModel>
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(IConfiguration configuration,
            ILogger<OrderRepository> logger
            )
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OrderModel> GetAsync(int Id)
        {
            _logger.LogInformation($"GetAsync {Id}");

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = "SELECT * FROM [Order] WHERE Id = @Id";

                var result = await connection.QueryFirstOrDefaultAsync<OrderModel>(query, new { Id });

                return result;
            }
        }
    }
}