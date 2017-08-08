namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextKoszyk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElementKoszykas",
                c => new
                    {
                        IdElementuKoszyka = c.Int(nullable: false, identity: true),
                        IdSesjiKoszyka = c.String(),
                        IdTowaru = c.Int(nullable: false),
                        Ilosc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataUtworzenia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdElementuKoszyka)
                .ForeignKey("dbo.Towars", t => t.IdTowaru, cascadeDelete: true)
                .Index(t => t.IdTowaru);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ElementKoszykas", "IdTowaru", "dbo.Towars");
            DropIndex("dbo.ElementKoszykas", new[] { "IdTowaru" });
            DropTable("dbo.ElementKoszykas");
        }
    }
}
