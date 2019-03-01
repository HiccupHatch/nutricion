using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioRest5.Areas.Api.Models
{
    public class Calorias
    {
        public string email { get; set; }
        public string fecha { get; set; }
        public char tipoComida { get; set; }
        public int codigoAlimento { get; set; }
        public int cantidad { get; set; }
    }
}