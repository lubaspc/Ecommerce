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
            SeedProveedores(context);
            SeedEmpleados(context);
        }

        private void SeedEmpleados(ApplicationDbContext db) {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            roleManager.Create(new IdentityRole("Administrador"));
            roleManager.Create(new IdentityRole("Empleado"));


            var user_rh = new ApplicationUser { UserName = "Andrea", Email = "andreaRH@gmail.com" };
            var rh = userManager.Create(user_rh, "pruebaRH");

            if (rh.Succeeded) {

                userManager.AddToRole(user_rh.Id, "Empleado");

                Empleados w_rh = new Empleados();
                w_rh.Id_users = user_rh.Id;
                w_rh.Nombre = "Andrea Escobar Cazares";
                w_rh.Sexo = false;
                w_rh.Salario = 9000;
                w_rh.Puesto = "Administrador de recursos humanos";
                w_rh.Area = "Recursos Humanos";
                w_rh.Fecha_Nacimeinto = new DateTime(1988, 8, 29);
                w_rh.Estado = "Mexico";
                w_rh.Municipio = "Chimalhuaacan";
                w_rh.CodigoPostal = 51680;
                w_rh.Colonia = "Los Patos";
                w_rh.Calle = "5 de mayo";
                w_rh.NoInterior = 1;
                w_rh.NoExterior = 1;
                w_rh.Referencia = "Puerta azul";
                w_rh.Registro_Completo= true;
                w_rh.Active = true;

                db.Empleados.AddOrUpdate(w_rh);
            }

            

            var user_fi = new ApplicationUser();
            user_fi.Email = "alejandroFI@gmail.com";
            user_fi.UserName = "Alejandro";
            var fi = userManager.Create(user_fi, "pruebaFI");

            if (fi.Succeeded)
            {

                userManager.AddToRole(user_fi.Id, "Empleado");

                Empleados w_rh = new Empleados();
                w_rh.Id_users = user_fi.Id;
                w_rh.Nombre = "Alejandro Orihuela Becerril";
                w_rh.Sexo = true;
                w_rh.Salario = 10500;
                w_rh.Puesto = "Control finanzas";
                w_rh.Area = "Finanzas";
                w_rh.Fecha_Nacimeinto = new DateTime(1985, 6, 15);
                w_rh.Estado = "Mexico";
                w_rh.Municipio = "Metepec";
                w_rh.CodigoPostal = 52156;
                w_rh.Colonia = "Metepec";
                w_rh.Calle = "15 de mayo";
                w_rh.NoInterior = 5;
                w_rh.NoExterior = 2;
                w_rh.Referencia = "Puerta negra";
                w_rh.Registro_Completo = true;
                w_rh.Active = true;

                db.Empleados.AddOrUpdate(w_rh);
            }

            var user_al = new ApplicationUser();
            user_al.Email = "humbertoAL@gmail.com";
            user_al.UserName = "Humberto";
            var al = userManager.Create(user_al, "pruebaAL");

            if (al.Succeeded)
            {

                userManager.AddToRole(user_al.Id, "Empleado");

                Empleados w_rh = new Empleados();
                w_rh.Id_users = user_al.Id;
                w_rh.Nombre = "Humberto Segura Guzman";
                w_rh.Sexo = true;
                w_rh.Salario = 8500;
                w_rh.Puesto = "Control de almacen";
                w_rh.Area = "Almacen";
                w_rh.Fecha_Nacimeinto = new DateTime(1995, 10, 30);
                w_rh.Estado = "Mexico";
                w_rh.Municipio = "Metepec";
                w_rh.CodigoPostal = 52156;
                w_rh.Colonia = "Metepec";
                w_rh.Calle = "25 de mayo";
                w_rh.NoInterior = 2;
                w_rh.NoExterior = 5;
                w_rh.Referencia = "Puerta amarilla";
                w_rh.Registro_Completo = true;
                w_rh.Active = true;

                db.Empleados.AddOrUpdate(w_rh);
            }

            var user_ad = new ApplicationUser();
            user_ad.Email = "vianyAD@gmail.com";
            user_ad.UserName = "Vianey";
            var ad = userManager.Create(user_ad, "pruebaAD");

            if (ad.Succeeded)
            {

                userManager.AddToRoles(user_ad.Id, "Administrador", "Empleado");

                Empleados w_rh = new Empleados();
                w_rh.Id_users = user_ad.Id;
                w_rh.Nombre = "Vianey Jaimes Martinez";
                w_rh.Sexo = false;
                w_rh.Salario = 11500;
                w_rh.Puesto = "Director Administrativo";
                w_rh.Area = "Direccion";
                w_rh.Fecha_Nacimeinto = new DateTime(1987, 1, 25);
                w_rh.Estado = "Mexico";
                w_rh.Municipio = "Metepec";
                w_rh.CodigoPostal = 52789;
                w_rh.Colonia = "Metepec";
                w_rh.Calle = "25 de enero";
                w_rh.NoInterior = 9;
                w_rh.NoExterior = 9;
                w_rh.Referencia = "Puerta morada";
                w_rh.Registro_Completo = true;
                w_rh.Active = true;

                db.Empleados.AddOrUpdate(w_rh);
            }

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
                Porcentage_descuento = 5,
                Status = 1,
                Precio_final = 8,
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 12,
                Time_Day = 31,
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
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 11,
                Time_Day = 4,
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
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 1,
                Time_Day = 1,
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
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 3,
                Time_Day = 3,
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
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 5,
                Time_Day = 7,
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
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 3,
                Time_Day = 23,
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
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 5,
                Time_Day = 23,
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
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 10,
                Time_Day = 23,
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
                activo = true,
                Cantidad_ventas = 3,
                Time_Mount = 11,
                Time_Day = 13,
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
                activo = true,
                Cantidad_ventas = 10,
                Time_Mount = 12,
                Time_Day = 31,
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
        
       
        private void SeedProveedores(ApplicationDbContext db)
        {
            Provedores prove1 = new Provedores();
            prove1.Id = 1;
            prove1.Nombre = "Alejandro";
            prove1.Telefono = "7224124088";
            prove1.Correo = "alexseed2@hotmail.com";
            Provedores prove2 = new Provedores();
            prove2.Id = 2;
            prove2.Nombre = "CHARLY";
            prove2.Telefono = "7171717171";
            prove2.Correo = "charly@hotmail.com";
            db.Provedores.AddOrUpdate(prove1);
            db.Provedores.AddOrUpdate(prove2);
        }
   
    }
}
