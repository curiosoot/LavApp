using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models.POCO
{
    public class ReservaPOCO
    {
        public int id_usuario_atiende { get; set; }
        public DateTime fecha_servicio { get; set; }
        public DateTime hora_servicio { get; set; }
    }
}