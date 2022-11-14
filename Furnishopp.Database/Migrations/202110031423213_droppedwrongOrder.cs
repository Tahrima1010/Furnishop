namespace Furnishopp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppedwrongOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "OrderFinal_ID", "dbo.OrderFinals");
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropIndex("dbo.OrderItems", new[] { "OrderFinal_ID" });
            DropColumn("dbo.OrderItems", "OrderID");
            RenameColumn(table: "dbo.OrderItems", name: "OrderFinal_ID", newName: "OrderID");
            AlterColumn("dbo.OrderItems", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderID");
            AddForeignKey("dbo.OrderItems", "OrderID", "dbo.OrderFinals", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.OrderFinals");
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            AlterColumn("dbo.OrderItems", "OrderID", c => c.Int());
            RenameColumn(table: "dbo.OrderItems", name: "OrderID", newName: "OrderFinal_ID");
            AddColumn("dbo.OrderItems", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderFinal_ID");
            CreateIndex("dbo.OrderItems", "OrderID");
            AddForeignKey("dbo.OrderItems", "OrderFinal_ID", "dbo.OrderFinals", "ID");
        }
    }
}
