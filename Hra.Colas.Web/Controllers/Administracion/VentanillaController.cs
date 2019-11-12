using Hra.Colas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hra.Colas.Web.Controllers
{
    [Autenticado]
    public class VentanillaController : Controller
    {
        // GET: Ventanilla
        public ActionResult Index()
        {
            return View(VentanillaBL.Listar( includeProperties:"Bloque,Usuario,Servicio" ));
       
        }
        public ActionResult Mantener(int id = 0)
        {
            ViewBag.cboUsuario = new SelectList(UsuarioBL.Listar(null, x => x.OrderByDescending(y => y.Id)), "Id", "Denominacion");
            ViewBag.cboServicio = new SelectList(ServicioBL.Listar(null, x => x.OrderByDescending(y => y.Id)), "Id", "Denominacion");

            ViewBag.cboBloque = new SelectList(BloqueBL.Listar(), "Id", "Denominacion");
            ViewBag.cboUsuario = new SelectList(UsuarioBL.Listar(), "Id", "NombreCompleto");
            ViewBag.cboServicio = new SelectList(ServicioBL.Listar(), "Id", "Denominacion");

            if (id == 0)
                return View(new Datos.Ventanilla() {  });
     
            else
                return View(VentanillaBL.Obtener(id));

        }

        [HttpPost]
        public ActionResult Guardar(Datos.Ventanilla ventanilla, string activo)
        {
            var rm = new Comun.ResponseModel();
          
            try
            {
                if (ventanilla.Id == 0)
                {
                    VentanillaBL.Crear(ventanilla);
                }
                else
                {
                    VentanillaBL.ActualizarParcial(ventanilla, x => x.Denominacion, x => x.BloqueId, x => x.UsuarioId, x => x.ServicioId);
                }
                rm.SetResponse(true);
                rm.href = Url.Action("Index", "Ventanilla");


            }
            catch (Exception ex)
            {
                rm.SetResponse(false, ex.Message);
            }
            return Json(rm, JsonRequestBehavior.AllowGet);
        }

    }
}

