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

    public partial class modelo_vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modelo_vehiculos()
        {
            this.vehiculos = new HashSet<vehiculos>();
        }

        [Display(Name = "Id Modelo Vehículo")]
        public int id_modelo_vehiculo { get; set; }

        [Display(Name = "Id Marca Vehículo")]
        public int id_marca_vehiculos { get; set; }

        [Display(Name = "Modelo Vehículo")]
        public string txt_desc_modelo { get; set; }

        [Display(Name = "Activo")]
        public bool sn_activo { get; set; }
    
        public virtual marca_vehiculos marca_vehiculos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiculos> vehiculos { get; set; }
    }
}
