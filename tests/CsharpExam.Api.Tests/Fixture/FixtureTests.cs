namespace CsharpExam.Api.UnitTests.Fixture
{
    using System.Threading.Tasks;
    using CsharpExam.Api.Interfaces;
    using Microsoft.Data.SqlClient;

    public class FixtureTests
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private IConfigurationSettings configurationSettings;

        public FixtureTests(IConfigurationSettings configurationSettings)
        {
            this.configurationSettings = configurationSettings;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        public Task CreateDbAsync()
        {
            var connectionString = configurationSettings.ConnectionStrings.DefaultConnection;
            var sqlConnection = new SqlConnection(connectionString);
            var sql = "CREATE DATABASE CsharpExamTests";
            var sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        public Task DropDbAsync()
        {
            var connectionString = configurationSettings.ConnectionStrings.DefaultConnection;
            var sqlConnection = new SqlConnection(connectionString);
            var sql = "DROP DATABASE CsharpExamTests";
            var sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return Task.CompletedTask;
        }
    }
}
