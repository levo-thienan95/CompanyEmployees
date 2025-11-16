using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services;
using CompanyEmployees.Core.Services.Abstractions;
using CompanyEmployees.Infrastructure.Persistence;
using CompanyEmployees.Infrastructure.Persistence.Repositories;
using LoggingService;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CompanyEmployees.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCros(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CrosPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }
    public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {

        });

    public static void ConfigureServices(this IServiceCollection services)
    {
        // register LoggerManager with the global Serilog Log.Logger instance
        services.AddSingleton<ILoggerManager>(provider => new LoggerManager(Log.Logger));
        services.AddScoped<ICompanyService, CompanyEmployees.Core.Services.CompanyService>();
        services.AddScoped<IEmployeeService, CompanyEmployees.Core.Services.EmployeeService>();
    }
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    public static void ConfigureServicesManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
    
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
}