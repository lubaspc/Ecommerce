using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using System.IO;

namespace Ecommerce.Controllers
{
    public class Productos1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Productos1
        public async Task<ActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "DateTime" ? "date_desc" : "DateTime";
            var productos = from s in db.Productos select  s;
            switch (sortOrder) {
                case "name_desc":
                    productos = productos.OrderByDescending(s => s.Nombre);
                    break;
                case "DateTime":
                    productos = productos.OrderBy(s => s.Fecha_caducidad);
                    break;
                case "date_desc":
                    productos = productos.OrderByDescending(s => s.Fecha_caducidad);
                    break;
                default:
                    productos = productos.OrderBy(s => s.Nombre);
                    break;
            }

            return View(await productos.AsNoTracking().ToListAsync());
        }

        // GET: Productos1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Descripcion,Url_image,Sabor,stock,Marca,Costo_unitario,Porcentage_descuento,Status,Fecha_caducidad,Precio_final,Cantidad_ventas")] Productos productos,HttpPostedFileBase file)
        {

            
            //var filename = Path.GetFileName(file.FileName);
            //var path = Path.Combine(Server.MapPath("~/Content/img/"), filename);
            //file.SaveAs(filename);
            //productos.Url_image = string.Concat("Content/img/", filename);
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                productos.Url_image = "~/Content/img/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                file.SaveAs(fileName);
                db.Productos.Add(productos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productos);
        }

        // GET: Productos1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Descripcion,Url_image,Sabor,stock,Marca,Costo_unitario,Porcentage_descuento,Status,Fecha_caducidad,Precio_final,Cantidad_ventas")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productos);
        }

        // GET: Productos1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Productos productos = await db.Productos.FindAsync(id);
            db.Productos.Remove(productos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
