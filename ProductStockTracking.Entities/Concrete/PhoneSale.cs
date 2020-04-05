using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Concrete
{
    public class PhoneSale : IEntity
    {
        [Key]
        [ForeignKey("Phone")]
        public int PhoneId { get; set; }
        public string Barcode { get; set; }
        public string NewPhoneOwnersName { get; set; }
        public string NewPhoneOwnersNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public float DeliveryPrice { get; set; }

        public virtual Phone Phone { get; set; }
    }
}
