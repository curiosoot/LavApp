using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Models.POCO
{
    public class PersonaPOCO
    {
        public decimal Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; } 
    }
}