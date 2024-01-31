using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RespuestaSesion
    {
        public bool Valido { get; set; }
        public bool EsAdmin { get; set; }
        public string Empleado { get; set; }
    }
    public class Sesion { 
       public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}
