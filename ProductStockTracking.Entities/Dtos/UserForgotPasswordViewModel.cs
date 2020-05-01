using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Dtos
{
    public class UserForgotPasswordViewModel : IDto
    {
        public string Password { get; set; }
        public string AgainPasswword { get; set; }
        public string Email { get; set; }
    }
}
