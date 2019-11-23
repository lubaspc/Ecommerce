using Ecommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {

            ViewBag.Usuarios = db.Users.ToList();
            ViewBag.Roles = db.Roles.ToList();
            ViewBag.Direcciones = db.Direccion.ToList();
            return View();
        }

        public ActionResult HomeAdmin()
        {
            return View();
        }

        public ActionResult ModificaEstado(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindById(id);

            user.Active = !user.Active;

            var resul = userManager.Update(user);

            return RedirectToAction("Index", "User");
        }


        //GET
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (IdentityRole rol in db.Roles.ToList()) {
                lst.Add(new SelectListItem() { Text = rol.Name , Value = rol.Name });
            }

            ViewBag.Roles = lst;
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterViewModel model, String Rol)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Male = model.Male, Nombre = model.Nombre, FechaNaciemiento = model.FechaNaciemiento, Active = true, Direccion = model.Direccion };
                var result = userManager.Create(user, model.Password);

                if (result.Succeeded)
                {

                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        var clienteid = userManager.FindByEmail(model.Email).Id;
                        userManager.AddToRole(clienteid, Rol);
                    }

                    return RedirectToAction("Index", "User");
                }
                AddErrors(result);
            }
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}