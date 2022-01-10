using System.Collections.Generic;
using MicrofrontendServer.Domain;
using MicrofrontendServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicrofrontendServer.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsController : ControllerBase
    {
        #region Private Fields

        private readonly ILogger<RestaurantsController> logger;
        private readonly IRestaurantService restaurantService;

        #endregion

        #region Public Constructors

        public RestaurantsController(ILogger<RestaurantsController> logger, IRestaurantService restaurantService)
        {
            this.logger = logger;
            this.restaurantService = restaurantService;
        }

        #endregion

        #region Public Methods

        [HttpGet("Search")]
        public ActionResult<IEnumerable<Restaurant>> Search(string filter, string category, PriceRange? range)
        {
            logger.LogInformation("Restaurants.Search() accessed.");

            return Ok(restaurantService.SearchRestaurants(filter, category, range));
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(long id, bool withItems = false)
        {
            logger.LogInformation($"Restaurants.Get(id={id}, withItems={withItems}) accessed.");

            var restaurant = restaurantService.GetRestaurantById(id, withItems);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        #endregion
    }
}