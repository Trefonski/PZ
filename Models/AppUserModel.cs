using Microsoft.AspNetCore.Identity;

namespace PZ.Models
{
    public class AppUser : IdentityUser
    {
        //FK
        public Clients Clients {get; set;}
    }
}