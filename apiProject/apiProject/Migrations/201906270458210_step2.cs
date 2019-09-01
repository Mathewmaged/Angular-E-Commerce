namespace apiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "subTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "DeliverDate");
            DropColumn("dbo.Orders", "TotalOrderCash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TotalOrderCash", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "DeliverDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "subTotal");
            DropColumn("dbo.Orders", "Price");
            DropColumn("dbo.Orders", "Quantity");
        }
    }
}
