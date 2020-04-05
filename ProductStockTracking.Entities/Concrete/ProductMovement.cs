using ProductStockTracking.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProductStockTracking.Entities.Concrete.Enums;

namespace ProductStockTracking.Entities.Concrete
{
    public class ProductMovement : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ProductTransaction ProductTransaction { get; set; }

        public int Piece { get; set; }
        public DateTime TransactionDate { get; set; }
        public float Price { get; set; }

        public Product Product { get; set; }
    }
}
