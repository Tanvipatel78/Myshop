namespace MyshopDataccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetMyOrderDetails : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.BasketItems", "MyOrderDetails_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.OrderItems", "MyOrderDetails_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.BasketItems", "MyOrderDetails_Id");
            CreateIndex("dbo.OrderItems", "MyOrderDetails_Id");
            AddForeignKey("dbo.BasketItems", "MyOrderDetails_Id", "dbo.MyOrderDetails", "Id");
            AddForeignKey("dbo.OrderItems", "MyOrderDetails_Id", "dbo.MyOrderDetails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyOrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "MyOrderDetails_Id", "dbo.MyOrderDetails");
            DropForeignKey("dbo.BasketItems", "MyOrderDetails_Id", "dbo.MyOrderDetails");
            DropIndex("dbo.MyOrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "MyOrderDetails_Id" });
            DropIndex("dbo.BasketItems", new[] { "MyOrderDetails_Id" });
            DropColumn("dbo.OrderItems", "MyOrderDetails_Id");
            DropColumn("dbo.BasketItems", "MyOrderDetails_Id");
            DropTable("dbo.MyOrderDetails");
        }
    }
}
