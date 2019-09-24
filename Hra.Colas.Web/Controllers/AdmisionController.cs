using Hra.Colas.Datos;
using Hra.Colas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hra.Colas.Web.Controllers
{
    [Autenticado]
    public class AdmisionController : Controller
    {
        public ActionResult Index()
        {
            var uid = Comun.SessionHelper.GetUser();
            return View(VentanillaBL.Obtener(x => x.UsuarioId == uid, includeProperties: "Bloque"));
        }
        public ActionResult ObtenerNroCola(int servicioId, int ventanillaId)
        {
            var cola = ColaBL.Contar(x => x.ServicioId == servicioId && x.IndAtendido == false
            && x.Fecha.Year == DateTime.Now.Year && x.Fecha.Month == DateTime.Now.Month && x.Fecha.Day == DateTime.Now.Day
            );
            var atendidos = ColaVentanillaBL.Contar(x => x.VentanillaId == ventanillaId && x.IndAtendido
            && x.Fecha.Year == DateTime.Now.Year && x.Fecha.Month == DateTime.Now.Month && x.Fecha.Day == DateTime.Now.Day
            );
            var ausentes = ColaVentanillaBL.Contar(x => x.VentanillaId == ventanillaId && x.IndAtendido == false
            && x.Fecha.Year == DateTime.Now.Year && x.Fecha.Month == DateTime.Now.Month && x.Fecha.Day == DateTime.Now.Day
            );

            return Json(new { cola, atendidos, ausentes }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LlamarCola(int servicioId)
        {
            var s = ColaBL.LlamarCola(servicioId);
            return Json(new { s.Codigo, s.ServicioId, s.Id }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Atender(int colaId, int ventanillaId, int servicioId, bool atendido)
        {
            ColaVentanillaBL.Crear(new ColaVentanilla {
                Fecha = DateTime.Now,
                ColaId = colaId,
                VentanillaId = ventanillaId,
                IndAtendido = atendido
            });
            ColaBL.ActualizarParcial(new Cola { Id = colaId, IndAtendido = true }, x => x.IndAtendido);
            //return Json(true, JsonRequestBehavior.AllowGet);
            return ObtenerNroCola(servicioId, ventanillaId);
        }
    }
}