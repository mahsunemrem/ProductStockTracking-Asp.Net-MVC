namespace ProductStockTracking.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configure9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "WhoAdded", c => c.String());
            AddColumn("dbo.Phones", "WhoUpdated", c => c.String());
            AddColumn("dbo.Phones", "WhoDeleted", c => c.String());
            AddColumn("dbo.Phones", "AddDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Phones", "EditDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "EditDate");
            DropColumn("dbo.Phones", "AddDate");
            DropColumn("dbo.Phones", "WhoDeleted");
            DropColumn("dbo.Phones", "WhoUpdated");
            DropColumn("dbo.Phones", "WhoAdded");
        }
    }
}
