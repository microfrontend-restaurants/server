using System.Collections.Generic;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL
{
    public interface IOrderRepository
    {
        #region Public Methods

        public Order Get(long id);

        public IEnumerable<Order> Get();

        public long Insert(Order order);

        public bool Remove(long id);

        public bool Update(Order order);

        #endregion
    }
}