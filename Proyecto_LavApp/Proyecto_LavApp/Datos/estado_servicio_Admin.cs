using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class estado_servicio_Admin
    {

        public IEnumerable<estado_servicio> Consultar()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.estado_servicio.AsNoTracking().ToList();
            }
        }
        public estado_servicio Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.estado_servicio.AsNoTracking().FirstOrDefault(c => c.id_estado_servicio == id);
            }
        }

        public void Guardar(estado_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.estado_servicio.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(estado_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(estado_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}