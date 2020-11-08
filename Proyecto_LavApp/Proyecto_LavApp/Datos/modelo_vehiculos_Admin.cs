using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class modelo_vehiculos_Admin
    {
        public IEnumerable<modelo_vehiculos> Consultar()
        {
           
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.modelo_vehiculos.Include(x => x.marca_vehiculos).ToList();
            }
        }
        public modelo_vehiculos Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.modelo_vehiculos.Include(x => x.marca_vehiculos).FirstOrDefault(c => c.id_modelo_vehiculo == id);
            }
        }

        public void Guardar(modelo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.modelo_vehiculos.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(modelo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(modelo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}