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
    
    public partial class reserva_servicio
    {
        public int id_reserva { get; set; }
        public int id_cita { get; set; }
        public string txt_nombre { get; set; }
        public int cedula { get; set; }
        public string txt_email { get; set; }
        public int telefono { get; set; }
        public int id_vehiculo { get; set; }
        public System.DateTime fecha_servicio { get; set; }
        public System.DateTime hora_servicio { get; set; }
        public int id_usuario_atiende { get; set; }
        public string txt_observacion { get; set; }
    
        public virtual reserva_tipo_servicio reserva_tipo_servicio { get; set; }
        public virtual usuarios usuarios { get; set; }
        public virtual vehiculos vehiculos { get; set; }
    }
}