using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Dtos
{
    public class UserLoginViewModel:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
