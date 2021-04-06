using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac
{
    public class ReportesSacFiltros
    {
        public string Grupo { get; set; }
        public bool IncluirCentral { get; set; }
        public bool RangoFecha { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string EstadoContrato { get; set; }
        public string Region { get; set; }
        public string TipoContrato { get; set; }
        public string Clase { get; set; }
    }
}
