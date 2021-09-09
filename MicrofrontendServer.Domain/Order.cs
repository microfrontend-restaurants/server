using System.Collections.Generic;

namespace MicrofrontendServer.Domain
{
    public class Order
    {
        #region Public Properties

        public long Id { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }

        #endregion
    }
}