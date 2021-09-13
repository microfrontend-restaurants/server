using System;
using System.Collections.Generic;
using System.Linq;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL.Mock
{
    public class FakeOrderRepository : IOrderRepository
    {
        #region Private Fields

        private readonly ICollection<Order> orders;

        #endregion

        #region Public Constructors

        public FakeOrderRepository()
        {
            orders = new List<Order>
            {
                new Order { Id = 1, CreatedDate = DateTime.Today.AddDays(-5) }
            };
        }

        #endregion

        #region Public Methods

        public Order Get(long id)
        {
            return orders.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> Get()
        {
            return orders.OrderByDescending(o => o.CreatedDate);
        }

        public long Insert(Order order)
        {
            order.Id = (orders.Max(o =>(long?) o.Id) ?? 0) + 1;
            orders.Add(order);

            return order.Id;
        }

        public bool Remove(long id)
        {
            var order = orders.SingleOrDefault(o => o.Id == id);
            if (order == null)
            {
                return false;
            }
            orders.Remove(order);
            return true;
        }

        public bool Update(Order order)
        {
            var orderToUpdate = orders.SingleOrDefault(o => o.Id == order.Id);

            if (orderToUpdate == null)
            {
                return false;
            }

            orders.Remove(orderToUpdate);
            orders.Add(order);
            return true;
        }

        #endregion
    }
}