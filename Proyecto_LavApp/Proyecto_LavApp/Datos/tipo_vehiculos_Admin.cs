using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class tipo_vehiculos_Admin
    {
        public IEnumerable<tipo_vehiculos> Consultar() 
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.tipo_vehiculos.AsNoTracking().ToList();
            }
        }

        public tipo_vehiculos Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.tipo_vehiculos.AsNoTracking().FirstOrDefault(c => c.id_tipo_vehiculo == id);
            }
        }

        public void Guardar (tipo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.tipo_vehiculos.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(tipo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(tipo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State=EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

    }
}