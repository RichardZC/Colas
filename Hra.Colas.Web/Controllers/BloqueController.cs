using Hra.Colas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hra.Colas.Web.Controllers
{
    public class BloqueController : Controller
    {
        // GET: Bloque
        public ActionResult Index()
        {
            return View(BloqueBL.Listar());
        }
        public ActionResult Mantener(int id = 0)
        {
            ViewBag.cboRol = new SelectList(BloqueBL.Listar(null, x => x.OrderByDescending(y => y.Id)), "Id", "Denominacion");

            if (id == 0)
                return View(new Datos.Bloque() { Activo = true, IndCambio = false });
            else
                return View(BloqueBL.Obtener(id));
        }
        [HttpPost]
        public ActionResult Guardar(Datos.Bloque bloque, string activo)
        {
            var rm = new Comun.ResponseModel();
            bloque.Activo = string.IsNullOrEmpty(activo) ? false : true;
            try
            {
                if (bloque.Id == 0)
                {

                    //usuario.IndCambio = false;
                    //usuario.Activo = true;
                    BloqueBL.Crear(bloque);
                }
                else
                {
                    BloqueBL.ActualizarParcial(bloque, x => x.Denominacion, x => x.Id);
                }
                rm.SetResponse(true);
                rm.href = Url.Action("Index", "Bloque");

            }
            catch (Exception ex)
            {
                rm.SetResponse(false, ex.Message);
            }
            return Json(rm, JsonRequestBehavior.AllowGet);
        }



        //public ActionResult Listar() {
        //    var user = UsuarioBL.Listar();

        //    return Json(user.Select(x => new { x.Id, x.Nombre }), JsonRequestBehavior.AllowGet);
    }

}