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
            [Required, ForeignKey("Customer")]
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
            public DateTime Date { get; set; }
            [Required, ForeignKey("Employee")]
            public int EmployeeId { get; set; }
            public Employee Employee { get; set; }
        
    }

}

