    using System.ComponentModel.DataAnnotations.Schema;
namespace DanAutoPower.Models
{
    public class Car
    {
        public int Id { get; set; }
        //   public string Brand { get; set; }

        public int ModelID { get; set; }
        public virtual Model? Model { get; set; }
        public DateOnly YearOfManifacture { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Car>? Cars { get; set; }

        //// Foreign Key - връзка към User
        //public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
    }

}