using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ecommerce.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public ActionResult Historial_Compras()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            ViewBag.proveedores = db.Provedores.ToList();
           
            return View();
        }
        // GET: Proveedores
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            ViewBag.proveedores = db.Provedores.ToList();
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear([Bind(Include = "Id,Nombre,Telefono,Correo,Compras")] Provedores proveedor)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            if (ModelState.IsValid)
            {
                db.Provedores.Add(proveedor);
                await db.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
            
            return View(proveedor);
        }
        public ActionResult Crear()
        {
            return View();
        }
        // GET: Provedores/Edit
        public async Task<ActionResult> Edit(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (id == null)
            {
              
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provedores provedores = await db.Provedores.FindAsync(id);
            if (provedores == null)
            {
               
                return HttpNotFound();
            }
          
            return View(provedores);
        }
        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Telefono,Correo,Compras")] Provedores proveedor)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                await db.SaveChangesAsync();
               
                return RedirectToAction("Index");
            }
            
            return View(proveedor);
        }
        // GET: Productos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            if (id == null)
            {
             
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provedores provedor = await db.Provedores.FindAsync(id);
            if (provedor == null)
            {
            
                return HttpNotFound();
            }
        
            return View(provedor);
        }

        
        //GET
        public async Task<ActionResult> Compra_proveedor(int? id)
        {

            if (id == null)
            {
                if (Session["proveedores"]==null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.Compra_proveedor = Session["proveedores"];
                   
                    ViewBag.Compra_detalles = Session["detalle_compras"];

                    return View();
                }
                
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();

                Provedores provee = await db.Provedores.FindAsync(id);
                Session["proveedores"] = provee;
                ViewBag.Compra_proveedor = Session["proveedores"];
      
                if (provee == null)
                {
                    return HttpNotFound();
                }
                return View();
            }
            
        }
        //GET
        public async Task<ActionResult> Agregar_Producto()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var productos = db.Productos.AsQueryable();
            return View(await productos.ToListAsync());           
        }
        // POST: Productos/Comprar
        [HttpPost, ActionName("Comprar")]
        public ActionResult Comprar()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            List<Carrito> detalle_proxy = (List<Carrito>)Session["detalle_compras"];
            
            double total = 0;
            ICollection<DetalleCompras> compras_list = new List<DetalleCompras>();
            foreach (Carrito det_proxy in detalle_proxy)
            {
                Productos producto = db.Productos.Find(det_proxy.Productos.Id);
                total += (det_proxy.Productos.Costo_unitario * det_proxy.Cantidad);
                DateTime vencimiento = DateTime.Now;
                vencimiento = vencimiento.AddMonths(producto.Time_Mount);
                vencimiento = vencimiento.AddDays(producto.Time_Day);
                DetalleCompras dcompra = new DetalleCompras
                {
                    Fecha_vencimiento= vencimiento,
                    Cantidad = det_proxy.Cantidad,
                    PorcentajeDescuento = 0,
                    PorcentajeIncremnto = 0,
                    Productos = producto,
                    SubTotal = (det_proxy.Productos.Precio_final * det_proxy.Cantidad)
                };
                compras_list.Add(dcompra);
            }
            Provedores prove = (Provedores)Session["proveedores"];
            Provedores prueba = db.Provedores.Where(x => x.Id == prove.Id).FirstOrDefault();         
            Compras compras = new Compras {
                DetallesCompras = compras_list,
                Provedores = prueba,
                FechaCompra = DateTime.Now,
                Status= 1,
                TipoPago=2,
                Total=total
            };
      
            db.Compras.Add(compras);
            
            db.SaveChangesAsync();

            Session["proveedores"] = null;
            Session["detalle_compras"] = null;
          
            return Redirect("/Compras/Index");
        }
        //GET
        public async Task<ActionResult> Agregar_Compra(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var productos = db.Productos.AsQueryable();
            if (id == null)
            {
                
                return View(await productos.ToListAsync());
            }

            productos = productos.Where(x => x.Id == id);
            if (Session["detalle_compras"] == null)
            {
                List<Carrito> carrito = new List<Carrito>();
                carrito.Add(new Carrito { Productos = productos.FirstOrDefault(), Cantidad = 1 });
                Session["detalle_compras"] = carrito;
            }
            else
            {
                List<Carrito> carrito = (List<Carrito>)Session["detalle_compras"];
                int index = isExist(id);
                if (index != -1)
                {
                    carrito[index].Cantidad++;
                }
                else
                {
                    carrito.Add(new Carrito { Productos = productos.FirstOrDefault(), Cantidad = 1 });
                }
                Session["detalle_compras"] = carrito;
            }
          
            return RedirectToAction("Compra_proveedor");
        }
        public ActionResult Cantidad(int Id, int cantidad)
        {
            List<Carrito> compras= (List<Carrito>)Session["detalle_compras"];
            int index = isExist(Id);
            if (index != -1)
            {
                    compras[index].Cantidad=cantidad;
            }
            return RedirectToAction("Index");
        }
        private int isExist(int? id)
        {
            List<Carrito> carro = (List<Carrito>)Session["detalle_compras"];
            for (int i = 0; i < carro.Count; i++)
            {
                if (carro[i].Productos.Id.Equals(id))
                    return i;
            }
            return -1;
        }
    }
}