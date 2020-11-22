using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Controllers
{ 
    public class login_Controller : Controller
    {
        // GET: login_
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult cerrarsesion() 
        {
            Session["Usuario"] = null;
            Session["rol"] = null;
            return RedirectToAction("Index");
        }

        public string Login(usuarios usuario)
        {
            string mensaje = "";
            string username=usuario.Username;
            string password = usuario.txt_password;
            using (LavApp_BDEntities contexto = new LavApp_BDEntities()) 
            {
                int numeroVeces = contexto.usuarios.Where(p => p.Username == username && p.txt_password == password).Count();
                mensaje = numeroVeces.ToString();
                if (mensaje == "0")
                {
                    mensaje = "Usuario o Contraseña incorrecta!";
                }
                else {
                    usuarios usr = contexto.usuarios.Where(p => p.Username == username && p.txt_password == password).First();
                    Session["Usuario"] = usr;
                    rolesCls rol = (from roles in contexto.roles
                                             join usuario_rol in contexto.usuario_rol
                                             on roles.id_rol equals usuario_rol.id_rol
                                             where usuario_rol.id_usuario == usr.id_usuario
                                             select new rolesCls
                                             {
                                                 id_rol = roles.id_rol,
                                                 txt_desc_rol = roles.txt_desc_rol,
                                                 sn_admin = roles.sn_admin,
                                                 sn_empleado = roles.sn_empleado,
                                                 sn_cliente = roles.sn_cliente
                                             }
                                            // ).ToList();
                                            ).FirstOrDefault();
                    Session["rol"] = rol;
                    if (rol.sn_cliente)
                        mensaje = "2";
                }
            }

            return mensaje;
        }

    }
}