using MicrofrontendServer.Domain;
using System.Collections.Generic;

namespace MicrofrontendServer.Services
{
    public interface IOrderService
    {
        #region Public Methods

        public Order GetOrder(long id);

        IEnumerable<Order> GetOrders();

        IEnumerable<RestaurantItem> GetRestaurantItems(long[] ids);

        public long InsertOrder(Order order);

        public bool RemoveOrder(long id);

        public bool UpdateOrder(Order order);

        #endregion
    }
}