namespace POS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150, unicode: false),
                        CategoryId = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        MeasurementId = c.Int(nullable: false),
                        Stock = c.Double(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Measurement", t => t.MeasurementId, cascadeDelete: true)
                .ForeignKey("dbo.Shop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ShopId)
                .Index(t => t.BrandId)
                .Index(t => t.MeasurementId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Measurement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20, unicode: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        Address = c.String(nullable: false, maxLength: 300, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        WebAddress = c.String(maxLength: 100, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                        FinancialYearId = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.FinancialYear", t => t.FinancialYearId, cascadeDelete: true)
                .Index(t => t.FinancialYearId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.FinancialYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartingDate = c.DateTime(nullable: false),
                        EndingDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Mobile = c.String(nullable: false, maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Address = c.String(maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SalesId = c.Int(nullable: false, identity: true),
                        SalesInvoiceNo = c.String(nullable: false, maxLength: 100, unicode: false),
                        SalesDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Remarks = c.String(maxLength: 100, unicode: false),
                        Vat = c.Double(nullable: false),
                        TotalDiscount = c.Double(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.SalesDetail",
                c => new
                    {
                        SalesDetailId = c.Int(nullable: false, identity: true),
                        SalesId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        SRate = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        LineDiscount = c.Double(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesDetailId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Sales", t => t.SalesId, cascadeDelete: true)
                .Index(t => t.SalesId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        PurchaseDetailId = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        BarCode = c.String(maxLength: 15, unicode: false),
                        Quantity = c.Double(nullable: false),
                        PRate = c.Double(nullable: false),
                        SRate = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseDetailId)
                .ForeignKey("dbo.Purchase", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PurchaseId);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(nullable: false, maxLength: 100, unicode: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        Remarks = c.String(maxLength: 100, unicode: false),
                        PaidAmount = c.Double(nullable: false),
                        DueAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Mobile = c.String(nullable: false, maxLength: 20, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Address = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Supplier", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchase");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.SalesDetail", "SalesId", "dbo.Sales");
            DropForeignKey("dbo.SalesDetail", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sales", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customer", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Product", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Shop", "FinancialYearId", "dbo.FinancialYear");
            DropForeignKey("dbo.FinancialYear", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shop", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Product", "MeasurementId", "dbo.Measurement");
            DropForeignKey("dbo.Measurement", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Product", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Product", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Brand", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Supplier", new[] { "CreatedBy" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Purchase", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.SalesDetail", new[] { "CreatedBy" });
            DropIndex("dbo.SalesDetail", new[] { "SalesId" });
            DropIndex("dbo.Sales", new[] { "CreatedBy" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "CreatedBy" });
            DropIndex("dbo.FinancialYear", new[] { "CreatedBy" });
            DropIndex("dbo.Shop", new[] { "CreatedBy" });
            DropIndex("dbo.Shop", new[] { "FinancialYearId" });
            DropIndex("dbo.Measurement", new[] { "CreatedBy" });
            DropIndex("dbo.Category", new[] { "CreatedBy" });
            DropIndex("dbo.Product", new[] { "CreatedBy" });
            DropIndex("dbo.Product", new[] { "MeasurementId" });
            DropIndex("dbo.Product", new[] { "BrandId" });
            DropIndex("dbo.Product", new[] { "ShopId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Brand", new[] { "CreatedBy" });
            DropTable("dbo.Supplier");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Purchase");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.SalesDetail");
            DropTable("dbo.Sales");
            DropTable("dbo.Customer");
            DropTable("dbo.FinancialYear");
            DropTable("dbo.Shop");
            DropTable("dbo.Measurement");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Brand");
        }
    }
}
