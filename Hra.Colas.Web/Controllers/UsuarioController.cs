using Hra.Colas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hra.Colas.Web.Controllers
{
    [Autenticado]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View(UsuarioBL.Listar());
        }
        public ActionResult Mantener(int id=0)
        {
            ViewBag.cboRol = new SelectList(RolBL.Listar(null, x => x.OrderByDescending(y => y.Id)), "Id", "Denominacion");

            if (id == 0)
                return View(new Datos.Usuario() { Activo = true, IndCambio = false });
            else
                return View(UsuarioBL.Obtener(id));
        }
        [HttpPost]
        public ActionResult Guardar(Datos.Usuario usuario,string activo)
        {
            var rm = new Comun.ResponseModel();
            usuario.Activo = string.IsNullOrEmpty(activo) ? false : true;
            try
            {
                if (usuario.Id == 0)
                {
                    usuario.Clave = usuario.Correo;
                    usuario.IndCambio = false;
                    usuario.Activo = true;
                    UsuarioBL.Crear(usuario);
                }
                else
                {
                    UsuarioBL.ActualizarParcial(usuario, x => x.NombreCompleto, x => x.Correo, x => x.Celular, x => x.Activo, x => x.RolId);
                }
                rm.SetResponse(true);
                rm.href = Url.Action("Index", "Usuario");
                
            }
            catch (Exception ex)
            {
                rm.SetResponse(false,ex.Message);                
            }
            return Json(rm, JsonRequestBehavior.AllowGet);
        }

       

        //public ActionResult Listar() {
        //    var user = UsuarioBL.Listar();

        //    return Json(user.Select(x => new { x.Id, x.Nombre }), JsonRequestBehavior.AllowGet);
        //}
    }
}