using Hra.Colas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hra.Colas.Web.Controllers
{
    public class VentanillaController : Controller
    {
        
        public ActionResult Index()
        {
            return View(VentanillaBL.Listar( includeProperties:"Bloque" ));
            //return View(BloqueBL.Listar());
        }
    }
}