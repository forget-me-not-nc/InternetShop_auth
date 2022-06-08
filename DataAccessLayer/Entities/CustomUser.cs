using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CustomUser : IdentityUser
    {
        public bool Sex { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        
        public Account Account { get; set; }
    }
}
