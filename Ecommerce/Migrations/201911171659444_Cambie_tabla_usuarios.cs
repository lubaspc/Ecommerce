namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambie_tabla_usuarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Sexo", c => c.String());
            DropColumn("dbo.AspNetUsers", "Hombre");
            DropColumn("dbo.AspNetUsers", "NoTarjeta");
            DropColumn("dbo.AspNetUsers", "TipoTarjeta");
            DropColumn("dbo.AspNetUsers", "Titular");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Titular", c => c.String());
            AddColumn("dbo.AspNetUsers", "TipoTarjeta", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NoTarjeta", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Hombre", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "Sexo");
        }
    }
}
