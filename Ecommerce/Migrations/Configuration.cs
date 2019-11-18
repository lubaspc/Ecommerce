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

            userCliente.UserName = "Lubin";
            userCliente.Email = "lubinpc@gmail.com";
            userCliente.Sexo = "Hombre";
            userCliente.FechaNaciemiento = new DateTime(1997,2,5,0,0,0);
            userCliente.Estado = "Tlaxcala";
            userCliente.Municipio = "Teltatlaucha";
            userCliente.Direccion = "Calle El Milagro s/n Colonia Centro";
            userCliente.CodigoPostal = "58960";
            userCliente.Status = "Activo";

            var resul_cliente = userManager.Create(userCliente, "PruebaCliente1");

            var userAdmin = new ApplicationUser();

            userAdmin.UserName = "Carlos";
            userAdmin.Email = "cyescaz@gmail.com";
            userAdmin.Sexo = "Hombre";
            userAdmin.FechaNaciemiento = new DateTime(1997, 2, 9, 0, 0, 0);
            userAdmin.Estado = "Mexico";
            userAdmin.Municipio = "Chimalhuacan";
            userAdmin.Direccion = "Calle Cenantli s/n Colonia Santa Elena";
            userAdmin.CodigoPostal = "56366";
            userAdmin.Status = "Activo";

            var resultado_admin = userManager.Create(userAdmin, "PruebaAdmin1");

            var userProductos = new ApplicationUser();

            userProductos.UserName = "Diana";
            userProductos.Email = "diana@gmail.com";
            userProductos.Sexo = "Mujer";
            userProductos.FechaNaciemiento = new DateTime(1960, 8, 8, 0, 0, 0);
            userProductos.Estado = "Mexico";
            userProductos.Municipio = "Nezahualcoyotl";
            userProductos.Direccion = "Av Los Patos s/n Barrio San Pedro";
            userProductos.CodigoPostal = "56660";
            userProductos.Status = "Activo";

            var resultado_productos = userManager.Create(userProductos, "PruebaProductos1");

            var userProvedores = new ApplicationUser();

            userProvedores.UserName = "Andrea";
            userProvedores.Email = "andrea@gmail.com";
            userProvedores.Sexo = "Mujer";
            userProvedores.FechaNaciemiento = new DateTime(1998, 8, 29, 0, 0, 0);
            userProvedores.Estado = "Mexico";
            userProvedores.Municipio = "Texcaltitlan";
            userProvedores.Direccion = "Calle 4 de Noviembre s/n Colonia Centro";
            userProvedores.CodigoPostal = "51670";
            userProvedores.Status = "Activo";

            var resultado_provedores = userManager.Create(userProvedores, "PruebaProvedores1");

            //Asignar roles

            var clienteid = userManager.FindByEmail("lubinpc@gmail.com").Id;
            userManager.AddToRole(clienteid, "Cliente");

            var adminid = userManager.FindByEmail("cyescaz@gmail.com").Id;
            userManager.AddToRole(adminid, "Administrador");

            var productosid = userManager.FindByEmail("diana@gmail.com").Id;
            userManager.AddToRole(productosid, "Control Productos");

            var provedoresid = userManager.FindByEmail("andrea@gmail.com").Id;
            userManager.AddToRole(provedoresid, "Control Provedores");
        }
    }
}
