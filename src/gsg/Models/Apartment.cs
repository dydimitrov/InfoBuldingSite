namespace gsg.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public double Area { get; set; }
        public Building Building { get; set; }
        public bool IsSold { get; set; } = false;
    }
}