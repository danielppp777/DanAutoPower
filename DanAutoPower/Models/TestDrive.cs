using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DanAutoPower.Models
{
    public class TestDrive
    {
            [Key]
            public int Id { get; set; }
            [Required, ForeignKey("Car")]
            public int CarId { get; set; }
            public Car Car { get; set; }
            public DateTime Date { get; set; }
        
    }

}

