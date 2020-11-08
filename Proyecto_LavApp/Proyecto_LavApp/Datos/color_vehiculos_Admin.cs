using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class color_vehiculos_Admin
    {
        public IEnumerable<color_vehiculo> Consultar()
        {

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.color_vehiculo.Include(x => x.marca_vehiculos).ToList();
            }
        }
        public color_vehiculo Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.color_vehiculo.Include(x => x.marca_vehiculos).FirstOrDefault(c => c.id_color_vehiculo == id);
            }
        }

        public void Guardar(color_vehiculo modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.color_vehiculo.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(color_vehiculo modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(color_vehiculo modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}