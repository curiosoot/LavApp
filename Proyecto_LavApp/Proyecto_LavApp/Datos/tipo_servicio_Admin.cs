using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class tipo_servicio_Admin
    {
        public IEnumerable<tipo_servicio> Consultar()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.tipo_servicio.AsNoTracking().ToList();
            }
        }
        public tipo_servicio Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.tipo_servicio.AsNoTracking().FirstOrDefault(c => c.id_tipo_servicio == id);
            }
        }

        public void Guardar(tipo_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.tipo_servicio.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(tipo_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(tipo_servicio modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}