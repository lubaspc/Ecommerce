namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ecommerce.Models;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Ecommerce.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ecommerce.Models.ApplicationDbContext context)
        {
            SeedCatagoProductos(context);
            SeedUsersAndRoles(context);
        }

        private void SeedCatagoProductos(ApplicationDbContext db)
        {
            Catalogos dulce = new Catalogos {Id = 1, name = "Dulce" };
            Catalogos sal = new Catalogos {Id =2, name = "Sal" };
            Catalogos pasteles = new Catalogos {Id = 3, name = "Pasteles" };
            db.Catalogos.AddOrUpdate(dulce);
            db.Catalogos.AddOrUpdate(sal); 
            db.Catalogos.AddOrUpdate(pasteles);

            Productos producto1 = new Productos
            {
                Id = 1,
                Nombre = "concha",
                Descripcion = "Tradicional",
                Url_image = "img/panaderia2.jpg",
                Sabor = "dulce",
                Marca = "Propia",
                Costo_unitario = 6.5,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 8,
                Catalogos = new List<Catalogos> { dulce, pasteles }
            };


             db.Productos.AddOrUpdate(producto1);

            db.Productos.AddOrUpdate(new Productos
            {
                Id = 2,
                Nombre = "cocol",
                Descripcion = "Tradicional",
                Url_image = "img/panaderia2.jpg",
                Sabor = "dulce",
                Marca = "Propia",
                Costo_unitario = 5.5,
                Porcentage_descuento = 5,
                Status = 1,
                Precio_final = 6.5,
                Catalogos = new List<Catalogos> { sal }
            }) ;
        }

        
        private void SeedUsersAndRoles(ApplicationDbContext db) {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //Crea roles

            var rolCliente = roleManager.Create(new IdentityRole("Cliente"));
            var rolAdmin = roleManager.Create(new IdentityRole("Administrador"));
            var rolProductos = roleManager.Create(new IdentityRole("Control Productos"));
            var rolProvedores = roleManager.Create(new IdentityRole("Control Provedores"));


            //Crear usuario
            var userCliente = new ApplicationUser();

            userCliente.UserName = "lubinpc@gmail.com";
            userCliente.Nombre = "Lubin";
            userCliente.Email = "lubinpc@gmail.com";
            userCliente.Male = true;
            userCliente.FechaNaciemiento = new DateTime(1997,2,5,0,0,0);
            userCliente.Active = true;

            userCliente.Direccion = new Direccion
            {
                Calle = "5 de mayo",
                CodigoPostal = 46190,
                Colonia= "Centro",
                Estado= "Tlaxcala",
                Municipio= "Tetlatlahuca",
                NoExterior= 1,
                NoInterior= 1,
                Referencia= "Puerta azul"
            };

            var resul_cliente = userManager.Create(userCliente, "prueba");

          

            //Asignar roles

            var clienteid = userManager.FindByEmail("lubinpc@gmail.com").Id;
            userManager.AddToRole(clienteid, "Cliente");

        }

   
    }
}
