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

namespace Ecommerce.Controllers
{
    public class CatalogosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Catalogos
        public async Task<ActionResult> Index()
        {
            return View(await db.Catalogos.ToListAsync());
        }

        // GET: Catalogos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogos catalogos = await db.Catalogos.FindAsync(id);
            if (catalogos == null)
            {
                return HttpNotFound();
            }
            return View(catalogos);
        }

        // GET: Catalogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,name")] Catalogos catalogos)
        {
            if (ModelState.IsValid)
            {
                db.Catalogos.Add(catalogos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(catalogos);
        }

        // GET: Catalogos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogos catalogos = await db.Catalogos.FindAsync(id);
            if (catalogos == null)
            {
                return HttpNotFound();
            }
            return View(catalogos);
        }

        // POST: Catalogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,name")] Catalogos catalogos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(catalogos);
        }

        // GET: Catalogos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogos catalogos = await db.Catalogos.FindAsync(id);
            if (catalogos == null)
            {
                return HttpNotFound();
            }
            return View(catalogos);
        }

        // POST: Catalogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Catalogos catalogos = await db.Catalogos.FindAsync(id);
            db.Catalogos.Remove(catalogos);
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
