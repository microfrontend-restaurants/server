using System.Collections.Generic;

namespace MicrofrontendServer.Domain
{
    public class Restaurant
    {
        #region Public Properties

        public IEnumerable<string> Categories { get; set; }
        public long Id { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<RestaurantItem> Items { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }

        #endregion
    }
}