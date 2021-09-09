using MicrofrontendServer.Domain;

namespace MicrofrontendServer.Services
{
    public interface IOrderService
    {
        #region Public Methods

        public Order GetOrder(long id);

        public long InsertOrder(Order order);

        public bool RemoveOrder(long id);

        public bool UpdateOrder(Order order);

        #endregion
    }
}