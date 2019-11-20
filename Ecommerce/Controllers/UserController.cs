using Ecommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    }
}