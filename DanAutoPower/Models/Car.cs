    using System.ComponentModel.DataAnnotations.Schema;
namespace DanAutoPower.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }          // from API
        public string Model { get; set; }         // from API
        public string Fuel { get; set; }          // static drodown
        public int Year { get; set; }             // entered manually
        public int Mileage { get; set; }          // entered manually
        public decimal Price { get; set; }        // entered manually
        public string ImageUrl { get; set; }      // entered manually
    }
}