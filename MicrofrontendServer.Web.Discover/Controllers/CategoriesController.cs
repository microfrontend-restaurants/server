using System.Collections.Generic;
using MicrofrontendServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicrofrontendServer.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        #region Private Fields

        private readonly ILogger<CategoriesController> logger;
        private readonly IRestaurantService restaurantService;

        #endregion

        #region Public Constructors

        public CategoriesController(ILogger<CategoriesController> logger, IRestaurantService restaurantService)
        {
            this.logger = logger;
            this.restaurantService = restaurantService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            logger.LogInformation("Categories.Get() accessed.");

            return Ok(restaurantService.GetCategories());
        }

        #endregion
    }
}