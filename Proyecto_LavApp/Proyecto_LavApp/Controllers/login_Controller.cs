using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public string Login(usuarios usuario)
        {
            string mensaje = "";
            string username=usuario.Username;
            string password = usuario.txt_password;
            using (LavApp_BDEntities contexto = new LavApp_BDEntities()) 
            {
                int numeroVeces = contexto.usuarios.Where(p => p.Username == username && p.txt_password == password).Count();
                mensaje = numeroVeces.ToString();
                if (mensaje=="0")
                {
                    mensaje = "Usuriario o Contraseña incorrecta!";
                }
            }

                return mensaje;
        }
    }
}