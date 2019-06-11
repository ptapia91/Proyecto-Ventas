namespace DotNetStore.AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCreacion = c.DateTime(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Productoes", new[] { "CategoriaID" });
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
