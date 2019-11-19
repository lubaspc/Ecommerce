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
            Catalogos dulce = new Catalogos { Id = 1, name = "Dulce" };
            Catalogos sal = new Catalogos { Id = 2, name = "Salado" };
            Catalogos trigo = new Catalogos { Id = 4, name = "Trigo" };
            Catalogos linaza = new Catalogos { Id = 5, name = "Linaza" };
            Catalogos champinon = new Catalogos { Id = 6, name = "Champiñon" };
            Catalogos reyes = new Catalogos { Id = 7, name = "Dia de Reyes" };
            Catalogos cupido = new Catalogos { Id = 8, name = "Dia de los Enamorados" };
            Catalogos Diademuertos = new Catalogos { Id = 9, name = "Dia de muertos" };
            Catalogos Navideno = new Catalogos { Id = 10, name = "Navidad" };

            db.Catalogos.AddOrUpdate(dulce);
            db.Catalogos.AddOrUpdate(sal);
            db.Catalogos.AddOrUpdate(trigo);
            db.Catalogos.AddOrUpdate(linaza);
            db.Catalogos.AddOrUpdate(champinon);
            db.Catalogos.AddOrUpdate(reyes);
            db.Catalogos.AddOrUpdate(cupido);
            db.Catalogos.AddOrUpdate(Diademuertos);
            db.Catalogos.AddOrUpdate(Navideno);


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
                Catalogos = new List<Catalogos> { dulce, trigo }
            };

            Productos producto2 = new Productos
            {
                Id = 2,
                Nombre = "Pan champan",
                Descripcion = "Pan relleno de champiñon",
                Url_image = "images/img3.jpg",
                Sabor = "Salado",
                Marca = "Cahampan",
                Costo_unitario = 10,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 12,
                Catalogos = new List<Catalogos> { sal, trigo }


            };

            Productos producto3 = new Productos
            {
                Id = 3,
                Nombre = "Pan champan especial",
                Descripcion = "Pan hecho totalmente de champiñones",
                Url_image = "images/img4.jpg",
                Sabor = "Champiñones",
                Marca = "Champan",
                Costo_unitario = 5,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 10,
                Catalogos = new List<Catalogos> { champinon, sal }
            };

            Productos producto4 = new Productos
            {
                Id = 4,
                Nombre = "Pan artesanal",
                Descripcion = "Pan hecho con trigo y champiñones",
                Url_image = "images/img5.jpg",
                Sabor = "Dulce",
                Marca = "Champan",
                Costo_unitario = 6,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 12,
                Catalogos = new List<Catalogos> { champinon, trigo }
            };

            Productos producto5 = new Productos
            {
                Id = 5,
                Nombre = "Pan con champiñones",
                Descripcion = "Pan relaborado con linaza horneado, acompañado de lechuga y champiñones",
                Url_image = "images/img6.jpg",
                Sabor = "Salado",
                Marca = "Champan",
                Costo_unitario = 12,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 20,
                Catalogos = new List<Catalogos> { trigo, champinon }

            };

            Productos producto6 = new Productos
            {
                Id = 6,
                Nombre = "Pan horneado con champiñones",
                Descripcion = "Pan horneado con champiñones",
                Url_image = "images/img7.jpg",
                Sabor = "Salado",
                Marca = "Champan",
                Costo_unitario = 10,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 15,
                Catalogos = new List<Catalogos> { linaza, champinon }
            };

            Productos producto7 = new Productos
            {
                Id = 7,
                Nombre = "Pan horneado de linaza",
                Descripcion = "Pan horneado elaborado de linaza creado artesanalmente",
                Url_image = "images/img8.jpg",
                Sabor = "Dulce",
                Marca = "Champan",
                Costo_unitario = 5,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 9,
                Catalogos = new List<Catalogos> { linaza, dulce }
            };

            Productos producto8 = new Productos
            {
                Id = 8,
                Nombre = "Pan horneado de trigo",
                Descripcion = "Pan horneado de trigo con un toque de champiñones",
                Url_image = "images/img9.jpg",
                Sabor = "Champiñon",
                Marca = "Champan",
                Costo_unitario = 10,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 15,
                Catalogos = new List<Catalogos> { trigo, champinon }
            };

            Productos producto9 = new Productos
            {
                Id = 9,
                Nombre = "Pan trigo",
                Descripcion = "Pan horneado de trigo elaborado artesanalmente",
                Url_image = "images/img10.jpg",
                Sabor = "Trigo",
                Marca = "Champan",
                Costo_unitario = 6,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 10,
                Catalogos = new List<Catalogos> { trigo }
            };

            Productos producto10 = new Productos
            {
                Id = 10,
                Nombre = "Pan especial champan",
                Descripcion = "Pan elaborado 100 % de champiñones horneado",
                Url_image = "images/img11.jpg",
                Sabor = "Champiñones",
                Marca = "Champan",
                Costo_unitario = 15,
                Porcentage_descuento = 0,
                Status = 1,
                Precio_final = 25,
                Catalogos = new List<Catalogos> { champinon, sal }
            };

            db.Productos.AddOrUpdate(producto1);
            db.Productos.AddOrUpdate(producto2);
            db.Productos.AddOrUpdate(producto3);
            db.Productos.AddOrUpdate(producto4);
            db.Productos.AddOrUpdate(producto5);
            db.Productos.AddOrUpdate(producto6);
            db.Productos.AddOrUpdate(producto7);
            db.Productos.AddOrUpdate(producto8);
            db.Productos.AddOrUpdate(producto9);
            db.Productos.AddOrUpdate(producto10);

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

   
    }
}
