using Board.Api.Tests.Stubs;
using Board.AppServices.Contexts.Adverts.Interfaces;
using Board.AppServices.Contexts.Categories.Interfaces;
using Board.AppServices.Contexts.Users.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Board.Api.Tests
{
    public class TestWebAppFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // подменить IAdvertRepository
                var advertRepository = services.FirstOrDefault(x => x.ServiceType == typeof(IAdvertRepository));
                services.Remove(advertRepository);
                services.AddScoped<IAdvertRepository, AdvertRepositoryStub>();

                // подменить IUserRepository
                var userRepository = services.FirstOrDefault(x => x.ServiceType == typeof(IUserRepository));
                services.Remove(userRepository);
                services.AddScoped<IUserRepository, UserRepositoryStub>();

                // подменить ICategoryRepository
                var categoryRepository = services.FirstOrDefault(x => x.ServiceType == typeof(ICategoryRepository));
                services.Remove(categoryRepository);
                services.AddScoped<ICategoryRepository, CategoryRepositoryStub>();

                // подменить IDistributedCache
                //var distributedCaches = services.Where(x => x.ServiceType == typeof(IDistributedCache)).ToArray();
                //foreach (var distributedCache in distributedCaches)
                //{
                //    services.Remove(distributedCache);
                //}

                //services.AddDistributedMemoryCache();
            });

            base.ConfigureWebHost(builder);
        }
    }
}