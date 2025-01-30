using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DanAutoPower.Models
{
    public class Sale
    {
            [Key]
            public int Id { get; set; }
            [Required, ForeignKey("Car")]
            public int CarId { get; set; }
            public Car Car { get; set; }
            [Required, ForeignKey("Customer")]
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
            public DateTime SaleDate { get; set; }
            public decimal FinalPrice { get; set; }

    }
}
