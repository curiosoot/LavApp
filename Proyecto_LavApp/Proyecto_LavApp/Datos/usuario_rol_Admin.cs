using Antlr.Runtime.Misc;
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
        public IEnumerable<usuario_rol_Cls> Consultar()
        {
            IEnumerable<usuario_rol_Cls> asociacion = null;
            //IEnumerable<usuario_rol> usuarios_roles = null;
            //var persona = new personas();
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                //usuarios_roles = contexto.usuario_rol.Include(x => x.roles).ToList();
                //return contexto.usuario_rol.Include(x => x.roles).ToList();
                asociacion = (from usuarios in contexto.usuarios
                              join usuario_rol in contexto.usuario_rol
                              on usuarios.id_usuario equals usuario_rol.id_usuario
                              join roles in contexto.roles
                              on usuario_rol.id_rol equals roles.id_rol
                              select new usuario_rol_Cls
                              {
                                id_usuario_rol = usuario_rol.id_usuario_rol,
                                id_usuario = usuario_rol.id_usuario,
                                id_rol = usuario_rol.id_rol,
                                txt_desc_rol = roles.txt_desc_rol,
                                Username = usuarios.Username
                              }).ToList();
            }
            return asociacion;
        }

        public IEnumerable<usuario_rol> Consultar2()
        {
            roles_Admin rolAdmin = new roles_Admin();
            usuarios_Admin usrAdmin = new usuarios_Admin();
            IEnumerable<usuario_rol_Cls> asociacion;
            //IEnumerable<usuario_rol> modelo = null;
            IEnumerable<usuario_rol> modelo = new List<usuario_rol>();
            usuario_rol modelo_rol = new usuario_rol();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                //usuarios_roles = contexto.usuario_rol.Include(x => x.roles).ToList();
                //return contexto.usuario_rol.Include(x => x.roles).ToList();
                asociacion = (from usuarios in contexto.usuarios
                              join usuario_rol in contexto.usuario_rol
                              on usuarios.id_usuario equals usuario_rol.id_usuario
                              join roles in contexto.roles
                              on usuario_rol.id_rol equals roles.id_rol
                              select new usuario_rol_Cls
                              {
                                  id_usuario_rol = usuario_rol.id_usuario_rol,
                                  id_usuario = usuario_rol.id_usuario,
                                  id_rol = usuario_rol.id_rol,
                                  txt_desc_rol = roles.txt_desc_rol,
                                  Username = usuarios.Username
                              }).ToList();
            }

            foreach (usuario_rol_Cls Item in asociacion) 
            {
                modelo_rol.id_usuario_rol = Item.id_usuario_rol;
                modelo_rol.id_usuario = Item.id_usuario;
                modelo_rol.id_rol = Item.id_rol;
                modelo_rol.roles = rolAdmin.Consultar(Item.id_rol);
                modelo_rol.usuarios = usrAdmin.Consultar(Item.id_usuario);

                //modelo.Add(modelo_rol);
                modelo.ToList().Add(modelo_rol);
            }
            return modelo;
        }

        public usuario_rol Consultar2(int id)
        {
            roles_Admin rolAdmin = new roles_Admin();
            usuarios_Admin usrAdmin = new usuarios_Admin();
            usuario_rol_Cls asociacion = new usuario_rol_Cls();
            usuario_rol modelo = new usuario_rol();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                //usuarios_roles = contexto.usuario_rol.Include(x => x.roles).ToList();
                //return contexto.usuario_rol.Include(x => x.roles).ToList();
                asociacion = (from usuarios in contexto.usuarios
                              join usuario_rol in contexto.usuario_rol
                              on usuarios.id_usuario equals usuario_rol.id_usuario
                              join roles in contexto.roles
                              on usuario_rol.id_rol equals roles.id_rol
                              where usuario_rol.id_usuario_rol == id
                              select new usuario_rol_Cls
                              {
                                  id_usuario_rol = usuario_rol.id_usuario_rol,
                                  id_usuario = usuario_rol.id_usuario,
                                  id_rol = usuario_rol.id_rol,
                                  txt_desc_rol = roles.txt_desc_rol,
                                  Username = usuarios.Username
                              }).FirstOrDefault();
            }

            //foreach (usuario_rol_Cls Item in asociacion)
            //{
                modelo.id_usuario_rol = asociacion.id_usuario_rol;
                modelo.id_usuario = asociacion.id_usuario;
                modelo.id_usuario_rol = asociacion.id_rol;
                modelo.roles = rolAdmin.Consultar(asociacion.id_rol);
                modelo.usuarios = usrAdmin.Consultar(asociacion.id_usuario);

                //modelo.ToList().Add(modelo_rol);
            //}
            return modelo;
        }

        public usuario_rol_Cls Consultar(int id)
        {
            usuario_rol_Cls asociacion = null;

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                //return contexto.usuario_rol.Include(x => x.usuarios).FirstOrDefault(c => c.id_usuario_rol == id);
                    asociacion = (from usuarios in contexto.usuarios
                                  join usuario_rol in contexto.usuario_rol
                                  on usuarios.id_usuario equals usuario_rol.id_usuario
                                  join roles in contexto.roles
                                  on usuario_rol.id_rol equals roles.id_rol
                                  where usuario_rol.id_usuario_rol == id
                                  select new usuario_rol_Cls
                                  {
                                      id_usuario_rol = usuario_rol.id_usuario_rol,
                                      id_usuario = usuario_rol.id_usuario,
                                      id_rol = usuario_rol.id_rol,
                                      txt_desc_rol = roles.txt_desc_rol,
                                      Username = usuarios.Username
                                  }).FirstOrDefault();
            }
                return asociacion;
        }

        public void Guardar(usuario_rol modelo)
        {
            //roles_Admin rolAdmin = new roles_Admin();
            //usuarios_Admin usrAdmin = new usuarios_Admin();

            //usuario_rol usuario = null;

            //usuario.id_usuario_rol = modelo.id_usuario_rol;
            //usuario.id_usuario = modelo.id_usuario;
            //usuario.id_usuario_rol = modelo.id_rol;
            //usuario.roles = rolAdmin.Consultar(modelo.id_rol);
            //usuario.usuarios = usrAdmin.Consultar(modelo.id_usuario);

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