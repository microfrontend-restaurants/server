using System;
using System.Collections.Generic;
using System.Linq;
using MicrofrontendServer.Domain;
using MicrofrontendServier.Resources;

namespace MicrofrontendServer.DAL.Mock
{
    public class FakeRestaurantRepository : IRestaurantRepository
    {
        #region Private Fields

        private static IEnumerable<Restaurant> products;

        #endregion

        #region Public Constructors

        public FakeRestaurantRepository()
        {
            products = new List<Restaurant>
            {
                new Restaurant { Id = 1, Rating = 4.73, PriceRange = PriceRange.Cheap, Name = "Gasthaus zum goldenen Stern", Image = Resources.ImageRestaurant1, Location = "Eferding", Categories = new List<string> { "Chinese" } },
                new Restaurant { Id = 2, Rating = 3.5, PriceRange = PriceRange.Normal, Name = "Rondo", Location = "Linz", Image = Resources.ImageRestaurant2, Categories = new List<string> { "Fusion Kitchen", "Vietnamese", "Chinese" } },
                new Restaurant { Id = 3, Rating = 3.5, PriceRange = PriceRange.Expensive, Name = "Ramen House", Location = "Linz", Image = Resources.ImageRestaurant3, Categories = new List<string> { "Japanese" } },
            };
        }

        #endregion

        #region Public Methods

        public Restaurant GetById(long id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Restaurant> Search(string filter, string category, PriceRange? priceRange)
        {
            return products.Where(p =>
                (string.IsNullOrEmpty(filter) || p.Name.ToLower().Contains(filter.ToLower())) &&
                (string.IsNullOrEmpty(category) || p.Categories.Contains(category)) &&
                (!priceRange.HasValue || p.PriceRange.Equals(priceRange.Value))
            );
        }

        #endregion
    }
}