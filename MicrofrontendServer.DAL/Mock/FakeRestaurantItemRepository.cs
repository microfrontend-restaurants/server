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
                new RestaurantItem { Id = 1, Name = "Schweinefleisch Süß-Sauer", ParentId = 1, Price = 9.90M, AllergyInformation = "A,C" },
                new RestaurantItem { Id = 2, Name = "Gebratene Nudeln mit Gemüse", ParentId = 1, Price = 4.50M, AllergyInformation = "A,C" },
                new RestaurantItem { Id = 3, Name = "Acht Schätze", ParentId = 1, Price = 12.10M, AllergyInformation = "A,C" },
                new RestaurantItem { Id = 4, Name = "Schnitzel mit Reis und Kartoffeln", ParentId = 2, Price = 9.90M, AllergyInformation = "A,C" },
                new RestaurantItem { Id = 5, Name = "Bowl mit Lachs und Gemüse", ParentId = 2, Price = 4.50M, AllergyInformation = "A,C" },
                new RestaurantItem { Id = 6, Name = "Burger mit Rindfleisch und Süßkartoffelpommes", ParentId = 2, Price = 12.10M, AllergyInformation = "A,C" },
                new RestaurantItem { Id = 7, Name = "Miso Ramen mit Rindfleisch", ParentId = 3, Price = 9.90M, AllergyInformation = "A,C" },
                new RestaurantItem { Id = 8, Name = "Tonkotsu Ramen Vegetarisch", ParentId = 3, Price = 4.50M, AllergyInformation = "A,C" },
                new RestaurantItem { Id = 9, Name = "Shio Ramen", ParentId = 3, Price = 12.10M, AllergyInformation = "A,C" }
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
