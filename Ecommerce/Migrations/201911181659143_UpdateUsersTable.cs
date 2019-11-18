namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Direccion_Id", "dbo.Direccions");
            DropIndex("dbo.AspNetUsers", new[] { "Direccion_Id" });
            AddColumn("dbo.AspNetUsers", "Estado", c => c.String());
            AddColumn("dbo.AspNetUsers", "Municipio", c => c.String());
            AddColumn("dbo.AspNetUsers", "Direccion", c => c.String());
            AddColumn("dbo.AspNetUsers", "CodigoPostal", c => c.String());
            AddColumn("dbo.AspNetUsers", "Status", c => c.String());
            DropColumn("dbo.AspNetUsers", "Direccion_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Direccion_Id", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "CodigoPostal");
            DropColumn("dbo.AspNetUsers", "Direccion");
            DropColumn("dbo.AspNetUsers", "Municipio");
            DropColumn("dbo.AspNetUsers", "Estado");
            CreateIndex("dbo.AspNetUsers", "Direccion_Id");
            AddForeignKey("dbo.AspNetUsers", "Direccion_Id", "dbo.Direccions", "Id");
        }
    }
}
