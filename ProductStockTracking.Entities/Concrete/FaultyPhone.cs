using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Concrete
{
    public class FaultyPhone : IEntity
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string BrandModel { get; set; }
        public string PhoneOwnersName { get; set; }
        public string PhoneOwnersNo { get; set; }
        public string FaultDescription { get; set; } // arıza açıklaması
        public DateTime ReceivedDate { get; set; }  //teslim alınan tarih
        public bool DeliveryState { get; set; } // teslim durumu

        public virtual  FaultyPhoneDelivery FaultyPhoneDelivery { get; set; }
    }
}
