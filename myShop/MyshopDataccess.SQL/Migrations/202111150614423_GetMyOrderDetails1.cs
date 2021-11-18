namespace MyshopDataccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetMyOrderDetails1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MyOrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.MyOrderDetails", new[] { "OrderId" });
            AddColumn("dbo.MyOrderDetails", "MyOrderDetails_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.MyOrderDetails", "MyOrderDetails_Id");
            CreateIndex("dbo.MyOrderDetails", "OrderId");
            AddForeignKey("dbo.MyOrderDetails", "MyOrderDetails_Id", "dbo.MyOrderDetails", "Id");
            AddForeignKey("dbo.MyOrderDetails", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyOrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.MyOrderDetails", "MyOrderDetails_Id", "dbo.MyOrderDetails");
            DropIndex("dbo.MyOrderDetails", new[] { "OrderId" });
            DropIndex("dbo.MyOrderDetails", new[] { "MyOrderDetails_Id" });
            DropColumn("dbo.MyOrderDetails", "MyOrderDetails_Id");
            CreateIndex("dbo.MyOrderDetails", "OrderId");
            AddForeignKey("dbo.MyOrderDetails", "OrderId", "dbo.Orders", "Id");
        }
    }
}
