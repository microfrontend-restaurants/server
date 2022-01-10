using MicrofrontendServer.Domain;
using MicrofrontendServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MicrofrontendServer.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        #region Private Fields

        private readonly ILogger<OrdersController> logger;
        private readonly IOrderService orderService;

        #endregion

        #region Public Constructors

        public OrdersController(ILogger<OrdersController> logger, IOrderService orderService)
        {
            this.logger = logger;
            this.orderService = orderService;
        }

        #endregion

        #region Public Methods

        [HttpGet("{id}")]
        public ActionResult<Domain.Order> Get(long id)
        {
            logger.LogInformation($"Orders.Get({id}) accessed.");

            var order = orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound("Order could not be found.");
            }

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Domain.Order>> Get()
        {
            return Ok(orderService.GetOrders());
        }

        [HttpPost]
        public ActionResult<long> Insert([FromBody] Domain.Order order)
        {
            logger.LogInformation($"Orders.Insert({order}) accessed.");

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
            logger.LogInformation($"Orders.Get(ids={ids}) accessed.");

            return Ok(orderService.GetRestaurantItems(ids));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            logger.LogInformation($"Orders.Remove({id}) accessed.");

            if (!orderService.RemoveOrder(id))
            {
                return Conflict("Order could not be removed.");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Domain.Order order)
        {
            logger.LogInformation($"Orders.Update({order}) accessed.");

            if (!orderService.UpdateOrder(order))
            {
                return Conflict("Order could not be updated.");
            }

            return Ok();
        }

        #endregion
    }
}