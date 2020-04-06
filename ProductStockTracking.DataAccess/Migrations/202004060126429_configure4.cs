namespace ProductStockTracking.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configure4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FaultyPhoneDeliveries", "FaultyPhoneId", "dbo.FaultyPhones");
            DropForeignKey("dbo.PhoneSales", "PhoneId", "dbo.Phones");
            AddForeignKey("dbo.FaultyPhoneDeliveries", "FaultyPhoneId", "dbo.FaultyPhones", "Id");
            AddForeignKey("dbo.PhoneSales", "PhoneId", "dbo.Phones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneSales", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.FaultyPhoneDeliveries", "FaultyPhoneId", "dbo.FaultyPhones");
            AddForeignKey("dbo.PhoneSales", "PhoneId", "dbo.Phones", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FaultyPhoneDeliveries", "FaultyPhoneId", "dbo.FaultyPhones", "Id", cascadeDelete: true);
        }
    }
}
