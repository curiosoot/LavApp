using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class marca_vehiculos_Admin
    {
        public IEnumerable<marca_vehiculos> Consultar() 
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities()) 
            {
                return contexto.marca_vehiculos.AsNoTracking().ToList();
            }
        }
        public marca_vehiculos Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.marca_vehiculos.AsNoTracking().FirstOrDefault(c=>c.id_marca_vehiculos==id);
            }
        }

        public void Guardar (marca_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.marca_vehiculos.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(marca_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(marca_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State=EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}