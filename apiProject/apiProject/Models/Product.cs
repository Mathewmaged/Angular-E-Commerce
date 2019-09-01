using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace apiProject.Models
{
    public class Product
    {

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Depth { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [ConcurrencyCheck]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual ICollection<OrderUserProduct> orderuserproducts { get; set; } = new List<OrderUserProduct>();
        public string Images { get; set; }
        public virtual Catagory Category { get; set; }
    }
}