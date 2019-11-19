using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProveedoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Proveedores
        public ActionResult Index()
        {
            ViewBag.proveedores = db.Provedores;
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}