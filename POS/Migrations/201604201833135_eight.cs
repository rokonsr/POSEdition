namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eight : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesDetail", "BarCode", c => c.Int(nullable: false));
            DropColumn("dbo.PurchaseDetails", "BarcodeImage");
            DropColumn("dbo.PurchaseDetails", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseDetails", "ImageUrl", c => c.String());
            AddColumn("dbo.PurchaseDetails", "BarcodeImage", c => c.Binary());
            AlterColumn("dbo.SalesDetail", "BarCode", c => c.String());
        }
    }
}
