using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string BrandModel { get; set; }
        public string Type { get; set; }
        public string Features { get; set; }

        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public virtual List<ProductBarcode> ProductBarcodes { get; set; }
        public virtual List<ProductMovement> ProductMovements { get; set; }
    }
}
