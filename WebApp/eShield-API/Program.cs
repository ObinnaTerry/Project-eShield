using eShield.CoreData.Data.eShield;
using eShield.CoreData.Data.Repos;
using eShield.CoreData.Interfaces;
using eShield_API.DataService;
using Microsoft.EntityFrameworkCore;

namespace eShield_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("eShieldConnection") ?? throw new InvalidOperationException("Connection string 'eShieldConnection' not found.");

            builder.Services.AddDbContext<EShieldContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IProxyDataRepo, ProxyDataRepo>();
            builder.Services.AddScoped<ProxyDataRepo>();
            builder.Services.AddScoped<IExamCodeRepo, ExamCodeRepo>();
            builder.Services.AddScoped<IExamRepo, ExamRepo>();
            builder.Services.AddScoped<ExamDataService>();

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