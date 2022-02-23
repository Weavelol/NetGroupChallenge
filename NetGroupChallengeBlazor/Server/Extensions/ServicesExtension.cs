using Microsoft.Extensions.DependencyInjection;
using Data.Interfaces;
using Data.Repositories;
using Services.Interfaces;
using Services.Services;


namespace NetGroupChallengeBlazor.Server.Extensions {
    public static class ServicesExtension {
        public static void ConfigureRepositories(this IServiceCollection services) {
            services.AddTransient<IStoragesRepository, StoragesRepository>();
            services.AddTransient<IItemsRepository, ItemsRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services) {
            services.AddTransient<IStoragesService, StoragesService>();
            services.AddTransient<IItemsService, ItemsService>();
        }
    }
}
