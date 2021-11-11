namespace MyshopDataccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedateFailed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.BasketItems", "CreatAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Baskets", "CreatAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "CreatAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderItems", "CreatAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "CreatAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Productcategories", "CreatAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreatAt", c => c.DateTime(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.Products", "CreatAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Productcategories", "CreatAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Orders", "CreatAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.OrderItems", "CreatAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Customers", "CreatAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Baskets", "CreatAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.BasketItems", "CreatAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id");
        }
    }
}
