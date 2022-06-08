using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Account 
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; } 
        public string UserId { get; set; } 
        public CustomUser User { get; set; } 
    }
}
