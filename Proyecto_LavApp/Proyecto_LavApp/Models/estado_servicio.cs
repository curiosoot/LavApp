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

    public partial class estado_servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estado_servicio()
        {
            this.detalle_servicio = new HashSet<detalle_servicio>();
        }

        [Display(Name = "Id Estado Servicio")]
        public int id_estado_servicio { get; set; }

        [Display(Name = "Descripción Estado Servicio")]
        public string txt_estado_Servicio { get; set; }

        [Display(Name = "Estado Activo")]
        public bool sn_activo { get; set; }

        [Display(Name = "Estado Cancelado")]
        public bool sn_cancelado { get; set; }

        [Display(Name = "Estado Finalizado")]
        public bool sn_finalizado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_servicio> detalle_servicio { get; set; }
    }
}
