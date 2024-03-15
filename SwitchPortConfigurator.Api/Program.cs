using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using SwitchPortConfigurator.Api.AutoMapperProfiles;
using SwitchPortConfigurator.Api.Repository.Db;
using SwitchPortConfigurator.Api.Repository.Db.Implementations;
using SwitchPortConfigurator.Api.Repository.Interfaces;
using SwitchPortConfigurator.Api.SwitchService.Interfaces;
using SS = SwitchPortConfigurator.Api.SwitchService.Default.Implementations.SwitchService;

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

            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                .AddNegotiate();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });


            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

            builder.Services.AddDbContext<RepositoryDbContext>(opts =>
                opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddScoped<ISwitchRepository, SwitchRepository>();
            builder.Services.AddScoped<ISwitchService, SS>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}