using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsConfermed { get; set; }

        [ForeignKey("vendor")]
        public string? VendorId { get; set; }
        public Vendor? vendor { get; set; }

        public List<Product>? Products { get; set; }
        public List<Review>? reviews { get; set; }

    }
}
