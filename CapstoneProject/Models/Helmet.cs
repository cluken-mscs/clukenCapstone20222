using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class Helmet
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public ICollection<Coat> Coats { get; set; }
    }
}
