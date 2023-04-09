using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        List<Review> getReviews(int id);
    }
}
