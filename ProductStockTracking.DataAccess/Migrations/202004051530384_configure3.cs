namespace ProductStockTracking.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configure3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "BrandModel", c => c.String());
            AddColumn("dbo.Phones", "FaultDescription", c => c.String());
            AlterColumn("dbo.Phones", "ReceivedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phones", "ReceivedDate", c => c.String());
            DropColumn("dbo.Phones", "FaultDescription");
            DropColumn("dbo.Phones", "BrandModel");
        }
    }
}
