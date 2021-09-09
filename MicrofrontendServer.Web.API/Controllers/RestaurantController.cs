﻿using System.Collections.Generic;
using MicrofrontendServer.Domain;
using MicrofrontendServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicrofrontendServer.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        #region Private Fields

        private readonly ILogger<RestaurantController> logger;
        private readonly IRestaurantService restaurantService;

        #endregion

        #region Public Constructors

        public RestaurantController(ILogger<RestaurantController> logger, IRestaurantService restaurantService)
        {
            this.logger = logger;
            this.restaurantService = restaurantService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> Get()
        {
            logger.LogInformation("Product.Get() accessed.");

            return Ok(restaurantService.GetRestaurants());
        }

        [HttpGet("Items")]
        public ActionResult<IEnumerable<Restaurant>> GetItems([FromQuery] long[] ids)
        {
            logger.LogInformation("Product.GetItems() accessed.");

            return Ok(restaurantService.GetRestaurantItems(ids));
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get(long id, bool withItems = false)
        {
            logger.LogInformation($"Product.Get(id={id}, withItems={withItems}) accessed.");

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