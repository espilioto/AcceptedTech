using acceptedTech.Application.Common.Interfaces;
using acceptedTech.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace acceptedTech.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("db"))
            );

            services.AddScoped<IMatchesRepository, MatchesRepository>();
            services.AddScoped<IMatchOddsRepository, MatchOddsRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
