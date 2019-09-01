namespace apiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "DeliverDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "DeliverDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
