using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int Rate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public List<Image> Images { get; set; }
    }
}
