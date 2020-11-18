using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class reserva_tipo_ser_Admin
    {
        public IEnumerable<reserva_tipo_servicio> Consultar()
        {
            tipo_servicio_Admin srv_Admin = new tipo_servicio_Admin();
            reserva_servicio_Admin rva_Admin = new reserva_servicio_Admin();
            List<reserva_tipo_servicio> modelo = new List<reserva_tipo_servicio>();
            List<reserva_tipo_servicio_Cls> modelo_new = new List<reserva_tipo_servicio_Cls>();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                int MaxId = contexto.reserva_servicio.Max(p => p.id_reserva);
                //return contexto.reserva_tipo_servicio.Include(x => x.tipo_servicio).ToList();
                modelo_new = (from reserva_tipo_servicio in contexto.reserva_tipo_servicio
                          where reserva_tipo_servicio.id_reserva == MaxId
                          select new reserva_tipo_servicio_Cls
                          {
                              id_cita_tipo_reserva = reserva_tipo_servicio.id_cita_tipo_reserva,
                              id_tipo_servicio = reserva_tipo_servicio.id_tipo_servicio,
                              total_servicios_sol = reserva_tipo_servicio.total_servicios_sol,
                              id_reserva = reserva_tipo_servicio.id_reserva
                          }).ToList();
            }

            foreach (reserva_tipo_servicio_Cls item in modelo_new)
            {
                reserva_tipo_servicio modelo_id = new reserva_tipo_servicio();

                modelo_id.id_cita_tipo_reserva = item.id_cita_tipo_reserva;
                modelo_id.id_tipo_servicio = item.id_tipo_servicio;
                modelo_id.total_servicios_sol = item.total_servicios_sol;
                modelo_id.id_reserva = item.id_reserva;
                modelo_id.tipo_servicio = srv_Admin.Consultar(item.id_tipo_servicio);
                modelo_id.reserva_servicio = rva_Admin.Consultar(item.id_reserva);

                modelo.Add(modelo_id);
            }

            return modelo;
        }
        public reserva_tipo_servicio Consultar(int id)
        {
            tipo_servicio_Admin srv_Admin = new tipo_servicio_Admin();
            reserva_servicio_Admin rva_Admin = new reserva_servicio_Admin();
            reserva_tipo_servicio modelo = new reserva_tipo_servicio();
            reserva_tipo_servicio_Cls modelo_id = new reserva_tipo_servicio_Cls();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                //return contexto.reserva_tipo_servicio.Include(x => x.tipo_servicio).FirstOrDefault(c => c.id_cita_tipo_reserva == id);
                modelo_id = (from reserva_tipo_servicio in contexto.reserva_tipo_servicio
                          where reserva_tipo_servicio.id_cita_tipo_reserva == id
                          select new reserva_tipo_servicio_Cls
                          {
                              id_cita_tipo_reserva = reserva_tipo_servicio.id_cita_tipo_reserva,
                              id_tipo_servicio = reserva_tipo_servicio.id_tipo_servicio,
                              total_servicios_sol = reserva_tipo_servicio.total_servicios_sol,
                              id_reserva = reserva_tipo_servicio.id_reserva
                          }).FirstOrDefault();
            }

            modelo.id_cita_tipo_reserva = modelo_id.id_cita_tipo_reserva;
            modelo.id_tipo_servicio = modelo_id.id_tipo_servicio;
            modelo.total_servicios_sol = modelo_id.total_servicios_sol;
            modelo.id_reserva = modelo_id.id_reserva;
            modelo.tipo_servicio = srv_Admin.Consultar(modelo_id.id_tipo_servicio);
            modelo.reserva_servicio = rva_Admin.Consultar(modelo_id.id_reserva);

            return modelo;
        }

        public void Guardar(reserva_tipo_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                int MaxId = contexto.reserva_servicio.Max(p => p.id_reserva);

                modelo.id_reserva = MaxId;

                contexto.reserva_tipo_servicio.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(reserva_tipo_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(reserva_tipo_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}