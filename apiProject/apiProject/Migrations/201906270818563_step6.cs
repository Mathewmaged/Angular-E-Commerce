namespace apiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderUserProducts", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "DeliverDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "TotalOrderCash", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "Name");
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "Price");
            DropColumn("dbo.Orders", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Name", c => c.String());
            DropColumn("dbo.Orders", "TotalOrderCash");
            DropColumn("dbo.Orders", "DeliverDate");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.OrderUserProducts", "Quantity");
        }
    }
}
