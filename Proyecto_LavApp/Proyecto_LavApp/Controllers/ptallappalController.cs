using Proyecto_LavApp.Datos;
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
            reserva_servicio_Admin admin = new reserva_servicio_Admin();
            var result = admin.ObtenerTotalReservas(); 

            return View(result);
        }

        public ActionResult PanelCliente()
        {
            return View();
        }
    }
}