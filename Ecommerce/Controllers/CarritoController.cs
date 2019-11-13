using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comprar(string id)
        {
            Productos productos = new Productos();
            if (Session["carro"] == null)
            {
                List<Carrito> carro = new List<Carrito>();
                carro.Add(new Carrito{ Productos = productos, Cantidad = 1 });
                Session["carro"] = carro;
            }
            else
            {
                List<Carrito> carro = (List<Carrito>)Session["carro"];
                int index = isExist(id);
                if (index != -1)
                {
                    carro[index].Cantidad++;
                }
                else
                {
                    carro.Add(new Carrito { Productos = productos, Cantidad = 1 });
                }
                Session["carro"] = carro;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(string id)
        {
            List<Carrito> carro = (List<Carrito>)Session["carro"];
            int index = isExist(id);
            carro.RemoveAt(index);
            Session["carro"] = carro;
            return RedirectToAction("Index");
        }

        private int isExist(String id)
        {
            List<Carrito> carro = (List<Carrito>)Session["carro"];
            for (int i = 0; i < carro.Count; i++)
            {
                if (carro[i].Productos.Id.Equals(id))
                    return i;
            }
            return -1;
        }
    }
}