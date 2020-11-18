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

    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            this.registro_servicio = new HashSet<registro_servicio>();
            this.usuario_rol = new HashSet<usuario_rol>();
            this.reserva_servicio = new HashSet<reserva_servicio>();
        }

        [Display(Name = "Id Usuario")]
        public int id_usuario { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string txt_password { get; set; }

        [Display(Name = "Id Persona")]
        public int id_persona { get; set; }

        [Display(Name = "Fecha Vencimiento Password")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime fec_vto_password { get; set; }

        [Display(Name = "Nombre Asociado ")]
        public string nom_asoc
        {
            get
            {
                return personas.txt_apellido1 + " " + personas.txt_apellido2 + " " + personas.txt_nombre;
            }
        }

        public virtual personas personas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro_servicio> registro_servicio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_rol> usuario_rol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva_servicio> reserva_servicio { get; set; }
    }
}
