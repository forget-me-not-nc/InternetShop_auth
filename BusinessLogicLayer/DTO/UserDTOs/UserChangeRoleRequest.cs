﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO.UserDTOs
{
    public class UserChangeRoleRequest
    {
        public string Id { get; set; }
        public string Role { get; set; }
    }
}
