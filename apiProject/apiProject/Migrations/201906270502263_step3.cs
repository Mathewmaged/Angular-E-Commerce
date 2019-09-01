namespace apiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderUserProducts", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderUserProducts", "Quantity", c => c.Int(nullable: false));
        }
    }
}
