namespace ProductStockTracking.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configure8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "State", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "State");
        }
    }
}
