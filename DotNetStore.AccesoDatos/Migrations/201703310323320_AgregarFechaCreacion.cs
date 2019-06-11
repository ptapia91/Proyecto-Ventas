namespace DotNetStore.AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarFechaCreacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "FechaEdicion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "FechaEdicion");
        }
    }
}
