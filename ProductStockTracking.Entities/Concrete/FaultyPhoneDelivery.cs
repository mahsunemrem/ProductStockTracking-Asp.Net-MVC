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
    public class FaultyPhoneDelivery : IEntity
    {
        [Key]
        [ForeignKey("FaultyPhone")]
        public int FaultyPhoneId { get; set; }      
        public string Barcode { get; set; }
        public string Transactions { get; set; } // yapılan işlemler
        public float TransactionPrice { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual FaultyPhone FaultyPhone { get; set; }
    }
}
