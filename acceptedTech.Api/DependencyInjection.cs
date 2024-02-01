using acceptedTech.Infrastructure.Converters;

namespace acceptedTech.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                    options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
                });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddProblemDetails();
            
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
