namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesDetail", "BarCode", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "BarCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseDetails", "BarCode", c => c.String());
            AlterColumn("dbo.SalesDetail", "BarCode", c => c.String());
        }
    }
}
