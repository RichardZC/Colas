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
    }
}