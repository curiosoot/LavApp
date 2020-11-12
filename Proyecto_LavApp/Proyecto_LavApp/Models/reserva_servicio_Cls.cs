using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class reserva_servicio_Cls
    {
        public int id_reserva { get; set; }
        public string txt_nombre { get; set; }
        public int cedula { get; set; }
        public string txt_email { get; set; }
        public int telefono { get; set; }
        public int id_vehiculo { get; set; }
        public System.DateTime fecha_servicio { get; set; }
        public System.DateTime hora_servicio { get; set; }
        public int id_usuario_atiende { get; set; }
        public string txt_observacion { get; set; }
    }
}