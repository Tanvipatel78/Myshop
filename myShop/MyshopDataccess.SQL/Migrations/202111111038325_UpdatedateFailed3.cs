namespace MyshopDataccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedateFailed3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "FirstName", c => c.String());
            AlterColumn("dbo.Orders", "SurName", c => c.String());
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "Street", c => c.String());
            AlterColumn("dbo.Orders", "City", c => c.String());
            AlterColumn("dbo.Orders", "State", c => c.String());
            AlterColumn("dbo.Orders", "ZipCode", c => c.String());
            AlterColumn("dbo.Orders", "OrderStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "State", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Orders", "Street", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "SurName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
