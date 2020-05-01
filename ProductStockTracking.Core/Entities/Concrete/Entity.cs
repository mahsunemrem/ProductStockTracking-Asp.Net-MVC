using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Core.Entities.Concrete
{
    public class Entity : IEntity
    {
        public string WhoAdded { get; set; }
        public string WhoUpdated { get; set; } = "Bilinmiyor";
        public string WhoDeleted { get; set; } = "Bilinmiyor";
        public DateTime AddDate { get; set; } = DateTime.Now;
        public DateTime EditDate { get; set; } = DateTime.Now;
    }
}
