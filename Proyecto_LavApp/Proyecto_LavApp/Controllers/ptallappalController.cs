using Proyecto_LavApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
    [Acceder]
    public class ptallappalController : Controller
    {
        // GET: ptallappal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PanelCliente()
        {
            return View();
        }
    }
}