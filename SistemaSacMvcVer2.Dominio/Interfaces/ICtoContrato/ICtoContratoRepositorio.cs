using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato
{
    public interface ICtoContratoRepositorio
    {
        List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario);
        List<string> ObtenerObrasRegionalesAdministradasCentralPorEstadoContratoGrupo(ReportesSacFiltros filtroReporteBasico);
        List<string> ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(ReportesSacFiltros filtroReporteBasico);
        List<string> ObtenerObrasRegionalesAdministradasCentralPorEstadoSoloObras(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaEnGarantiaPorGrupoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico);
    }
}
