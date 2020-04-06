using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ProductStockTrackingContext : DbContext
    {
        public ProductStockTrackingContext() : base("cnn")
        {
           // Database.SetInitializer<NorthwindContext>(null); //migration yapma yani gidip veritabanı oluşturma hazır var !.
        }

        public DbSet<FaultyPhone> FaultyPhones { get; set; }
        public DbSet<FaultyPhoneDelivery> FaultyPhoneDeliveries { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneSale> PhoneSales { get; set; }
        public DbSet<ProductBarcode> ProductBarcodes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMovement> ProductMovements { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new ProductMap());
            //modelBuilder.Configurations.Add(new CategoryMap());


            modelBuilder.Entity<FaultyPhone>().HasOptional(c => c.FaultyPhoneDelivery).WithRequired(i => i.FaultyPhone);
            modelBuilder.Entity<Phone>().HasOptional(c => c.PhoneSale).WithRequired(i => i.Phone);
            modelBuilder.Entity<Product>().HasMany(c => c.ProductBarcodes).WithRequired(i => i.Product);
            modelBuilder.Entity<Product>().HasMany(c => c.ProductMovements).WithRequired(i => i.Product);
            modelBuilder.Entity<Product>().HasRequired(c => c.ProductType).WithMany(i => i.Products).HasForeignKey(k=>k.ProductTypeId);






        }
    }
}
