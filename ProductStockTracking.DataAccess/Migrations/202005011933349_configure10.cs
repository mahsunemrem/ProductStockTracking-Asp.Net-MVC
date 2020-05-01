namespace ProductStockTracking.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configure10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ForgotEmailId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ForgotEmailId");
        }
    }
}
