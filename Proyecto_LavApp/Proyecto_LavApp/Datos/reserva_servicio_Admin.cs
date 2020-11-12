using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class reserva_servicio_Admin
    {
        public IEnumerable<reserva_servicio> Consultar()
        {
            usuarios_Admin usr_Admin = new usuarios_Admin();
            vehiculos_Admin veh_Admin = new vehiculos_Admin();

            IEnumerable<reserva_servicio> modelo = new List<reserva_servicio>();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                modelo = (from reserva_servicio in contexto.reserva_servicio
                              select new reserva_servicio
                              {
                                  id_reserva = reserva_servicio.id_reserva,
                                  txt_nombre = reserva_servicio.txt_nombre,
                                  cedula = reserva_servicio.cedula,
                                  txt_email = reserva_servicio.txt_email,
                                  telefono = reserva_servicio.telefono,
                                  id_vehiculo = reserva_servicio.id_vehiculo,
                                  fecha_servicio = reserva_servicio.fecha_servicio,
                                  hora_servicio = reserva_servicio.hora_servicio,
                                  id_usuario_atiende = reserva_servicio.id_usuario_atiende,
                                  txt_observacion = reserva_servicio.txt_observacion,
                                  usuarios = usr_Admin.Consultar(reserva_servicio.id_usuario_atiende)//,
                                  //vehiculos = veh_Admin.Consultar(reserva_servicio.id_vehiculo)
                              }).ToList();
            }

            return modelo;
        }

        public reserva_servicio Consultar(int id)
        {
            usuarios_Admin usr_Admin = new usuarios_Admin();
            vehiculos_Admin veh_Admin = new vehiculos_Admin();

            reserva_servicio modelo = new reserva_servicio();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                modelo = (from reserva_servicio in contexto.reserva_servicio
                          where reserva_servicio.id_reserva == id
                          select new reserva_servicio
                          {
                              id_reserva = reserva_servicio.id_reserva,
                              txt_nombre = reserva_servicio.txt_nombre,
                              cedula = reserva_servicio.cedula,
                              txt_email = reserva_servicio.txt_email,
                              telefono = reserva_servicio.telefono,
                              id_vehiculo = reserva_servicio.id_vehiculo,
                              fecha_servicio = reserva_servicio.fecha_servicio,
                              hora_servicio = reserva_servicio.hora_servicio,
                              id_usuario_atiende = reserva_servicio.id_usuario_atiende,
                              txt_observacion = reserva_servicio.txt_observacion,
                              usuarios = usr_Admin.Consultar(reserva_servicio.id_usuario_atiende)//,
                              //vehiculos = veh_Admin.Consultar(reserva_servicio.id_vehiculo)
                          }).FirstOrDefault();
            }

            return modelo;
        }

        public void Guardar(reserva_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.reserva_servicio.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(reserva_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(reserva_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}