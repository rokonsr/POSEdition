namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseDetails", "BarcodeImage", c => c.Binary());
            AddColumn("dbo.PurchaseDetails", "ImageUrl", c => c.String());
            AlterColumn("dbo.SalesDetail", "BarCode", c => c.String());
            AlterColumn("dbo.PurchaseDetails", "BarCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseDetails", "BarCode", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesDetail", "BarCode", c => c.Int(nullable: false));
            DropColumn("dbo.PurchaseDetails", "ImageUrl");
            DropColumn("dbo.PurchaseDetails", "BarcodeImage");
        }
    }
}
