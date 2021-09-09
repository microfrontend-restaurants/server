using System;
using MicrofrontendServer.DAL;
using MicrofrontendServer.Domain;
using System.Linq;

namespace MicrofrontendServer.Services
{
    public class OrderService : IOrderService
    {
        #region Public Methods

        private readonly IOrderRepository orderRepository;
        private readonly IOrderItemRepository orderItemRepository;

        public OrderService(
            IOrderItemRepository orderItemRepository,
            IOrderRepository orderRepository)
        {
            this.orderItemRepository = orderItemRepository;
            this.orderRepository = orderRepository;
        }

        public Order GetOrder(long id)
        {
            var items = orderItemRepository.GetByParent(id);

            var order = orderRepository.Get(id);
            order.Items = items;

            return order;
        }

        public long InsertOrder(Order order)
        {
            foreach (var item in order.Items)
            {
                if(orderItemRepository.Insert(item) <= 0)
                {
                    return -1;
                }
            }

            return orderRepository.Insert(order);
        }

        public bool RemoveOrder(long id)
        {
            return orderRepository.Remove(id);
        }

        public bool UpdateOrder(Order order)
        {
            return orderRepository.Update(order);
        }

        #endregion
    }
}