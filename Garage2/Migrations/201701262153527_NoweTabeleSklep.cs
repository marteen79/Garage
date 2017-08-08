namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoweTabeleSklep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rodzajs",
                c => new
                    {
                        IdRodzaju = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 20),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.IdRodzaju);
            
            CreateTable(
                "dbo.Towars",
                c => new
                    {
                        IdTowaru = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Kod = c.String(nullable: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FotoUrl = c.String(nullable: false),
                        Opis = c.String(),
                        Promocja = c.Boolean(nullable: false),
                        IdRodzaju = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTowaru)
                .ForeignKey("dbo.Rodzajs", t => t.IdRodzaju, cascadeDelete: true)
                .Index(t => t.IdRodzaju);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Towars", "IdRodzaju", "dbo.Rodzajs");
            DropIndex("dbo.Towars", new[] { "IdRodzaju" });
            DropTable("dbo.Towars");
            DropTable("dbo.Rodzajs");
        }
    }
}
