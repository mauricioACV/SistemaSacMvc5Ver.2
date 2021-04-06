using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Entidades
{
    public class CtoContratoModifica
    {
        public string CodigoCarpeta { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaTramite { get; set; }
    }
}
