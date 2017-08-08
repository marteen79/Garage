namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hours_update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyProfiles",
                c => new
                    {
                        CompanyProfileId = c.Int(nullable: false, identity: true),
                        ProfileContent = c.String(),
                    })
                .PrimaryKey(t => t.CompanyProfileId);
            
            CreateTable(
                "dbo.Hours",
                c => new
                    {
                        HourId = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        Hours = c.String(),
                    })
                .PrimaryKey(t => t.HourId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OfferId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Jakosc = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Offers");
            DropTable("dbo.Hours");
            DropTable("dbo.CompanyProfiles");
        }
    }
}
