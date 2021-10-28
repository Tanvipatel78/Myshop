namespace MyshopDataccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pending_DB_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baskets", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.BasketItems", "BasketId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BasketItems", "BasketId", c => c.String(maxLength: 128));
            DropColumn("dbo.Baskets", "Quantity");
        }
    }
}
