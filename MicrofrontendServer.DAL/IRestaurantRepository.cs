using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL
{
    public interface IRestaurantRepository
    {
        public IEnumerable<Restaurant> Search(string filter, string category, PriceRange? range);
        Restaurant GetById(long id);
    }
}
