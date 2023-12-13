namespace CsharpExam.Api.DataBases
{
    using System.Threading.Tasks;
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    using Microsoft.Data.SqlClient;

    public class OrderRepository : IRepositoryBase<OrderModel>
    {
        private IConfiguration _configuration;
        private ILogger<OrderRepository> _logger;

        public OrderRepository(IConfiguration configuration,
            ILogger<OrderRepository> logger
            )
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OrderModel> GetAsync(int Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = "SELECT * FROM Orders WHERE Id = @Id";

                var result = await connection.QueryFirstOrDefaultAsync<OrderModel>(query, new { Id });

                return result;
            }
        }
    }
}