using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class VentasController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Ventas
        public ActionResult Index()
        {
            ViewBag.Ventas = db.Ventas.ToList();
            return View();
        }

        public  ActionResult DetalleVentas(int Id)
        {
            ViewBag.Detalle = db.Ventas.Find(Id).DetalleVentas;

            return View();
        }
    }
}