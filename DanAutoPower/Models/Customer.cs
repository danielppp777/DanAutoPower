using System.ComponentModel.DataAnnotations;

namespace DanAutoPower.Models
{
    public class Customer
    {
            
            public int Id { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required, EmailAddress]
            public string Email { get; set; }
            [Required]
            public string Phone { get; set; }
            public string Address { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string DriverLicenseNumber { get; set; }
        
    }
}
