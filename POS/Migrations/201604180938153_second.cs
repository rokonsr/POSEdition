namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.SalesDetail", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Sales", new[] { "CreatedBy" });
            DropIndex("dbo.SalesDetail", new[] { "CreatedBy" });
            DropColumn("dbo.Sales", "CreatedBy");
            DropColumn("dbo.Sales", "CreatedAt");
            DropColumn("dbo.Sales", "UpdatedAt");
            DropColumn("dbo.SalesDetail", "CreatedBy");
            DropColumn("dbo.SalesDetail", "CreatedAt");
            DropColumn("dbo.SalesDetail", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesDetail", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.SalesDetail", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.SalesDetail", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Sales", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "CreatedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.SalesDetail", "CreatedBy");
            CreateIndex("dbo.Sales", "CreatedBy");
            AddForeignKey("dbo.SalesDetail", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Sales", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
