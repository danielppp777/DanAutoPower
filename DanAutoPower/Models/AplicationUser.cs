using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Car> Cars { get; set; }
}
