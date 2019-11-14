using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Tienda(int? Id)
        {
            List<Productos> productos;
            if (Id.HasValue)
            {
                productos = db.Catalogos.Find(Id).Productos;
            }
            else
            {
               productos = db.Productos.ToList();
            }
            
            ViewBag.catalogos = db.Catalogos.ToList();
            ViewBag.productos = productos; 
            return View();
        }
    }
}