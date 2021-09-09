using System.Collections.Generic;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL
{
    public interface IOrderItemRepository
    {
        #region Public Methods

        public IEnumerable<OrderItem> GetByParent(long parentId);

        public long Insert(OrderItem item);

        #endregion
    }
}