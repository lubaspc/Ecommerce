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
            SeedProveedores(context);
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

            //Client
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

            //Admin
            var userAdmin = new ApplicationUser();

            userAdmin.UserName = "cyescaz@gmail.com";
            userAdmin.Nombre = "Carlos";
            userAdmin.Email = "cyescaz@gmail.com";
            userAdmin.Male = true;
            userAdmin.FechaNaciemiento = new DateTime(1997, 2, 9, 0, 0, 0);
            userAdmin.Active = true;

            userAdmin.Direccion = new Direccion
            {
                Calle = "10 de mayo",
                CodigoPostal = 46192,
                Colonia = "San Pedro",
                Estado = "Mexico",
                Municipio = "Chimalhuacan",
                NoExterior = 1,
                NoInterior = 1,
                Referencia = "Puerta negra"
            };

            var resul_admin = userManager.Create(userAdmin, "prueba");

            //Control productos
            var userProd = new ApplicationUser();

            userProd.UserName = "diana@gmail.com";
            userProd.Nombre = "Diana";
            userProd.Email = "diana@gmail.com";
            userProd.Male = false;
            userProd.FechaNaciemiento = new DateTime(1960, 8, 8, 0, 0, 0); 
            userProd.Active = true;  

            userProd.Direccion = new Direccion
            {
                Calle = "25 de mayo",
                CodigoPostal = 46194,
                Colonia = "San Pablo",
                Estado = "Mexico",
                Municipio = "Chimalhuacan",
                NoExterior = 1,
                NoInterior = 1,
                Referencia = "Puerta roja"
            };

            var resul_prod = userManager.Create(userProd, "prueba");


            //Control Provedores
            var userProv = new ApplicationUser();

            userProv.UserName = "andrea@gmail.com";
            userProv.Nombre = "Andrea";
            userProv.Email = "andrea@gmail.com";
            userProv.Male = false;
            userProv.FechaNaciemiento = new DateTime(1960, 8, 29, 0, 0, 0);
            userProv.Active = true;

            userProv.Direccion = new Direccion
            {
                Calle = "30 de mayo",
                CodigoPostal = 46196,
                Colonia = "San Benito",
                Estado = "Mexico",
                Municipio = "Chimalhuacan",
                NoExterior = 1,
                NoInterior = 1,
                Referencia = "Puerta morada"
            };

            var resul_prov = userManager.Create(userProv, "prueba");




            //Asignar roles

            var clienteid = userManager.FindByEmail("lubinpc@gmail.com").Id;
            userManager.AddToRole(clienteid, "Cliente");

            var adminid = userManager.FindByEmail("cyescaz@gmail.com").Id;
            userManager.AddToRole(adminid, "Administrador");

            var prodid = userManager.FindByEmail("diana@gmail.com").Id;
            userManager.AddToRole(prodid, "Control Productos");

            var provid = userManager.FindByEmail("andrea@gmail.com").Id;
            userManager.AddToRole(provid, "Control Provedores");




        }
        private void SeedProveedores(ApplicationDbContext db)
        {
            Provedores prove1 = new Provedores();
            prove1.Id = 1;
            prove1.Nombre = "Alejandro";
            prove1.Telefono = "7224124088";
            prove1.Credito = 150000;
            

            prove1.Direccion = new Direccion
            {
                Calle = "Catarina",
                CodigoPostal = 46192,
                Colonia = "Santa Barbara",
                Estado = "ESTADO DE MEXICO",
                Municipio = "TOLUCA",
                NoExterior = 202,
                NoInterior = 202,
                Referencia = "Puerta negra"
            };
        }
   
    }
}
