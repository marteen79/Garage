namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zamowienie1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PozycjaZamowienias", "Ilosc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PozycjaZamowienias", "Ilosc", c => c.Int(nullable: false));
        }
    }
}
