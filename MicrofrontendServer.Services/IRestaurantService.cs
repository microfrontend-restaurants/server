using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.Services
{
    public interface IRestaurantService
    {
        public IEnumerable<Restaurant> GetRestaurants();

        public Restaurant GetRestaurantById(long id, bool withItems);
        IEnumerable<RestaurantItem> GetRestaurantItems(long[] ids);
    }
}
