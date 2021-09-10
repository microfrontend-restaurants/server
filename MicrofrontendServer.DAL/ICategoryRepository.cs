using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrofrontendServer.Domain;

namespace MicrofrontendServer.DAL
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> Get();
    }
}
