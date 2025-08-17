using HarmancoolProductsService.Models.Data;
using HarmancoolProductsService.Models.Domain;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HarmancoolProductsService
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ConStr");

            // Add services to the container.


            //do not use this for Context class
            //for any other kind of dependencies add it this way


            //ontext obj
            builder.Services.AddDbContext<HarmanCoolProductsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped(typeof(ICoolProductsService),typeof(CoolProductsService));//has interface so two classes

            
            //builder.Services.AddScoped(typeof(HarmanCoolProductsDbContext)); //IoC inverse of conversion Configuration  one isntance per request
            // builder.Services.AddTransient(typeof(HarmanCoolProductsDbContext)); //IoC inverse of conversion Configuration for one call
            // builder.Services.AddSingleton(typeof(HarmanCoolProductsDbContext)); //IoC inverse of conversion Configuration for one instance for entire application




            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddOData();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger();//add the ui
                app.UseSwaggerUI();
            }

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
