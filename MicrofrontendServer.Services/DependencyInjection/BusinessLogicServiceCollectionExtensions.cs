using Microsoft.Extensions.DependencyInjection;

namespace MicrofrontendServer.Services.DependencyInjection
{
    public static class BusinessLogicServiceCollectionExtensions
    {
        #region Public Methods

        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

        #endregion
    }
}