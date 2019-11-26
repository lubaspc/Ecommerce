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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ecommerce.Controllers
{
    public class EmpleadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Empleados

        public async Task<ActionResult> Index()
        {
            //Administrador de recursos humanos Director Administrativo
            ViewBag.Usuarios = db.Users.ToList();
            ViewBag.Roles = db.Roles.ToList();

            return View(await db.Empleados.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = await db.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        public ActionResult ModificaEstado(int id)
        {
            Empleados empleado = db.Empleados.Find(id);

            empleado.Active = !empleado.Active;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Roles = db.Roles.ToList();
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Id_users,Nombre,Sexo,Salario,Puesto,Area,Fecha_Nacimeinto,Estado,Municipio,CodigoPostal,Colonia,Calle,NoInterior,NoExterior,Referencia,Active,Registro_completo")] Empleados empleados, string[] roles, string Email, string Password, string ConfirmPassword, string UserName)
        {

            if (ModelState.IsValid)
            {
                if (Password.Equals(ConfirmPassword)) {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                    var user = new ApplicationUser { UserName = UserName, Email = Email };
                    var result = userManager.Create(user, Password);



                    if (result.Succeeded)
                    {

                        if (roles != null)
                        {
                            for (int i = 0; i < roles.Length; i++)
                            {
                                userManager.AddToRole(user.Id, roles[i]);
                            }
                        }


                        empleados.Active = true;
                        empleados.Id_users = user.Id;
                        empleados.Fecha_Nacimeinto = new DateTime(1997, 1, 1);
                        db.Empleados.Add(empleados);
                        await db.SaveChangesAsync();
                    }

                }
                
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = await db.Empleados.FindAsync(id);

            List <string> rolesA = new List <string>();
            List <string> rolesB = new List <string>();

            foreach (IdentityRole rol in db.Roles.ToList())
            {
                if (userManager.IsInRole(empleados.Id_users, rol.Name))
                {
                    rolesA.Add(rol.Name);
                }
                else {
                    rolesB.Add(rol.Name);
                }
            }
            ViewBag.Usuarios = db.Users.ToList();
            //ViewBag.Roles = db.Roles.ToList();
            ViewBag.rolesActuales = rolesA;
            ViewBag.rolesFaltantes = rolesB;

            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Id_users,Nombre,Sexo,Salario,Puesto,Area,Fecha_Nacimeinto,Estado,Municipio,CodigoPostal,Colonia,Calle,NoInterior,NoExterior,Referencia,Active,Registro_completo")] Empleados empleados, string[] roles, string Password, string ConfirmPassword, string UserName)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var user = userManager.FindById(empleados.Id_users);
                user.UserName = UserName;

                if (!Password.Equals("") ) {
                    if (Password.Equals(ConfirmPassword)) {
                        userManager.RemovePassword(user.Id);
                        userManager.AddPassword(user.Id, Password);
                    }
                }

                if (roles != null)
                {
                    foreach (IdentityRole rol in  db.Roles.ToList()) {
                        if (userManager.IsInRole(user.Id, rol.Name)) {
                            userManager.RemoveFromRole(user.Id, rol.Name);
                        }
                    }
                    
                    for (int i = 0; i < roles.Length; i++)
                    {
                        
                        userManager.AddToRole(user.Id, roles[i]);
                    }
                }

                db.Entry(empleados).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = await db.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empleados empleados = await db.Empleados.FindAsync(id);
            db.Empleados.Remove(empleados);
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
