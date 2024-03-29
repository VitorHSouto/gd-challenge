
using FluentMigrator.Runner;
using gd_api.Controllers;
using gd_api.Domain.Helpers;
using gd_api.Domain.Repositories;
using gd_api.Domain.Services;
using gd_api.Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace gd_api
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

            var connection = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(connection));

            ConfigureJWTAuthentication(builder);
            var serviceProvider = CreateServices(builder);
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            AddServices(builder);
            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            app.MapControllers();
            app.Run();
        }
        private static IServiceProvider CreateServices(WebApplicationBuilder builder)
        {
            var connections = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connections?.DataBase)
                    .ScanIn(typeof(Program).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        //TODO: Remover declara��o de servi�os
        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<FileService>();
            builder.Services.AddScoped<FileRepository>();

            builder.Services.AddScoped<AddressService>();
            builder.Services.AddScoped<AddressRepository>();

            builder.Services.AddScoped<CompanyService>();
            builder.Services.AddScoped<CompanyRepository>();

            builder.Services.AddScoped<LoginController>();
            builder.Services.AddScoped<LoginService>();

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<UserRepository>();

            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<ProductRepository>();
        }

        private static void ConfigureJWTAuthentication(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Context.JwtSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}