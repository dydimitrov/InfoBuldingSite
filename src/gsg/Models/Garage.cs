using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gsg.Models
{
    public class Garage
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Floor { get; set; }
        
        public string Description { get; set; }

        [Required]
        public double Area { get; set; }
        public Building Building { get; set; }
        public bool IsSold { get; set; } = false;
    }
}
