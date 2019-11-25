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

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Productos productos = await db.Productos.FindAsync(id);
            db.Productos.Remove(productos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //GET
        public async Task<ActionResult> Compra_proveedor(int? id)
        {
            Provedores provee = await db.Provedores.FindAsync(id);
            ViewBag.Compra_proveedor = provee;

            if (provee == null)
            {
                return HttpNotFound();
            }
            return View();
        }
    }
}