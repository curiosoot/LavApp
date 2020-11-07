using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
    public class marca_vehiculos_Controller : Controller
    {
        marca_vehiculos_Admin admin = new marca_vehiculos_Admin();
        // GET: marca_vehiculos_
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
        public ActionResult Guardar(marca_vehiculos modelo)
        {
            admin.Guardar(modelo);
            //return View("Crear",modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(marca_vehiculos modelo)
        {
            admin.Modificar(modelo);
            return View("Editar",modelo);
        }

        public ActionResult Eliminar(int id) 
        {
            marca_vehiculos modelo = admin.Consultar(id);
            admin.Eliminar(modelo);
            return View("Index",admin.Consultar());
        }
    }
}