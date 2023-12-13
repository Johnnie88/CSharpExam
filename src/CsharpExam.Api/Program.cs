namespace CsharpExam.Api
{
    using CsharpExam.Api.Business;
    using CsharpExam.Api.DataBases;
    using CsharpExam.Api.Entities;
    using CsharpExam.Api.Interfaces;
    using CsharpExam.Api.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add the app settings values considering the environment variables
            var conf = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("conf/appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IConfigurationSettings>(
                conf.GetSection("ConfigurationSettings")
                .Get<ConfigurationSettings>());

            // add the database context
            builder.Services.AddSingleton<IDbContext, DbContext>();

            builder.Services.AddSingleton<OrderRepository, OrderRepository>();
            builder.Services.AddSingleton<IOrderBusiness, OrderBusiness>();
            builder.Services.AddTransient<IRepositoryBase<OrderModel>, OrderRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
