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
    
    public partial class color_vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public color_vehiculo()
        {
            this.vehiculos = new HashSet<vehiculos>();
        }
    
        public int id_color_vehiculo { get; set; }
        public int id_marca_vehiculos { get; set; }
        public string txt_desc_color { get; set; }
        public bool sn_activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vehiculos> vehiculos { get; set; }
        public virtual marca_vehiculos marca_vehiculos { get; set; }
    }
}
