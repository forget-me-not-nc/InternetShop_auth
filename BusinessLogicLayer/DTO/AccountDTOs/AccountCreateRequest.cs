using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO.AccountDTOs
{
    public class AccountCreateRequest
    {
        public string Id { get; set; }
        public bool isActive { get; set; }
        public decimal Balance { get; set; }

        public string UserId { get; set; }
    }
}
