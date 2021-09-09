using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL.Mock
{
    public class FakeRestaurantItemRepository : IRestaurantItemRepository
    {
        private IEnumerable<RestaurantItem> items;

        public FakeRestaurantItemRepository()
        {
            items = new List<RestaurantItem>()
            {
                new RestaurantItem { Id = 1, Name = "Item 1", ParentId = 1, Price = 9.90M },
                new RestaurantItem { Id = 2, Name = "Item 2", ParentId = 1, Price = 4.50M },
                new RestaurantItem { Id = 3, Name = "Item 3", ParentId = 1, Price = 12.10M },
                new RestaurantItem { Id = 4, Name = "Item 1", ParentId = 2, Price = 9.90M },
                new RestaurantItem { Id = 5, Name = "Item 2", ParentId = 2, Price = 4.50M },
                new RestaurantItem { Id = 6, Name = "Item 3", ParentId = 2, Price = 12.10M },
                new RestaurantItem { Id = 7, Name = "Item 1", ParentId = 3, Price = 9.90M },
                new RestaurantItem { Id = 8, Name = "Item 2", ParentId = 3, Price = 4.50M },
                new RestaurantItem { Id = 9, Name = "Item 3", ParentId = 3, Price = 12.10M }
            };
        }

        public IEnumerable<RestaurantItem> GetByIds(long[] ids)
        {
            return items.Where(i => ids.Contains(i.Id));
        }

        public IEnumerable<RestaurantItem> GetByRestaurantId(long restaurantId)
        {
            return items.Where(i => i.ParentId == restaurantId);
        }
    }
}
