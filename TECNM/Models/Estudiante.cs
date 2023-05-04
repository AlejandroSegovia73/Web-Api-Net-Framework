using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TECNM.Models
{
    public class Estudiante
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string matricula { get; set; }
    }
}