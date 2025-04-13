using System.ComponentModel.DataAnnotations.Schema;
namespace DanAutoPower.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        //// Foreign Key - връзка към User
        //public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
    }

}