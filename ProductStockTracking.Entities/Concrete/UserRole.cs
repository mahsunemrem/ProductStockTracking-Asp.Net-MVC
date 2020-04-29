using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

    }
}