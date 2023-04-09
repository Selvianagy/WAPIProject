using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customer User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
