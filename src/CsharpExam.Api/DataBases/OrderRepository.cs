namespace CsharpExam.Api.DataBases
{
    using System.Threading.Tasks;
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    using Microsoft.Data.SqlClient;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="OrderRepository" />.
    /// </summary>
    public class OrderRepository : IRepositoryBase<OrderModel>
    {
        private readonly IConfigurationSettings _configurationSettings;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(IConfigurationSettings configuration,
            ILogger<OrderRepository> logger
            )
        {
            _logger = logger;
            _configurationSettings = configuration;
        }

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<OrderModel> GetAsync(int Id)
        {
            _logger.LogInformation($"GetAsync {Id}");

            using (var connection = new SqlConnection(_configurationSettings.ConnectionStrings.DefaultConnection
            ))
            {
                var query = "SELECT * FROM [Order] WHERE Id = @Id";

                var result = await connection.QueryFirstOrDefaultAsync<OrderModel>(query, new { Id });

                return result;
            }
        }

        public Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}