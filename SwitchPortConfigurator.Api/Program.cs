using Microsoft.EntityFrameworkCore;
using SwitchPortConfigurator.Api.AutoMapperProfiles;
using SwitchPortConfigurator.Api.Repository.Db;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.Interfaces;
using SwitchPortConfigurator.Api.Repository.Db.ErrorHandlerDb.SqlErrorHandler.Implementations;
using SwitchPortConfigurator.Api.Repository.Db.Implementations;
using SwitchPortConfigurator.Api.Repository.Interfaces;

namespace SwitchPortConfigurator.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<RepositoryDtoProfile>());

            builder.Services.AddDbContext<RepositoryDbContext>(opts => 
                opts.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddSingleton<IErrorHandlerDb, ErrorHandlerDb>();
            builder.Services.AddScoped<IAreaRepository, AreaRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            builder.Services.AddScoped<IModelRepository, ModelRepository>();
            builder.Services.AddScoped<ISwitchRepository, SwitchRepository>();

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