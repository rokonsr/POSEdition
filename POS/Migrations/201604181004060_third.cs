namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesDetail", "BarCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesDetail", "BarCode");
        }
    }
}
