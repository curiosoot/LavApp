using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{
    public class vehiculos_Controller : Controller
    {
        List<SelectListItem> listmarcas;
        List<SelectListItem> listmodelo;
        List<SelectListItem> listcolor;
        List<SelectListItem> listtipoveh;
        List<SelectListItem> listpersonas;

        vehiculos_Admin admin = new vehiculos_Admin();
        // GET: vehiculos_
        public ActionResult Index()
        {
            return View(admin.Consultar());
        }

        public ActionResult Detalle(int id)
        {
            return View(admin.Consultar(id));
        }

        public ActionResult Crear(vehiculos modelo)
        {
            llenar_marcas();
            ViewBag.lista = listmarcas;
            llenar_tipo_veh();
            ViewBag.listaveh = listtipoveh;
            llenar_modelos(modelo.id_marca_vehiculo);
            ViewBag.listmodelo = listmodelo;
            llenar_colores(modelo.id_marca_vehiculo);
            ViewBag.listcol = listcolor;
            llenar_personas();
            ViewBag.listapersonas = listpersonas;
            return View();
        }
        public ActionResult Guardar(vehiculos modelo)
        {
            if (!ModelState.IsValid)
            {
                llenar_marcas();
                ViewBag.lista = listmarcas;
                llenar_tipo_veh();
                ViewBag.listaveh = listtipoveh;
                llenar_personas();
                ViewBag.listapersonas = listpersonas;
                llenar_modelos(modelo.id_marca_vehiculo);
                ViewBag.listmodelo = listmodelo;
                llenar_colores(modelo.id_marca_vehiculo);
                ViewBag.listcol = listcolor;
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
            llenar_tipo_veh();
            ViewBag.listaveh = listtipoveh;
            //llenar_modelos(modelo.id_marca_vehiculo);
            //ViewBag.listmodelo = listmodelo;
            //llenar_colores(modelo.id_marca_vehiculo);
            //ViewBag.listcol = listcolor;
            llenar_personas();
            ViewBag.listapersonas = listpersonas;
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(vehiculos modelo)
        {
            admin.Modificar(modelo);
            llenar_marcas();
            ViewBag.lista = listmarcas;
            llenar_tipo_veh();
            ViewBag.listaveh = listtipoveh;
            llenar_personas();
            ViewBag.listapersonas = listpersonas;
            llenar_modelos(modelo.id_marca_vehiculo);
            ViewBag.listmodelo = listmodelo;
            llenar_colores(modelo.id_marca_vehiculo);
            ViewBag.listcol = listcolor;
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            vehiculos modelo = admin.Consultar(id);
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

        private void llenar_modelos(int id_marca)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listmodelo = (from modelos in contexto.modelo_vehiculos
                              where modelos.sn_activo == true && modelos.id_marca_vehiculos == id_marca
                              select new SelectListItem
                                {
                                    Text = modelos.txt_desc_modelo,
                                    Value = modelos.id_modelo_vehiculo.ToString()
                                }).ToList();
                listmodelo.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenar_colores(int id_marca)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listcolor = (from colores in contexto.color_vehiculo
                             where colores.sn_activo == true && colores.id_marca_vehiculos == id_marca
                             select new SelectListItem
                                {
                                    Text = colores.txt_desc_color,
                                    Value = colores.id_color_vehiculo.ToString()
                                }).ToList();
                listcolor.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenar_tipo_veh()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listtipoveh = (from tipo_vehiculos in contexto.tipo_vehiculos
                               where tipo_vehiculos.sn_activo == true 
                               select new SelectListItem
                                {
                                    Text = tipo_vehiculos.txt_tipo_vehiculo,
                                    Value = tipo_vehiculos.id_tipo_vehiculo.ToString()
                                }).ToList();
                listtipoveh.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenar_personas()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listpersonas = (from personas in contexto.personas
                                    //where personas.id_persona in 
                                select new SelectListItem
                                {
                                    Text = personas.txt_apellido1 + " " + personas.txt_apellido2 + " " + personas.txt_nombre,
                                    Value = personas.id_persona.ToString()
                                }).ToList();
                listpersonas.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
    }
}