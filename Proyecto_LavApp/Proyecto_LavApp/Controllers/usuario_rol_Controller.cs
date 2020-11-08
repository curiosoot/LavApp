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
    [Acceder]
    public class usuario_rol_Controller : Controller
    {
        List<SelectListItem> listroles;
        List<SelectListItem> listusuarios;

        usuario_rol_Admin admin = new usuario_rol_Admin();
        // GET: usuario_rol_
        public ActionResult Index()
        {
            return View(admin.Consultar2());
        }

        public ActionResult Detalle(int id)
        {
            return View(admin.Consultar2(id));
        }

        public ActionResult Crear()
        {
            llenar_roles();
            ViewBag.listaroles = listroles;

            llenar_usuarios();
            ViewBag.listausuarios = listusuarios;

            return View();
        }
        public ActionResult Guardar(usuario_rol modelo)
        {
            if (!ModelState.IsValid)
            {
                llenar_roles();
                ViewBag.listaroles = listroles;

                llenar_usuarios();
                ViewBag.listausuarios = listusuarios;

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
            llenar_roles();
            ViewBag.listaroles = listroles;

            llenar_usuarios();
            ViewBag.listausuarios = listusuarios;
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(usuario_rol modelo)
        {
            admin.Modificar(modelo);
            llenar_roles();
            ViewBag.listaroles = listroles;

            llenar_usuarios();
            ViewBag.listausuarios = listusuarios;
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            usuario_rol modelo = admin.Consultar2(id);
            admin.Eliminar(modelo);
            return View("Index", admin.Consultar());
        }

        private void llenar_roles()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listroles = (from roles in contexto.roles
                                 //where tipo_documento.sn_activo == true
                                 select new SelectListItem
                                 {
                                     Text = roles.txt_desc_rol,
                                     Value = roles.id_rol.ToString()
                                 }).ToList();
                listroles.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenar_usuarios()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listusuarios = (from usuarios in contexto.usuarios
                                 //where tipo_documento.sn_activo == true 
                                 select new SelectListItem
                                 {
                                     Text = usuarios.Username,
                                     Value = usuarios.id_usuario.ToString()
                                 }).ToList();
                listusuarios.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
    }
}