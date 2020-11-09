using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Filters;
using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
  
    public class estado_servicio_Controller : Controller
    {
        estado_servicio_Admin admin = new estado_servicio_Admin();
        // GET: estado_servicio_
        public ActionResult Index()
        {
            return View(admin.Consultar());
        }

        public ActionResult Detalle(int id)
        {
            return View(admin.Consultar(id));
        }

        public ActionResult Crear()
        {
            return View();
        }
        public ActionResult Guardar(estado_servicio modelo)
        {
            admin.Guardar(modelo);
            //return View("Crear",modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(estado_servicio modelo)
        {
            admin.Modificar(modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            estado_servicio modelo = admin.Consultar(id);
            admin.Eliminar(modelo);
            return View("Index", admin.Consultar());
        }
    }
}