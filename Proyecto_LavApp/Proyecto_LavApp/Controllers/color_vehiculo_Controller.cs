using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
    public class color_vehiculo_Controller : Controller
    {
   
        List<SelectListItem> listmarcas;

        color_vehiculos_Admin admin = new color_vehiculos_Admin();
        // GET: color_vehiculo_
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
            llenar_marcas();
            ViewBag.lista = listmarcas;
            return View();
        }
        public ActionResult Guardar(color_vehiculo modelo)
        {
            if (!ModelState.IsValid)
            {
                llenar_marcas();
                ViewBag.lista = listmarcas;
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
            llenar_marcas();
            ViewBag.lista = listmarcas;
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(color_vehiculo modelo)
        {
            admin.Modificar(modelo);
            llenar_marcas();
            ViewBag.lista = listmarcas;
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            color_vehiculo modelo = admin.Consultar(id);
            admin.Eliminar(modelo);
            return View("Index", admin.Consultar());
        }

        private void llenar_marcas()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listmarcas = (from marca_vehiculos in contexto.marca_vehiculos
                              where marca_vehiculos.sn_activo == true
                              select new SelectListItem
                              {
                                  Text = marca_vehiculos.txt_desc_marca,
                                  Value = marca_vehiculos.id_marca_vehiculos.ToString()
                              }).ToList();
                listmarcas.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
    }
}