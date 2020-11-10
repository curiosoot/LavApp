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

    public partial class vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vehiculos()
        {
            this.persona_vehiculo = new HashSet<persona_vehiculo>();
            this.registro_servicio = new HashSet<registro_servicio>();
        }

        [Display(Name = "Id Vehiculo")]
        public int id_vehiculo { get; set; }

        [Display(Name = "Id Tipo Vehiculo")]
        public int id_tipo_vehiculo { get; set; }

        [Display(Name = "Placa")]
        public string txt_placa { get; set; }

        [Display(Name = "Id Marca Vehiculo")]
        public int id_marca_vehiculo { get; set; }

        [Display(Name = "Id Modelo Vehiculo")]
        public int id_modelo_vehiculo { get; set; }

        [Display(Name = "Id Color Vehiculo")]
        public int id_color_vehiculo { get; set; }

        [Display(Name = "Id Año Vehiculo")]
        public int ano_vehiculo { get; set; }
    
        public virtual color_vehiculo color_vehiculo { get; set; }
        public virtual marca_vehiculos marca_vehiculos { get; set; }
        public virtual modelo_vehiculos modelo_vehiculos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<persona_vehiculo> persona_vehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro_servicio> registro_servicio { get; set; }
        public virtual tipo_vehiculos tipo_vehiculos { get; set; }
    }
}
