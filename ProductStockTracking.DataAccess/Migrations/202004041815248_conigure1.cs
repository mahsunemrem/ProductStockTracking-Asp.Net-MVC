namespace ProductStockTracking.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conigure1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FaultyPhoneDeliveries",
                c => new
                    {
                        FaultyPhoneId = c.Int(nullable: false),
                        Barcode = c.String(),
                        Transactions = c.String(),
                        TransactionPrice = c.Single(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FaultyPhoneId)
                .ForeignKey("dbo.FaultyPhones", t => t.FaultyPhoneId, cascadeDelete: true)
                .Index(t => t.FaultyPhoneId);
            
            CreateTable(
                "dbo.FaultyPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.String(),
                        BrandModel = c.String(),
                        PhoneOwnersName = c.String(),
                        PhoneOwnersNo = c.String(),
                        FaultDescription = c.String(),
                        ReceivedDate = c.DateTime(nullable: false),
                        DeliveryState = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.String(),
                        FaultyPhone = c.String(),
                        GuaranteeTerm = c.Int(nullable: false),
                        AccessoryStatus = c.String(),
                        ReceivedPrice = c.Single(nullable: false),
                        OldPhoneOwnersName = c.String(),
                        OldPhoneOwnersNo = c.String(),
                        ReceivedDate = c.String(),
                        SaleState = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneSales",
                c => new
                    {
                        PhoneId = c.Int(nullable: false),
                        Barcode = c.String(),
                        NewPhoneOwnersName = c.String(),
                        NewPhoneOwnersNo = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Phones", t => t.PhoneId, cascadeDelete: true)
                .Index(t => t.PhoneId);
            
            CreateTable(
                "dbo.ProductBarcodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Barcode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandModel = c.String(),
                        Type = c.String(),
                        Features = c.String(),
                        ProductTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: true)
                .Index(t => t.ProductTypeId);
            
            CreateTable(
                "dbo.ProductMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductTransaction = c.Int(nullable: false),
                        Piece = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.ProductMovements", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductBarcodes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PhoneSales", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.FaultyPhoneDeliveries", "FaultyPhoneId", "dbo.FaultyPhones");
            DropIndex("dbo.ProductMovements", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.ProductBarcodes", new[] { "ProductId" });
            DropIndex("dbo.PhoneSales", new[] { "PhoneId" });
            DropIndex("dbo.FaultyPhoneDeliveries", new[] { "FaultyPhoneId" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductMovements");
            DropTable("dbo.Products");
            DropTable("dbo.ProductBarcodes");
            DropTable("dbo.PhoneSales");
            DropTable("dbo.Phones");
            DropTable("dbo.FaultyPhones");
            DropTable("dbo.FaultyPhoneDeliveries");
        }
    }
}
