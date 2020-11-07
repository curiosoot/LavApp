using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class usuario_rol_Admin
    {
        public IEnumerable<usuario_rol> Consultar()
        {
            //var persona = new personas();
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.usuario_rol.Include(x => x.roles).ToList();
            }
        }
        public usuario_rol Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.usuario_rol.Include(x => x.usuarios).FirstOrDefault(c => c.id_usuario_rol == id);
            }
        }

        public void Guardar(usuario_rol modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.usuario_rol.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(usuario_rol modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(usuario_rol modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}