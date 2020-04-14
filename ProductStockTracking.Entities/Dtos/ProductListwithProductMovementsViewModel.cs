using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Entities.Dtos
{
    public class ProductListwithProductMovementsViewModel
    {
  
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public virtual ICollection<ProductBarcode> ProductBarcodes { get; set; }
        public virtual ICollection<ProductMovement> ProductMovements { get; set; }
        public Product Product { get; set; }
      
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

     
    }
}
