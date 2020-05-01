﻿using ProductStockTracking.Core.Entities;
using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Dtos
{
    public class UserRoleViewModel :IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
