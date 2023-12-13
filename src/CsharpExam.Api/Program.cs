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

            IConfigurationSettings configurationSettings = builder.Configuration.Get<ConfigurationSettings>();

            builder.Services.AddSingleton<IConfigurationSettings>(configurationSettings);

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
