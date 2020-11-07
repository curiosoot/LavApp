using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class usuarios_Admin
    {
        public IEnumerable<usuarios> Consultar()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                //return contexto.usuarios.AsNoTracking().ToList();
                return contexto.usuarios.Include(x => x.personas).ToList();
            }
        }

        public IEnumerable<usuariosCls> Consultar2()
        {
            IEnumerable<usuariosCls> users = null;
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                users = (from usuarios in contexto.usuarios
                         join personas in contexto.personas
                         on usuarios.id_persona equals personas.id_persona
                         select new usuariosCls
                         {
                             id_usuario = usuarios.id_usuario,
                             Username = usuarios.Username,
                             txt_password = usuarios.txt_password,
                             id_persona = usuarios.id_persona,
                             nombre_asoc = personas.txt_apellido1 + " " + personas.txt_apellido2 + " " + personas.txt_nombre,
                             fec_vto_password = usuarios.fec_vto_password,
                         }).ToList();
            }
            return users;
        }

        public usuarios Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                //return contexto.usuarios.AsNoTracking().FirstOrDefault(c => c.id_usuario == id);
                return contexto.usuarios.Include(x => x.personas).FirstOrDefault(c => c.id_usuario == id);
            }
        }

        public void Guardar(usuarios modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.usuarios.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(usuarios modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(usuarios modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

    }
}