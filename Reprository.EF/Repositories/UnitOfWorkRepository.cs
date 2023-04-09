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
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public ApplicationDBContext context;

        public IBaseRepository<ApplicationUser> ApplicationUser { get; private set; }
        public IBaseRepository<Customer> Customer { get; private set; }
        public IBaseRepository<Store> Store { get; private set; }
        public IBaseRepository<Vendor> Vendor { get; private set; }


        public UnitOfWorkRepository(ApplicationDBContext context)
        {
            this.context = context;

            ApplicationUser = new BaseRepository<ApplicationUser>(this.context);
            Customer = new BaseRepository<Customer>(this.context);
            Store = new BaseRepository<Store>(this.context);    
            Vendor = new BaseRepository<Vendor>(this.context);    
        }
        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
