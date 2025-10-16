using AutoMapper;
using Board.AppServices.Contexts.Adverts.Repository;
using Board.AppServices.Contexts.Adverts.Services;
using Board.Infrastructure.ComponentRegistrar.MapProfiles;
using Board.Infrastructure.DataAccess.Contexts.Adverts.Repositories;
using Board.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Board.Infrastructure.ComponentRegistrar
{
    public static class ComponentRegistrar
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertService, AdvertService>();
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdvertRepository, AdvertRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AdvertProfile>();
            });
            config.AssertConfigurationIsValid();

            return config;
        }
    }
}
