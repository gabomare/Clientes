using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cargar = Request.QueryString["cargar"];
            Session["CargarListado"] = false;

            if (cargar != null) {
                Session["CargarListado"] = true;
            }
            bool logueado = Session["UsuarioLogueado"] as bool? ?? false;

            if (!logueado) {
                return RedirectToAction("Sesion", "Sesion");
                //return View("Error");
            }
            ViewBag.Title = "Home Page";

            return View("Index");
        }

    }
}
