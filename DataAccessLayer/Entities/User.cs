using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities
{
    public class User : IdentityUser
    { 
        public Account Account { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
    }
}
