namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Purchase", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchase", "UpdatedAt", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Purchase", "CreatedBy");
            AddForeignKey("dbo.Purchase", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Purchase", new[] { "CreatedBy" });
            DropColumn("dbo.Purchase", "UpdatedAt");
            DropColumn("dbo.Purchase", "CreatedAt");
            DropColumn("dbo.Purchase", "CreatedBy");
        }
    }
}
