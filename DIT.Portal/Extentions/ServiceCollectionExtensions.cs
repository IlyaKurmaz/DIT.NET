using DIT.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DIT.Portal.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection
                .AddDbContext<DitContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

            return serviceCollection;
        }
    }
}
