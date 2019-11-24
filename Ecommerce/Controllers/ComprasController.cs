using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Compras
        public async Task<ActionResult> Index()
        {
            return View(await db.Compras.ToListAsync()); 

        }
    }
}