namespace MyshopDataccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedateFailed1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Street", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "State", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.OrderItems", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Orders", "SurName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Street", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Orders", "State", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Orders", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "OrderStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Orders", "OrderStatus", c => c.String());
            AlterColumn("dbo.Orders", "ZipCode", c => c.String());
            AlterColumn("dbo.Orders", "State", c => c.String());
            AlterColumn("dbo.Orders", "City", c => c.String());
            AlterColumn("dbo.Orders", "Street", c => c.String());
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "SurName", c => c.String());
            AlterColumn("dbo.Orders", "FirstName", c => c.String());
            AlterColumn("dbo.OrderItems", "ProductName", c => c.String());
            AlterColumn("dbo.Customers", "ZipCode", c => c.String());
            AlterColumn("dbo.Customers", "State", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "Street", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
