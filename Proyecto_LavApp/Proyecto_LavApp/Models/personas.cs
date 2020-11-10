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

    public partial class personas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personas()
        {
            this.persona_vehiculo = new HashSet<persona_vehiculo>();
            this.registro_servicio = new HashSet<registro_servicio>();
            this.usuarios = new HashSet<usuarios>();
        }

        [Display(Name = "Id Persona")]
        public int id_persona { get; set; }

        [Display(Name = "Id Tipo Documento")]
        public int id_tipo_documento { get; set; }

        [Display(Name = "Documento")]
        public decimal txt_documento { get; set; }

        [Display(Name = "Nombre")]
        public string txt_nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string txt_apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string txt_apellido2 { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fec_nacimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<persona_vehiculo> persona_vehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro_servicio> registro_servicio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarios> usuarios { get; set; }
        public virtual tipo_documento tipo_documento { get; set; }
    }
}
