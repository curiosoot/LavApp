using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class reserva_servicio_Cls
    {
        [Display(Name = "Id Reserva")]
        public int id_reserva { get; set; }

        [Display(Name = "Nombre")]
        public string txt_nombre { get; set; }

        [Display(Name = "Número Identificación")]
        public int cedula { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string txt_email { get; set; }

        [Display(Name = "Teléfono ")]
        public double telefono { get; set; }

        [Display(Name = "Id Vehículo")]
        public int id_vehiculo { get; set; }

        [Display(Name = "Fecha Servicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public System.DateTime fecha_servicio { get; set; }

        [Display(Name = "Hora Servicio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime hora_servicio { get; set; }

        [Display(Name = "Id Usuario Atiende")]
        public int id_usuario_atiende { get; set; }

        [Display(Name = "Observación")]
        public string txt_observacion { get; set; }
    }
}