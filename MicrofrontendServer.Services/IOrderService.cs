using System.Collections.Generic;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.Services
{
    public interface IOrderService
    {
        #region Public Methods

        public Order GetOrder(long id);

        IEnumerable<Order> GetOrders();

        public long InsertOrder(Order order);

        public bool RemoveOrder(long id);

        public bool UpdateOrder(Order order);

        #endregion
    }
}