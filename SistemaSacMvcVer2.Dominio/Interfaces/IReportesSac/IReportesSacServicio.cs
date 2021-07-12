using SistemaSacMvcVer2.Dominio.Common.Models;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac
{
    public interface IReportesSacServicio
    {
        List<ReportesSac> ObtenerListadoBasicoObrasPorGrupoPorEstado(SacFiltros filtroBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato(SacFiltros filtroBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoPorGrupoSoloObras(SacFiltros filtroBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasEnEjecucionMasTerminados(SacFiltros filtroBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoContrato(SacFiltros filtroBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorTipoContrato(SacFiltros filtroBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoSoloObras(SacFiltros filtroBasico);
        List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminEjEjecucionMasTerminados(SacFiltros filtroBasico);
    }
}