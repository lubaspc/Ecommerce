using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class DbContex : DbContext
    {
        public DbSet<Productos> productos { get; set; }
        public DbSet<Catalogos> catalogos { get; set; }
    }
}