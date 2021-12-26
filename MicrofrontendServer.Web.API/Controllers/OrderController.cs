using System.Collections;
using System.Collections.Generic;
using MicrofrontendServer.Domain;
using MicrofrontendServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicrofrontendServer.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        #region Private Fields

        private readonly ILogger<OrderController> logger;
        private readonly IOrderService orderService;

        #endregion

        #region Public Constructors

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            this.logger = logger;
            this.orderService = orderService;
        }

        #endregion

        #region Public Methods

        [HttpGet("{id}")]
        public ActionResult<Order> Get(long id)
        {
            logger.LogInformation($"Order.Get({id}) accessed.");

            var order = orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound("Order could not be found.");
            }

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(orderService.GetOrders());
        }

        [HttpPost]
        public ActionResult<long> Insert([FromBody] Order order)
        {
            logger.LogInformation($"Order.Insert({order}) accessed.");

            var id = orderService.InsertOrder(order);

            if (id <= 0)
            {
                return BadRequest("Order could not be added.");
            }

            return Ok();
        }

        [HttpGet("Items")]
        public ActionResult<IEnumerable<Restaurant>> GetItems([FromQuery] long[] ids)
        {
            logger.LogInformation($"Order.Get(ids={ids}) accessed.");

            return Ok(orderService.GetRestaurantItems(ids));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            logger.LogInformation($"Order.Remove({id}) accessed.");

            if (!orderService.RemoveOrder(id))
            {
                return Conflict("Order could not be removed.");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Order order)
        {
            logger.LogInformation($"Order.Update({order}) accessed.");

            if (!orderService.UpdateOrder(order))
            {
                return Conflict("Order could not be updated.");
            }

            return Ok();
        }

        #endregion
    }
}