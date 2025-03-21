using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace DanAutoPower.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Car> Cars { get; set; }
    }
}