using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
    public class tipo_vehiculos_Controller : Controller
    { 
        tipo_vehiculos_Admin admin = new tipo_vehiculos_Admin();
        // GET: tipo_vehiculos_
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
        public ActionResult Guardar(tipo_vehiculos_Cls modelo)
        {
            admin.Guardar(modelo);
            //return View("Crear",modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(tipo_vehiculos_Cls modelo)
        {
            admin.Modificar(modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            tipo_vehiculos_Cls modelo = admin.Consultar(id);
            admin.Eliminar(modelo);
            return View("Index", admin.Consultar());
        }
    }
}