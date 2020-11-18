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
    public class reserva_tipo_serv_Controller : Controller
    {
        List<SelectListItem> listtiposerv;

        reserva_tipo_ser_Admin admin = new reserva_tipo_ser_Admin();
        // GET: reserva_tipo_serv_
        public ActionResult Index()
        {
            return View(admin.Consultar());
        }

        public ActionResult Crear()
        {
            llenar_tipos_serv();
            ViewBag.lista = listtiposerv;
            return View();
        }
        public ActionResult Guardar(reserva_tipo_servicio modelo)
        {
            if (!ModelState.IsValid)
            {
                llenar_tipos_serv();
                ViewBag.lista = listtiposerv;
                return View(modelo);
            }
            else
            {
                admin.Guardar(modelo);
                //return View("Crear", modelo);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Eliminar(int id)
        {
            reserva_tipo_servicio modelo = admin.Consultar(id);
            admin.Eliminar(modelo);
            return View("Index", admin.Consultar());
        }

        private void llenar_tipos_serv()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listtiposerv = (from tipo_servicio in contexto.tipo_servicio
                              select new SelectListItem
                              {
                                  Text = tipo_servicio.txt_desc_servicio,
                                  Value = tipo_servicio.id_tipo_servicio.ToString()
                              }).ToList();
                listtiposerv.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
    }
}