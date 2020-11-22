using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Filters;
using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
    //[Acceder]
    public class usuarios_Controller : Controller
    {
        List<SelectListItem> listpersonas;

        usuarios_Admin admin = new usuarios_Admin();
        // GET: usuarios_
        public ActionResult Index()
        {
            return View(admin.Consultar());
            //return View(admin.Consultar2());
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

        [HttpPost] 
        public ActionResult Crear(usuarios modelo)
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
                if (Session["Usuario"] == null)
                {
                    admin.Guardar_usr(modelo);
                    return RedirectToAction("Index", "login_");
                }
                else
                {
                    return RedirectToAction("Index");
                }
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
            return RedirectToAction("Index");
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
                var usuarios = contexto.usuarios.Select(x => x.id_persona).ToList();
                listpersonas = contexto.personas.Where(x => !usuarios.Contains(x.id_persona)).Select(x => new SelectListItem
                {
                    Text = x.txt_apellido1 + " " + x.txt_apellido2 + " " + x.txt_nombre,
                    Value = x.id_persona.ToString()
                }).ToList();

                listpersonas.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
    }
}