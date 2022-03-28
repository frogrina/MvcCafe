namespace MvcCafe.Models
{
    public class Cafe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CurrentLoad { get; set; }
        public int? MaxLoad { get; set; }
    }
}