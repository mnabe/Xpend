using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExpenseTests")]
[assembly: InternalsVisibleTo("expense.WebApi")]

namespace expense.Persistence
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExpenseDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ExpenseConnection")));
            return services;
        }
    }
}
