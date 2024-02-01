using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class SesionController : Controller
    {
        // GET: Sesion
        public ActionResult Sesion()
        {
            return View();
        }
        public ActionResult NoLogueado() {
            Session["UsuarioLogueado"] = false;
            Session["EsAdmin"] = false;
            return Json(new { mensaje = "¡Llamada exitosa!" });
        }
        [HttpPost]
        public ActionResult Logueado(bool EsAdmin, string Empleado)
        {
            Session["UsuarioLogueado"] = true;
            Session["EsAdmin"] = EsAdmin;
            Session["Empleado"]= Empleado;
            return Json(new { mensaje = "¡Llamada exitosa!" });
        }
    }
}