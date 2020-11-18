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
    public class reserva_servicio_Controller : Controller
    {
        List<SelectListItem> lisusr_atiende;
        List<SelectListItem> listvehiculos;

        reserva_servicio_Admin admin = new reserva_servicio_Admin();
        // GET: reserva_servicio_
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
            llenar_usr_atiende();
            ViewBag.listausr = lisusr_atiende;

            llenar_vehiculos();
            ViewBag.listavehiculos = listvehiculos;

            return View();
        }
        public ActionResult Guardar(reserva_servicio modelo)
        {
            if (!ModelState.IsValid)
            {
                llenar_usr_atiende();
                ViewBag.listausr = lisusr_atiende;

                llenar_vehiculos();
                ViewBag.listavehiculos = listvehiculos;

                return View(modelo);
            }
            else
            {
                admin.Guardar(modelo);
                //return View("Crear", modelo);
                return RedirectToAction("Index","reserva_tipo_serv_");
            }
        }

        public ActionResult Editar(int id)
        {
            llenar_usr_atiende();
            ViewBag.listausr = lisusr_atiende;

            llenar_vehiculos();
            ViewBag.listavehiculos = listvehiculos;
            return View(admin.Consultar(id));
        }

        public ActionResult Modificar(reserva_servicio modelo)
        {
            admin.Modificar(modelo);
            llenar_usr_atiende();
            ViewBag.listausr = lisusr_atiende;

            llenar_vehiculos();
            ViewBag.listavehiculos = listvehiculos;
            return RedirectToAction("Index", "reserva_tipo_serv_");
        }

        public ActionResult Eliminar(int id)
        {
            reserva_servicio modelo = admin.Consultar(id);
            admin.Eliminar(modelo);
            return View("Index", admin.Consultar());
        }

        private void llenar_vehiculos()
        {
            usuarios usuario = new usuarios();

            if (Session["Usuario"] != null)
            {
                usuario = (usuarios)Session["Usuario"];
            }
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                listvehiculos = (from vehiculos in contexto.vehiculos
                                    join marca_vehiculos in contexto.marca_vehiculos
                                    on vehiculos.id_marca_vehiculo equals marca_vehiculos.id_marca_vehiculos
                                    join modelo_vehiculos in contexto.modelo_vehiculos
                                    on vehiculos.id_modelo_vehiculo equals modelo_vehiculos.id_modelo_vehiculo
                                    where vehiculos.id_persona == usuario.id_persona
                                    select new SelectListItem
                                    {
                                        Text = marca_vehiculos.txt_desc_marca + " " + modelo_vehiculos.txt_desc_modelo,
                                        Value = vehiculos.id_vehiculo.ToString()
                                    }).ToList();
                listvehiculos.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenar_usr_atiende()
        {

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                lisusr_atiende = (from usuarios in contexto.usuarios
                                  join personas in contexto.personas
                                  on usuarios.id_persona equals personas.id_persona
                                  join usuario_rol in contexto.usuario_rol 
                                  on usuarios.id_usuario equals usuario_rol.id_usuario
                                  join roles in contexto.roles 
                                  on usuario_rol.id_rol equals roles.id_rol
                                  where roles.sn_empleado == true 
                                select new SelectListItem
                                {
                                    Text = personas.txt_apellido1 + " " + personas.txt_apellido2 + " " + personas.txt_nombre,
                                    Value = usuarios.id_usuario.ToString()
                                }).ToList();
                lisusr_atiende.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
    }
}