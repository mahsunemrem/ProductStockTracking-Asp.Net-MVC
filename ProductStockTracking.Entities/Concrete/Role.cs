﻿using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
