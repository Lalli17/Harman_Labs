using HarmanCoolProductsService.Models.Data;
using HarmanCoolProductsService.Models.Domain;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HarmanCoolProductsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string connectionString = builder.Configuration.GetConnectionString("ConStr");

            builder.Services.AddDbContext<HarmansCoolProductsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped(typeof(ICoolProductsService), typeof(CoolProductsService));

            //builder.Services.AddScoped(typeof(HarmansCoolProductsDbContext)); // IoC configuration
            //builder.Services.AddTransient(typeof(HarmansCoolProductsDbContext)); // IoC configuration
            //builder.Services.AddSingleton(typeof(HarmansCoolProductsDbContext)); // IoC configuration


            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddOData(); // for OData

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Register Swagger
            builder.Services.AddEndpointsApiExplorer(); // required
            builder.Services.AddSwaggerGen();           // required

            // create CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger();
                app.UseSwaggerUI(); // optional customization below
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(e =>
            {
                e.EnableDependencyInjection();
                e.Select().OrderBy().Filter().Count().MaxTop(100).SkipToken();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
