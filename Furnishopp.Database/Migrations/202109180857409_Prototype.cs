namespace Furnishopp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prototype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                        Category_ID = c.Int(),
                        Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        C_ID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.C_ID_ID)
                .Index(t => t.C_ID_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C_ID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.C_ID_ID)
                .Index(t => t.C_ID_ID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        rating = c.Single(nullable: false),
                        C_ID_ID = c.Int(),
                        P_ID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.C_ID_ID)
                .ForeignKey("dbo.Products", t => t.P_ID_ID)
                .Index(t => t.C_ID_ID)
                .Index(t => t.P_ID_ID);
            
        }
        
        public override void Down ()
        {
            DropForeignKey("dbo.Ratings", "P_ID_ID", "dbo.Products");
            DropForeignKey("dbo.Ratings", "C_ID_ID", "dbo.Customers");
            DropForeignKey("dbo.Products", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "C_ID_ID", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "C_ID_ID", "dbo.Customers");
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Ratings", new[] { "P_ID_ID" });
            DropIndex("dbo.Ratings", new[] { "C_ID_ID" });
            DropIndex("dbo.Orders", new[] { "C_ID_ID" });
            DropIndex("dbo.Invoices", new[] { "C_ID_ID" });
            DropIndex("dbo.Products", new[] { "Order_ID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
