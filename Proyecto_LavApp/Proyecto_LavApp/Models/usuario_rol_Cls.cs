using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class usuario_rol_Cls
    {
        [Display(Name = "id_usuario_rol")]
        public int id_usuario_rol { get; set; }

        [Display(Name = "Usuario")]
        public int id_usuario { get; set; }

        [Display(Name = "Rol")]
        public int id_rol { get; set; }

        [Display(Name = "Rol")]
        public string txt_desc_rol { get; set; }

        [Display(Name = "Rol")]
        public string Username { get; set; }

    }
}