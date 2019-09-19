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
            return View();
        }
    }
}