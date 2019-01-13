using System.ComponentModel.DataAnnotations;

namespace gsg.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Area { get; set; }
        public Building Building { get; set; }
        public bool IsSold { get; set; } = false;
    }
}