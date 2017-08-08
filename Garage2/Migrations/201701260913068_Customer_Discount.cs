namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer_Discount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Discount", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Discount");
        }
    }
}
