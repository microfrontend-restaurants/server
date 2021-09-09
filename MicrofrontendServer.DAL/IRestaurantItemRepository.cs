using System.Collections.Generic;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL
{
    public interface IRestaurantItemRepository
    {
        #region Public Methods

        IEnumerable<RestaurantItem> GetByRestaurantId(long restaurantId);
        IEnumerable<RestaurantItem> GetByIds(long[] ids);

        #endregion
    }
}