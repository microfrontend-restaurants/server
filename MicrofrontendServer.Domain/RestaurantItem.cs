namespace MicrofrontendServer.Domain
{
    public class RestaurantItem
    {
        #region Public Properties

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public long ParentId { get; set; }
        #endregion
    }
}