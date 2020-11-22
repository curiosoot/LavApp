using Proyecto_LavApp.Datos;
using Proyecto_LavApp.Filters;
using Proyecto_LavApp.Models;
using Proyecto_LavApp.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            //var usuario = new usuarios();
            //var modelo = new reserva_servicio();
            //if (Session["Usuario"] != null)
            //{
            //    usuario = (usuarios)Session["Usuario"];
            //    using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            //    {
            //        var persona = contexto.personas.Where(x => x.id_persona == usuario.id_persona).FirstOrDefault();
            //        if(persona != null)
            //        {
            //            modelo.cedula = (int)persona.txt_documento;
            //            modelo.txt_nombre = persona.txt_nombre + " " + persona.txt_apellido1 + " " + persona.txt_apellido2;
            //            modelo.fecha_servicio = DateTime.Now;
            //            modelo.hora_servicio = DateTime.Now;

            //        }
            //    }
            //}

            //return View(modelo);
            return View();
        }
         
        [HttpPost]
        public ActionResult Crear(reserva_servicio modelo)
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

        [HttpPost]
        public ActionResult Editar(reserva_servicio modelo)
        {
            if (!ModelState.IsValid)
            {
                llenar_usr_atiende();
                ViewBag.listausr = lisusr_atiende;

                llenar_vehiculos();
                ViewBag.listavehiculos = listvehiculos;

                return View(modelo); 
            }

            admin.Modificar(modelo);
            llenar_usr_atiende();
            ViewBag.listausr = lisusr_atiende;

            llenar_vehiculos();
            ViewBag.listavehiculos = listvehiculos;
            return RedirectToAction("Index", "reserva_tipo_serv_");
        }

        public ActionResult Eliminar(int id)
        {
            bool error = false;
            string message = string.Empty;

            try
            {
                admin.Eliminar(id);
            }
            catch (Exception ex)
            {
                error = true;
                message = $"Se presento un error no controlado: {ex.Message}";
                if (ex.InnerException?.InnerException?.Message?.Contains("FK_") == true)
                {
                    message = $"La reserva se encuentra asociado a otro proceso";
                }
            }

            var objeto = new { error, message };
            return Json(objeto, JsonRequestBehavior.AllowGet);
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

        public ActionResult ValidarHorarioEmpleado(DateTime fecha, DateTime hora)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                try
                {
                    var empleados = (from usuarios in contexto.usuarios
                                     join personas in contexto.personas
                                     on usuarios.id_persona equals personas.id_persona
                                     join usuario_rol in contexto.usuario_rol
                                     on usuarios.id_usuario equals usuario_rol.id_usuario
                                     join roles in contexto.roles
                                     on usuario_rol.id_rol equals roles.id_rol
                                     where roles.sn_empleado == true
                                     select usuarios).ToList();

                    // empleados con reservas el dia consultado se pasa a entidad POCO para poder manejar consulta compleja por LINQ
                    var empleados_con_reservas = contexto.reserva_servicio.Where(x => x.fecha_servicio == fecha.Date)
                                                .Select(x => new ReservaPOCO
                                                {
                                                    id_usuario_atiende = x.id_usuario_atiende,
                                                    fecha_servicio = x.fecha_servicio,
                                                    hora_servicio = x.hora_servicio
                                                }).ToList();

                    var empleados_no_disponibles = empleados_con_reservas.Where(x => x.fecha_servicio == fecha.Date &&
                                                    //x.hora_servicio.Hour <= hora.Hour && x.hora_servicio.Hour + 1 >= hora.Hour && 
                                                    //x.hora_servicio.Minute >= hora.Minute)
                                                    (x.hora_servicio.Hour == hora.Hour) ||
                                                    (x.hora_servicio.Hour + 1 == hora.Hour && x.hora_servicio.Minute > hora.Minute))
                                                    // (x.hora_servicio.Hour < hora.Hour && x.hora_servicio.Minute < hora.Minute))
                                                    .Select(x => x.id_usuario_atiende).Distinct().ToList();
                    llenar_usr_atiende();
                    var objeto = new { lisusr_atiende, empleados_no_disponibles, error = empleados_no_disponibles.Count == empleados.Count };
                    
                    return Json(objeto, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    var objeto = new { message = ex.Message, error = true };
                    return Json(objeto, JsonRequestBehavior.AllowGet); 
                }
            }
        }
       
    }
}