using System.Collections.Generic;
using MicrofrontendServer.DAL;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.Services
{
    public class RestaurantService : IRestaurantService
    {
        #region Private Fields

        private readonly IRestaurantRepository restaurantRepository;
        private readonly IRestaurantItemRepository restaurantItemRepository;

        #endregion

        #region Public Constructors

        public RestaurantService(IRestaurantRepository restaurantRepository, IRestaurantItemRepository restaurantItemRepository)
        {
            this.restaurantRepository = restaurantRepository;
            this.restaurantItemRepository = restaurantItemRepository;
        }

        #endregion

        #region Public Methods

        public Restaurant GetRestaurantById(long id, bool withItems)
        {
            var restaurant = restaurantRepository.GetById(id);

            if(withItems)
            {
                restaurant.Items = restaurantItemRepository.GetByRestaurantId(id);
            }

            return restaurant;
        }

        public IEnumerable<RestaurantItem> GetRestaurantItems(long[] ids)
        {
            return restaurantItemRepository.GetByIds(ids);
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return restaurantRepository.GetAll();
        }

        #endregion
    }
}