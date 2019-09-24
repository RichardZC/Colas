using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hra.Colas.Web.Controllers
{
    [Autenticado]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var rol = Session["Rol"].ToString();
            if (rol == Negocio.Constante.Rol.Admision)
                return RedirectToAction("Index", "Admision");
            if (rol == Negocio.Constante.Rol.Medico)
                return RedirectToAction("Index", "Llamado");
            
            return View();
        }


    }
}