using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IBaseRepository<ApplicationUser> ApplicationUser { get; }
        IBaseRepository<Customer> Customer { get; }
        IBaseRepository<Store> Store { get; }
        IBaseRepository<Vendor> Vendor { get; }

    }
}
