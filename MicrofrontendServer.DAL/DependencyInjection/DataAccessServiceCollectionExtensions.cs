using MicrofrontendServer.DAL.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace MicrofrontendServer.DAL.DependencyInjection
{
    public static class DataAccessServiceCollectionExtensions
    {
        #region Public Methods

        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddSingleton<IRestaurantItemRepository, FakeRestaurantItemRepository>();
            services.AddSingleton<IRestaurantRepository, FakeRestaurantRepository>();
            services.AddSingleton<IOrderItemRepository, FakeOrderItemRepository>();
            services.AddSingleton<IOrderRepository, FakeOrderRepository>();

            return services;
        }

        #endregion
    }
}