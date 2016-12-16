namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "OverallDiscount", c => c.Double(nullable: false));
            DropColumn("dbo.Sales", "Vat");
            DropColumn("dbo.Sales", "TotalDiscount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "TotalDiscount", c => c.Double(nullable: false));
            AddColumn("dbo.Sales", "Vat", c => c.Double(nullable: false));
            DropColumn("dbo.Sales", "OverallDiscount");
        }
    }
}
