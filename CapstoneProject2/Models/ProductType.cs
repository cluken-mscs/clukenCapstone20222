using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject2.Models
{
    public class ProductType
    {
        [Key]
        public int ProdTypeId { get; set; }
        public string ProdTypeDesc { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
