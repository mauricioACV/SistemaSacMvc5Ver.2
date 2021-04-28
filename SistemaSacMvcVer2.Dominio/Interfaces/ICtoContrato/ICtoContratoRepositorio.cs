using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato
{
    public interface ICtoContratoRepositorio
    {
        List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario);
        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoContrato(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaEnGarantiaPorGrupoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaSoloObrasPorGrupoPorEstado(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaPorGrupoPorEstado(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContrato(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaContratosRegionPorGrupoAdminEnGarantiaEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico);
    }
}
