using System;
using System.Collections.Generic;
using System.Linq;
using MicrofrontendServer.DAL;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.Services
{
    public class OrderService : IOrderService
    {
        #region Private Fields

        private readonly IOrderItemRepository orderItemRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IRestaurantItemRepository restaurantItemRepository;

        #endregion

        #region Public Constructors

        public OrderService(
            IOrderItemRepository orderItemRepository,
            IOrderRepository orderRepository,
            IRestaurantItemRepository restaurantItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
            this.orderRepository = orderRepository;
            this.restaurantItemRepository = restaurantItemRepository;
        }

        #endregion

        #region Private Methods

        private void WithDependencies(Order order)
        {
            // Load order items
            var orderItems = orderItemRepository.GetByParent(order.Id);
            // Load restaurant items
            var restaurantItems = restaurantItemRepository.GetByIds(orderItems.Select(i => i.Id).ToArray());

            foreach (var orderItem in orderItems)
            {
                orderItem.Item = restaurantItems.Single(r => r.Id == orderItem.Id);
            }

            order.Items = orderItems;
        }

        #endregion

        #region Public Methods

        public Order GetOrder(long id)
        {
            var order = orderRepository.Get(id);

            // Load items
            WithDependencies(order);

            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = orderRepository.Get();

            foreach (var order in orders)
            {
                WithDependencies(order);
            }

            return orders;
        }

        public long InsertOrder(Order order)
        {
            // Set creation date
            order.CreatedDate = DateTime.Now;
            var orderId = orderRepository.Insert(order);

            if(orderId <= 0)
            {
                return -1;
            }

            foreach (var item in order.Items)
            {
                // Set parent id
                item.ParentId = order.Id;

                // Insert order
                if (orderItemRepository.Insert(item) <= 0)
                {
                    return -1;
                }
            }

            return orderId;
        }

        public bool RemoveOrder(long id)
        {
            return orderRepository.Remove(id);
        }

        public bool UpdateOrder(Order order)
        {
            return orderRepository.Update(order);
        }

        public IEnumerable<RestaurantItem> GetRestaurantItems(long[] ids)
        {
            return restaurantItemRepository.GetByIds(ids);
        }

        #endregion
    }
}