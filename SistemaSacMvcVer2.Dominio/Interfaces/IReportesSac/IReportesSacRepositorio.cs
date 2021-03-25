using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac
{
    public interface IReportesSacRepositorio
    {
        List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoYgrupo(ReportesSacFiltros filtroReporteBasico);
        ReportesSac ObtenerDatosBasicoObrasPorCodigoCarpeta(string pCodigoCarpeta);
    }
}
