namespace MicrofrontendServer.Domain
{
    public class OrderItem
    {
        #region Public Properties

        public double Amount { get; set; }
        public long Id { get; set; }
        public RestaurantItem Item { get; set; }
        public long ParentId { get; set; }

        #endregion
    }
}