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
    public class VendorRepository : BaseRepository<Vendor>,IVendorRepository
    {
        ApplicationDBContext context;
        public VendorRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public string FindVendorId(int hotelid)
        {
            string userid = context.Vendors.Where(m => m.StoreId == hotelid).Select(m => m.ApplicationUserId).FirstOrDefault();
            return userid;
        }

        public Vendor FindVendorDetailes(string userid)
        {
            Vendor hotel_Manager = context.Vendors.Where(v => v.ApplicationUserId == userid).
                Include(h => h.store).Include(a => a.ApplicationUser).FirstOrDefault();
            return hotel_Manager;
        }





    }
}


