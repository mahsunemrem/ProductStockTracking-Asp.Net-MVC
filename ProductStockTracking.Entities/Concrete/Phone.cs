using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProductStockTracking.Entities.Concrete.Enums;

namespace ProductStockTracking.Entities.Concrete
{
    public class Phone : IEntity
    {
        public int Id { get; set; }
        public string Barcode { get; set; }

        public PhoneType PhoneType;

        public string FaultyPhone { get; set; }
        public int GuaranteeTerm { get; set; } //garanti süresi
        public string AccessoryStatus { get; set; }
        public float ReceivedPrice { get; set; }
        public string OldPhoneOwnersName { get; set; }
        public string OldPhoneOwnersNo { get; set; }
        public string ReceivedDate { get; set; }
        public bool SaleState { get; set; }

        public virtual PhoneSale PhoneSale { get; set; }

    }
}
