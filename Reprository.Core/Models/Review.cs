using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.Core.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("store")]
        public int? StoreId { get; set; }
        public Store? store { get; set; }

        [ForeignKey("product")]
        public int? ProductId { get; set; }
        public Product? product { get; set; }

        [ForeignKey("customer")]
        public string? CustomerId { get; set; }
        public Customer? customer { get; set; }
    }
}
