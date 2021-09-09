using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrofrontendServer.Domain;
using MicrofrontendServier.Resources;

namespace MicrofrontendServer.DAL.Mock
{
    public class FakeRestaurantRepository : IRestaurantRepository
    {

        private static IEnumerable<Restaurant> products;

        public FakeRestaurantRepository()
        {
            products = new List<Restaurant>
            {
                new Restaurant { Id = 1, Rating = 4.73, Name = "Gasthaus zum goldenen Stern", Image = Resources.ImageRestaurant1, Location = "Eferding", Categories = new List<string> { "Chinese" } },
                new Restaurant { Id = 2, Rating = 3.5, Name = "Rondo", Location = "Linz", Image = Resources.ImageRestaurant2, Categories = new List<string> { "Fusion Kitchen", "Vietnamese", "Chinese" } },
                new Restaurant { Id = 3, Rating = 3.5, Name = "Ramen House", Location = "Linz", Image = Resources.ImageRestaurant3, Categories = new List<string> { "Japanese" } },
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return products;
        }

        public Restaurant GetById(long id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
