//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_LavApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class usuario_rol
    {
        public int id_usuario_rol { get; set; }

        [Display(Name = "Usuario")]
        public int id_usuario { get; set; }

        [Display(Name = "Rol")]
        public int id_rol { get; set; }
    
        public virtual roles roles { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
