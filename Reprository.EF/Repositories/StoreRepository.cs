using Microsoft.EntityFrameworkCore;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using Reprository.EF.Reprositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.EF.Repositories
{
    public class StoreRepository : BaseRepository<Store>,IStoreRepository
    {
        ApplicationDBContext context;
        public StoreRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }
        public List<Review> getReviews(int id)
        {
            List<Review> reviews = context.Reviews.Where(i => i.IsDeleted == false && i.StoreId == id).OrderByDescending(d => d.Id).Take(8).Include(c => c.customer).ThenInclude(a => a.ApplicationUser).ToList();
            return reviews;
        }

    }
}
