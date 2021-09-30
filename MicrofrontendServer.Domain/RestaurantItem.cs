namespace MicrofrontendServer.Domain
{
    public class RestaurantItem
    {
        #region Public Properties

        public string AllergyInformation { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
        public decimal Price { get; set; }

        #endregion
    }
}