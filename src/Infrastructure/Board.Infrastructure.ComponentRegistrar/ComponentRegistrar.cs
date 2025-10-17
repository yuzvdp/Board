using AutoMapper;
using Board.AppServices.Contexts.Adverts.Interfaces;
using Board.AppServices.Contexts.Adverts.Services;
using Board.AppServices.Contexts.Categories.Interfaces;
using Board.AppServices.Contexts.Categories.Services;
using Board.AppServices.Contexts.Users.Interfaces;
using Board.AppServices.Contexts.Users.Services;
using Board.Infrastructure.ComponentRegistrar.MapProfiles;
using Board.Infrastructure.DataAccess.Contexts.Adverts.Repositories;
using Board.Infrastructure.DataAccess.Contexts.Categories.Repositories;
using Board.Infrastructure.DataAccess.Contexts.Users.Repositories;
using Board.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Board.Infrastructure.ComponentRegistrar
{
    public static class ComponentRegistrar
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertService, AdvertService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdvertRepository, AdvertRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AdvertProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<CategoryProfile>();
            });
            config.AssertConfigurationIsValid();

            return config;
        }
    }
}
