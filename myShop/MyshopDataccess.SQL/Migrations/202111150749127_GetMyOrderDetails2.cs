namespace MyshopDataccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetMyOrderDetails2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketItems", "MyOrderDetails_Id", "dbo.MyOrderDetails");
            DropForeignKey("dbo.MyOrderDetails", "MyOrderDetails_Id", "dbo.MyOrderDetails");
            DropForeignKey("dbo.OrderItems", "MyOrderDetails_Id", "dbo.MyOrderDetails");
            DropForeignKey("dbo.MyOrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.BasketItems", new[] { "MyOrderDetails_Id" });
            DropIndex("dbo.MyOrderDetails", new[] { "MyOrderDetails_Id" });
            DropIndex("dbo.OrderItems", new[] { "MyOrderDetails_Id" });
            DropIndex("dbo.MyOrderDetails", new[] { "OrderId" });
            DropColumn("dbo.BasketItems", "MyOrderDetails_Id");
            DropColumn("dbo.OrderItems", "MyOrderDetails_Id");
            DropTable("dbo.MyOrderDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MyOrderDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderId = c.String(maxLength: 128),
                        ProductId = c.String(),
                        ProductName = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        OrderStatus = c.String(),
                        CreatAt = c.DateTime(nullable: false),
                        MyOrderDetails_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderItems", "MyOrderDetails_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.BasketItems", "MyOrderDetails_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.MyOrderDetails", "OrderId");
            CreateIndex("dbo.OrderItems", "MyOrderDetails_Id");
            CreateIndex("dbo.MyOrderDetails", "MyOrderDetails_Id");
            CreateIndex("dbo.BasketItems", "MyOrderDetails_Id");
            AddForeignKey("dbo.MyOrderDetails", "OrderId", "dbo.Orders", "Id");
            AddForeignKey("dbo.OrderItems", "MyOrderDetails_Id", "dbo.MyOrderDetails", "Id");
            AddForeignKey("dbo.MyOrderDetails", "MyOrderDetails_Id", "dbo.MyOrderDetails", "Id");
            AddForeignKey("dbo.BasketItems", "MyOrderDetails_Id", "dbo.MyOrderDetails", "Id");
        }
    }
}
