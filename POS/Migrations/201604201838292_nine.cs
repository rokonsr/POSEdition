namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseDetails", "BarCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseDetails", "BarCode", c => c.String());
        }
    }
}
