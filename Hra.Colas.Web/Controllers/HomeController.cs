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

        public ActionResult ListarBloque()
        {
            return Json(Negocio.BloqueBL.Listar(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListarServicio(int pBloqueId)
        {
            return Json(Negocio.ServicioBL.Listar(x => x.BloqueId == pBloqueId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListarVentanilla(int pServicioId)
        {
            return Json(Negocio.VentanillaBL.Listar(x => x.ServicioId == pServicioId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult MantenerBloque(Datos.Bloque pBloque)
        {
            pBloque.Denominacion = pBloque.Denominacion.ToUpper();
           var bloque =  Negocio.BloqueBL.Guardar(pBloque);
           if (bloque == null) bloque = pBloque;

            return Json(bloque, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MantenerServicio(Datos.Servicio pServicio)
        {
            pServicio.Denominacion = pServicio.Denominacion.ToUpper();
            var servicio = Negocio.ServicioBL.Guardar(pServicio);
            if (servicio == null) servicio = pServicio;

            return Json(servicio, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MantenerVentanilla(Datos.Ventanilla pVentanilla)
        {
            pVentanilla.Denominacion = pVentanilla.Denominacion.ToUpper();

            if (pVentanilla.Id == 0)
                Negocio.VentanillaBL.Crear(pVentanilla);
            else
                Negocio.VentanillaBL.ActualizarParcial(pVentanilla, x => x.Denominacion, x => x.ServicioId);
            
            return Json(pVentanilla, JsonRequestBehavior.AllowGet);
        }

    }
}