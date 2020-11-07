using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
    public class usuarios_Controller : Controller
    {
        List<SelectListItem> listpersonas;

        usuarios_Admin admin = new usuarios_Admin();
        // GET: usuarios_
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
            llenar_personas();
            ViewBag.lista = listpersonas;
            return View();
        }
        public ActionResult Guardar(usuarios modelo)
        {
            if (!ModelState.IsValid)
            {
                llenar_personas();
                ViewBag.lista = listpersonas;
                return View(modelo);
            }
            else
            {
                admin.Guardar(modelo);
                //return View("Crear", modelo);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar(int id)
        {
            llenar_personas();
            ViewBag.lista = listpersonas;
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(usuarios modelo)
        {
            admin.Modificar(modelo);
            llenar_personas();
            ViewBag.lista = listpersonas;
            return View("Editar", modelo);
        }

        public ActionResult Eliminar(int id)
        {
            usuarios modelo = admin.Consultar(id);
            admin.Eliminar(modelo);
            return View("Index", admin.Consultar());
        }

        private void llenar_personas()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listpersonas = (from personas in contexto.personas
                                 //where personas.id_persona in 
                                 select new SelectListItem
                                 {
                                     Text =  personas.txt_apellido1 + " " + personas.txt_apellido2 + " " + personas.txt_nombre,
                                     Value = personas.id_persona.ToString()
                                 }).ToList();
                listpersonas.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
    }
}