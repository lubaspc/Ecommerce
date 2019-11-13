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

        public ActionResult Tienda()
        {
            var productos = db.Productos.ToList();
            ViewBag.catalogos = db.Catalogos.ToList();
            return View();
        }
<<<<<<< HEAD
<<<<<<< HEAD


    }
=======
>>>>>>> parent of a1b03cd... cambios 2

        public ActionResult Catalog(var)
        {

=======

        public ActionResult Catalog(var)
        {

>>>>>>> parent of a1b03cd... cambios 2
        }
    }
}