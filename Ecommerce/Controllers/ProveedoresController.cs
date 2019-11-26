using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProveedoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Proveedores
        public ActionResult Historial_Compras()
        {
            ViewBag.proveedores = db.Provedores.ToList();
            return View();
        }
        // GET: Proveedores
        public ActionResult Index()
        {
            ViewBag.proveedores = db.Provedores.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear([Bind(Include = "Id,Nombre,Telefono,Correo,Compras")] Provedores proveedor)
        {
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
            var productos = db.Productos.AsQueryable();
            return View(await productos.ToListAsync());           
        }
        // POST: Productos/Comprar
        [HttpPost, ActionName("Comprar")]
        public ActionResult Comprar()
        {
            ICollection<DetalleCompras> compras_list = new List<DetalleCompras>();
            double total = 0;
            List<DetalleCompras> detalle_proxy = (List<DetalleCompras>)Session["detalle_compras"];
            foreach (DetalleCompras det_proxy in detalle_proxy)
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
                    SubTotal = (det_proxy.Productos.Precio_final * det_proxy.Cantidad),
                };
                compras_list.Add(dcompra);
            }
            Provedores prove = (Provedores)Session["proveedores"];
            Compras compras = new Compras {
                DetallesCompras = compras_list,
                Provedores = prove,
                FechaCompra = DateTime.Now,
                Status= 1,
                TipoPago=3,
                Total=total
            };
            
            db.Compras.Add(compras);
            db.SaveChanges();
            Session["proveedores"] = null;
            compras_list.Clear();
            Session["carro"] = compras_list;
            return Redirect("/Compras/Index");
        }
        //GET
        public async Task<ActionResult> Agregar_Compra(int? id)
        {
            var productos = db.Productos.AsQueryable();
            if (id == null)
            {

                return View(await productos.ToListAsync());
            }

            productos = productos.Where(x => x.Id == id);
            if (Session["detalle_compras"] == null)
            {
                List<DetalleCompras> detalle_compras = new List<DetalleCompras>();
                detalle_compras.Add(new DetalleCompras { Productos = productos.FirstOrDefault(), Cantidad = 1 });
                Session["detalle_compras"] = detalle_compras;
            }
            else
            {
                List<DetalleCompras> detalle_compras = (List<DetalleCompras>)Session["detalle_compras"];
                int index = isExist(id);
                if (index != -1)
                {
                    detalle_compras[index].Cantidad++;
                }
                else
                {
                    detalle_compras.Add(new DetalleCompras { Productos = productos.FirstOrDefault(), Cantidad = 1 });
                }
                Session["detalle_compras"] = detalle_compras;
            }
            return RedirectToAction("Compra_proveedor");
        }
        public ActionResult Cantidad(int Id, int cantidad)
        {
            List<DetalleCompras> compras= (List<DetalleCompras>)Session["detalle_compras"];
            int index = isExist(Id);
            if (index != -1)
            {
                    compras[index].Cantidad=cantidad;
            }
            return RedirectToAction("Index");
        }
        private int isExist(int? id)
        {
            List<DetalleCompras> carro = (List<DetalleCompras>)Session["detalle_compras"];
            for (int i = 0; i < carro.Count; i++)
            {
                if (carro[i].Productos.Id.Equals(id))
                    return i;
            }
            return -1;
        }
    }
}