using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var iduser = User.Identity.GetUserId();

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                if (userManager.IsInRole(iduser, "Empleado"))
                {
                    
                    return RedirectToAction("Home", "Empleados");
                }
                else
                {
                    //Cliente logeado
                    ViewBag.Sales = db.Productos.Where(p => p.Cantidad_ventas > 0).OrderBy(p => p.Cantidad_ventas).ToList();
                    ViewBag.Sale = db.Productos.Where(p => p.Cantidad_ventas > 0).OrderBy(p => p.Cantidad_ventas).First();
                    ViewBag.Offers = db.Productos.Where(p => p.Porcentage_descuento > 0).OrderBy(p => p.Porcentage_descuento).ToList();
                    ViewBag.Offer = db.Productos.Where(p => p.Porcentage_descuento > 0).OrderBy(p => p.Porcentage_descuento).First();
                    return View();
                }

            }
            else {
                ViewBag.Sales = db.Productos.Where(p => p.Cantidad_ventas > 0).OrderBy(p => p.Cantidad_ventas).ToList();
                ViewBag.Sale = db.Productos.Where(p => p.Cantidad_ventas > 0).OrderBy(p => p.Cantidad_ventas).First();
                ViewBag.Offers = db.Productos.Where(p => p.Porcentage_descuento > 0).OrderBy(p => p.Porcentage_descuento).ToList();
                ViewBag.Offer = db.Productos.Where(p => p.Porcentage_descuento > 0).OrderBy(p => p.Porcentage_descuento).First();
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.productos = db.Productos.ToList();
            return View();
        }

        public ActionResult Tienda(int? Id)
        {
            ICollection<Productos> productos;
            if (Id.HasValue)
            {
                var catalog = db.Catalogos.Find(Id);
                
                productos = catalog.Productos;
            }
            else
            {
               productos = db.Productos.ToList();
            }
            
            ViewBag.catalogos = db.Catalogos.ToList();
            ViewBag.productos = productos.ToList();
            ViewBag.metodos = new MetodosPago().MetodoPago;
            return View();
        }
    }
}