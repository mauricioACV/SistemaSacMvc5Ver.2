using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac
{
    public interface IReportesSacServicio
    {
        List<ReportesSac> ObtenerListadoBasicoObras(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(ReportesSacFiltros filtroReporteBasico);
    }
}
