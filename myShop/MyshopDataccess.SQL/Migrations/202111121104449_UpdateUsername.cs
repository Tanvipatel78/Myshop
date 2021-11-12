namespace MyshopDataccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketItems", "Order_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.BasketItems", "Order_Id");
            AddForeignKey("dbo.BasketItems", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.BasketItems", new[] { "Order_Id" });
            DropColumn("dbo.BasketItems", "Order_Id");
        }
    }
}
