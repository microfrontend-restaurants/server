using System;
using System.Collections.Generic;

namespace MicrofrontendServer.Domain
{
    public class Order
    {
        #region Public Properties

        public DateTime CreatedDate { get; set; }
        public long Id { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }

        #endregion
    }
}