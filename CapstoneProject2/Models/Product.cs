using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        //public string Color { get; set; }

        public ICollection<ProductType> ProductTypes { get; set; }
    }
}
