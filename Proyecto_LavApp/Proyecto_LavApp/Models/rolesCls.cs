using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class rolesCls
    {
        [Display(Name = "Id Rol")]
        public int id_rol { get; set; }

        [Display(Name = "Descripción Rol")]
        public string txt_desc_rol { get; set; }

        [Display(Name = "Es Admon")]
        public bool sn_admin { get; set; }

        [Display(Name = "Es Empleado")]
        public bool sn_empleado { get; set; }

        [Display(Name = "Es Cleinte")]
        public bool sn_cliente { get; set; }
    }
}