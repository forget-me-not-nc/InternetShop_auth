using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO.AccountDTOs
{
    public class AccountModify
    {
        public string Id { get; set; }
        public bool isActive { get; set; }
        public decimal Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
