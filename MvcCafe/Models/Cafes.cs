using System.ComponentModel.DataAnnotations;

namespace MvcCafe.Models
{
    public class Cafe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal CurrentLoad { get; set; }
        public decimal MaxLoad { get; set; }
 // ownerid 
    }
}