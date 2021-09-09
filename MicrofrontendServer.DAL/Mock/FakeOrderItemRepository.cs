using System.Collections.Generic;
using System.Linq;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL.Mock
{
    public class FakeOrderItemRepository : IOrderItemRepository
    {
        #region Private Fields

        private readonly ICollection<OrderItem> items;

        #endregion

        #region Public Constructors

        public FakeOrderItemRepository()
        {
            items = new List<OrderItem>();
        }

        #endregion

        #region Public Methods

        public IEnumerable<OrderItem> GetByParent(long parentId)
        {
            return items.Where(i => i.ParentId == parentId);
        }

        public long Insert(OrderItem item)
        {
            item.Id = (items.Max(o => (long?)o.Id) ?? 0) + 1;
            items.Add(item);

            return item.Id;
        }

        #endregion
    }
}