namespace ProductStockTracking.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configure5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "PhoneType", c => c.Int(nullable: false));
            AddColumn("dbo.ProductMovements", "Barcode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductMovements", "Barcode");
            DropColumn("dbo.Phones", "PhoneType");
        }
    }
}
