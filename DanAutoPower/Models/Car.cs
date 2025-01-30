namespace DanAutoPower.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } // Път за изображение
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }

    }
}
