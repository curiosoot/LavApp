using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class vehiculos_Cls
    {
        public int id_vehiculo { get; set; }
        public int id_tipo_vehiculo { get; set; }
        public int id_persona { get; set; }
        public string txt_placa { get; set; }
        public int id_marca_vehiculo { get; set; }
        public int id_modelo_vehiculo { get; set; }
        public int id_color_vehiculo { get; set; }
        public int ano_vehiculo { get; set; }
    }
}