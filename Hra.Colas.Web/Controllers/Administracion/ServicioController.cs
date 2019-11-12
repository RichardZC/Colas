using Hra.Colas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hra.Colas.Web.Controllers
{
    [Autenticado]
    public class ServicioController : Controller
    {
        // GET: Servicio
        public ActionResult Index()
        {
            return View(ServicioBL.Listar(includeProperties: "Bloque"));
        }


        public ActionResult Mantener(int id = 0)
        {
            ViewBag.cboBloque = new SelectList(BloqueBL.Listar(), "Id", "Denominacion");

            if (id == 0)
                return View(new Datos.Servicio() { Estado = true });
            else
                return View(ServicioBL.Obtener(id));
        }
        [HttpPost]
        public ActionResult Guardar(Datos.Servicio servicio, string activo)
        {
            var rm = new Comun.ResponseModel();
            servicio.Estado = string.IsNullOrEmpty(activo) ? false : true;
            try
            {
                if (servicio.Id == 0)
                {
                    ServicioBL.Crear(servicio);
                }
                else
                {
                    ServicioBL.ActualizarParcial(servicio, x => x.Denominacion, x => x.BloqueId, x => x.Estado);
                }
                rm.SetResponse(true);
                rm.href = Url.Action("Index", "Servicio");

            }
            catch (Exception ex)
            {
                rm.SetResponse(false, ex.Message);
            }
            return Json(rm, JsonRequestBehavior.AllowGet);
        }

    }
}