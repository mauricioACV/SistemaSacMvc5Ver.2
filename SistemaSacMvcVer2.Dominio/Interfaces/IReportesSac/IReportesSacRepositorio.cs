using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac
{
    public interface IReportesSacRepositorio
    {
        ReportesSac ObtenerReporteBasicoObrasPorCodigoCarpeta(string pCodigoCarpeta);
    }
}
