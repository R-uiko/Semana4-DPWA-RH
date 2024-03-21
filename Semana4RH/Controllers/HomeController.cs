using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//llamar nuestro modelo
using Semana4RH.Models; 

namespace Semana4RH.Controllers
{
    public class HomeController : Controller
    {
        DAOUsuario dao = new DAOUsuario();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult helper()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult recibeForm(string txtNombre, string txtPass, string combo)
        {

            string nombre = txtNombre;
            string pass = txtPass;
            string nivel = combo;


            return RedirectToAction("helper");
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Usuarios(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                if(dao.insertar(u))
                {
                    ViewBag.ins = "true";
                    ViewBag.user = u.username;
                }
                else
                {
                    ViewBag.ins = "false";
                }
            }


            return View();
        }
        //---------------- actualizar y Eliminar--------------------- no se como lo queria que ejecutemos ya que es una pagina de login
        [HttpPost]
        public ActionResult ActualizarUsuario(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                if (dao.actualizar(u))
                {
                    ViewBag.actualizacion = "true";
                    ViewBag.user = u.username;
                }
                else
                {
                    ViewBag.actualizacion = "false";
                }
            }

            return View("Usuarios", u);
        }

        [HttpPost]
        public ActionResult EliminarUsuario(int userId)
        {
            if (dao.eliminar(userId))
            {
                ViewBag.eliminacion = "true";
            }
            else
            {
                ViewBag.eliminacion = "false";
            }

            return RedirectToAction("Usuarios");
        }
    }
}
