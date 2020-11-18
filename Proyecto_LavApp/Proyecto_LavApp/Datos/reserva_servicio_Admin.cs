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
        public List<reserva_servicio> Consultar()
        {
            usuarios_Admin usr_Admin = new usuarios_Admin();
            vehiculos_Admin veh_Admin = new vehiculos_Admin();

            List<reserva_servicio_Cls> modelo_new = new List<reserva_servicio_Cls>();
            List<reserva_servicio> modelo = new List<reserva_servicio>();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                modelo_new = (from reserva_servicio in contexto.reserva_servicio
                              select new reserva_servicio_Cls
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
                                  txt_observacion = reserva_servicio.txt_observacion
                                  //usuarios = usr_Admin.Consultar(reserva_servicio.id_usuario_atiende)//,
                                  //vehiculos = veh_Admin.Consultar(reserva_servicio.id_vehiculo)
                              }).ToList();
            }

            foreach (reserva_servicio_Cls item in modelo_new)
            {
                reserva_servicio modelo_rva = new reserva_servicio();

                modelo_rva.id_reserva = item.id_reserva;
                modelo_rva.txt_nombre = item.txt_nombre;
                modelo_rva.cedula = item.cedula;
                modelo_rva.txt_email = item.txt_email;
                modelo_rva.telefono = item.telefono;
                modelo_rva.id_vehiculo = item.id_vehiculo;
                modelo_rva.fecha_servicio = item.fecha_servicio;
                modelo_rva.hora_servicio = item.hora_servicio;
                modelo_rva.id_usuario_atiende = item.id_usuario_atiende;
                modelo_rva.txt_observacion = item.txt_observacion;
                modelo_rva.usuarios = usr_Admin.Consultar(item.id_usuario_atiende);
                modelo_rva.vehiculos = veh_Admin.Consultar(item.id_vehiculo);

                modelo.Add(modelo_rva);
            }

            return modelo;
        }

        public reserva_servicio Consultar(int id)
        {
            usuarios_Admin usr_Admin = new usuarios_Admin();
            vehiculos_Admin veh_Admin = new vehiculos_Admin();

            reserva_servicio_Cls modelo_new = new reserva_servicio_Cls();
            reserva_servicio modelo = new reserva_servicio();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                modelo_new = (from reserva_servicio in contexto.reserva_servicio
                              select new reserva_servicio_Cls
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
                                  txt_observacion = reserva_servicio.txt_observacion
                                  //usuarios = usr_Admin.Consultar(reserva_servicio.id_usuario_atiende)//,
                                  //vehiculos = veh_Admin.Consultar(reserva_servicio.id_vehiculo)
                              }).FirstOrDefault();
            }

                modelo.id_reserva = modelo_new.id_reserva;
                modelo.txt_nombre = modelo_new.txt_nombre;
                modelo.cedula = modelo_new.cedula;
                modelo.txt_email = modelo_new.txt_email;
                modelo.telefono = modelo_new.telefono;
                modelo.id_vehiculo = modelo_new.id_vehiculo;
                modelo.fecha_servicio = modelo_new.fecha_servicio;
                modelo.hora_servicio = modelo_new.hora_servicio;
                modelo.id_usuario_atiende = modelo_new.id_usuario_atiende;
                modelo.txt_observacion = modelo_new.txt_observacion;
                modelo.usuarios = usr_Admin.Consultar(modelo_new.id_usuario_atiende);
                modelo.vehiculos = veh_Admin.Consultar(modelo_new.id_vehiculo);

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