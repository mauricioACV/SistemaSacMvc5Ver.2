using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Entidades
{
    public class CtoUsuario
    {
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Grupo { get; set; }
        public string TipoUsuario { get; set; }
        public string Clave { get; set; }
    }
}
