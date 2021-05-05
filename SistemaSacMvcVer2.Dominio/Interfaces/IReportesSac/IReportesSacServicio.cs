using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac
{
    public interface IReportesSacServicio
    {
        List<ReportesSac> ObtenerListadoBasicoObrasPorGrupoPorEstado(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoPorGrupoSoloObras(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasEnEjecucionMasTerminados(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoContrato(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorTipoContrato(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoSoloObras(ReportesSacFiltros filtroReporteBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminEjEjecucionMasTerminados(ReportesSacFiltros filtroReporteBasico);
    }
}