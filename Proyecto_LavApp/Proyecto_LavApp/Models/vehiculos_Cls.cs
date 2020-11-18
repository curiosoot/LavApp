using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models
{
    public class vehiculos_Cls
    {
        [Display(Name = "Id Vehículo ")]
        public int id_vehiculo { get; set; }

        [Display(Name = "Id Tipo Vehículo ")]
        public int id_tipo_vehiculo { get; set; }

        [Display(Name = "Id Persona")]
        public int id_persona { get; set; }

        [Display(Name = "Placa")]
        public string txt_placa { get; set; }

        [Display(Name = "Id Marca Vehículo")]
        public int id_marca_vehiculo { get; set; }

        [Display(Name = "Id Modelo Vehículo ")]
        public int id_modelo_vehiculo { get; set; }

        [Display(Name = "Id Color Vehículo ")]
        public int id_color_vehiculo { get; set; }

        [Display(Name = "Año Vehículo ")]
        public int ano_vehiculo { get; set; }
    }
}