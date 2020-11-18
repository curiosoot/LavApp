using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class reserva_tipo_servicio_Cls
    {
        [Display(Name = "Id Tipo Servicio")]
        public int id_tipo_servicio { get; set; }

        [Display(Name = "Total Servicios Solicitados")]
        public int total_servicios_sol { get; set; }

        [Display(Name = "Id Cita Tipo Reserva")]
        public int id_cita_tipo_reserva { get; set; }

        [Display(Name = "Id Reserva")]
        public int id_reserva { get; set; }
    }
}