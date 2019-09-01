namespace apiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "subTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "subTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
