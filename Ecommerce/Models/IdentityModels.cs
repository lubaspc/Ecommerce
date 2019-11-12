using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ecommerce.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
      
        public bool Hombre { get; set; }
        public DateTime FechaNaciemiento { get; set; }
        public int NoTarjeta { get; set; }
        public int TipoTarjeta { get; set; }
        public string Titular { get; set; }
        [Required]
        public virtual Direccion Direccion { get; set; }
        public List<Ventas> Ventas { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


        
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
           
        }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Catalogos> Catalogos { get; set; }
        public DbSet<DetalleCompras> DetalleCompras { get; set; }
        public DbSet<DetalleVenta> DetalleVentas{ get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<MetodosPago> MetodosPagos{ get; set; }
        public DbSet<Compras> Compras{ get; set; }
        public DbSet<Provedores> Provedores{ get; set; }
       
        public static ApplicationDbContext Create()
        {
          
            return new ApplicationDbContext();
        }
    }
}