using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Filters;
using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
    //[Acceder]
    public class personas_Controller : Controller
    {
        List<SelectListItem> listdocumento;

        personas_Admin admin = new personas_Admin();
        // GET: personas_
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
            llenar_documentos();
            ViewBag.lista = listdocumento;
            return View(); 
        }

        [HttpPost]
        public ActionResult Crear(personas modelo)
        {
            if (!ModelState.IsValid)
            {
                llenar_documentos();
                ViewBag.lista = listdocumento;
                return View(modelo);
            }
            else
            {
                admin.Guardar(modelo);
                if (Session["Usuario"] == null)
                {
                    return RedirectToAction("Crear","usuarios_");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Editar(int id)
        {
            llenar_documentos();
            ViewBag.lista = listdocumento;
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(personas modelo)
        {
            admin.Modificar(modelo);
            llenar_documentos();
            ViewBag.lista = listdocumento;
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            personas modelo = admin.Consultar(id);
            admin.Eliminar(modelo);
            return View("Index", admin.Consultar());
        }

        private void llenar_documentos()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listdocumento = (from tipo_documento in contexto.tipo_documento
                                 where tipo_documento.sn_activo == true
                                 select new SelectListItem
                                 {
                                     Text = tipo_documento.txt_tipo_doc,
                                     Value = tipo_documento.id_tipo_documento.ToString()
                                 }).ToList();
                listdocumento.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
    }
}