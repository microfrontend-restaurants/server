using System.Collections.Generic;
using MicrofrontendServer.DAL;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.Services
{
    public class RestaurantService : IRestaurantService
    {
        #region Private Fields

        private readonly ICategoryRepository categoryRepository;
        private readonly IRestaurantItemRepository restaurantItemRepository;
        private readonly IRestaurantRepository restaurantRepository;

        #endregion

        #region Public Constructors

        public RestaurantService(
            IRestaurantRepository restaurantRepository,
            IRestaurantItemRepository restaurantItemRepository,
            ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            this.restaurantRepository = restaurantRepository;
            this.restaurantItemRepository = restaurantItemRepository;
        }

        #endregion

        #region Public Methods

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.Get();
        }

        public Restaurant GetRestaurantById(long id, bool withItems)
        {
            var restaurant = restaurantRepository.GetById(id);

            if (withItems)
            {
                restaurant.Items = restaurantItemRepository.GetByRestaurantId(id);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> SearchRestaurants(string filter, string category, PriceRange? range)
        {
            return restaurantRepository.Search(filter, category, range);
        }

        #endregion
    }
}