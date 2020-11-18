using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class usuariosCls
    {
        [Display(Name = "Id Usuario")]
        public int id_usuario { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string txt_password { get; set; }

        [Display(Name = "Id Persona Asignada")]
        public int id_persona { get; set; }

        [Display(Name = "Persona Asignada")]
        public string nombre_asoc { get; set; }

        [Display(Name = "Fecha de Vencimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public System.DateTime fec_vto_password { get; set; }

    }
}