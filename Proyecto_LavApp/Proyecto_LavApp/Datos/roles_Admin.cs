using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class roles_Admin
    {
        public IEnumerable<roles> Consultar()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.roles.AsNoTracking().ToList();
            }
        }
        public roles Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.roles.AsNoTracking().FirstOrDefault(c => c.id_rol == id);
            }
        }

        public void Guardar(roles modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.roles.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(roles modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(roles modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}