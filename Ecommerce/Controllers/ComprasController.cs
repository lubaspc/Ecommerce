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
        public async Task<ActionResult> Index(string searchBy, string search,string sortBy)
        {
            ViewBag.StatusSort = String.IsNullOrEmpty(sortBy) ? "Status desc" : "";
            ViewBag.TipoPagoSort = sortBy == "TipoPago" ? "TipoPago desc" : "TipoPago";
            var compras = db.Compras.AsQueryable();

            if (searchBy == "TipoPago")
            {
                compras = compras.Where(x => x.TipoPago.ToString() == search || search == null);
            }
            else
            {
                compras = compras.Where(x => x.Status.ToString().StartsWith(search) || search == null);
            }

            switch (sortBy)
            {
                case "TipoPago":
                    compras = compras.OrderByDescending(x => x.TipoPago);
                    break;
                case "Status desc":
                    compras = compras.OrderByDescending(x => x.Status);
                    break;
                case "Status":
                    compras = compras.OrderBy(x => x.Status);
                    break;
                case "Nombre del proveedor":
                    compras = compras.OrderBy(x => x.Provedores.Nombre);
                    break;
                case "Fecha de Compra":
                    compras = compras.OrderBy(x => x.FechaCompra);
                    break;
                default:
                    compras = compras.OrderBy(x => x.Id);
                    break;
            }

            return View(await db.Compras.ToListAsync()); 

        }


        
    }
}