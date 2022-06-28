using CompanyEmployees.BusinessLayer.Services;
using CompanyEmployees.BusinessLayer.Services.ClientServ;
using CompanyEmployess.DAL;
using CompanyEmployess.DAL.Repositories;
using CompanyEmployess.DAL.Repositories.ClientRepo;
using CompanyEmployess.DAL.Repositories.CompanyRepo;
using CompanyEmployess.DAL.Repositories.EmployeeRepo;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("CompanyEmployees")));

        public static void ConfigureExternalClientContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ExternalClientContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("externalClientConnection"), b => b.MigrationsAssembly("CompanyEmployees")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
