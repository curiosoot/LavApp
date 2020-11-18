using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class reserva_tipo_servicio_Cls
    {
        public int id_tipo_servicio { get; set; }
        public int total_servicios_sol { get; set; }
        public int id_cita_tipo_reserva { get; set; }
        public int id_reserva { get; set; }
    }
}