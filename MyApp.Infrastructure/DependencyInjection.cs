using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Interfaces;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=CPC-shiva-FJSDR;Database=EFCoreDB2;Trusted_Connection=True;TrustServerCertificate=True;"));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
