namespace Furnishopp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderFinalAndOrderItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderFinals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        OrderedAt = c.DateTime(nullable: false),
                        Status = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        OrderFinal_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.OrderFinals", t => t.OrderFinal_ID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID)
                .Index(t => t.OrderFinal_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderFinal_ID", "dbo.OrderFinals");
            DropForeignKey("dbo.OrderItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderFinal_ID" });
            DropIndex("dbo.OrderItems", new[] { "ProductID" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.OrderFinals");
        }
    }
}
