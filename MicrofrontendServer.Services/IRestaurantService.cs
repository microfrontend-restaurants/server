using System.Collections.Generic;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.Services
{
    public interface IRestaurantService
    {
        #region Public Methods

        public IEnumerable<Category> GetCategories();

        public Restaurant GetRestaurantById(long id, bool withItems);

        IEnumerable<RestaurantItem> GetRestaurantItems(long[] ids);

        public IEnumerable<Restaurant> SearchRestaurants(string filter, string category, PriceRange? range);

        #endregion
    }
}