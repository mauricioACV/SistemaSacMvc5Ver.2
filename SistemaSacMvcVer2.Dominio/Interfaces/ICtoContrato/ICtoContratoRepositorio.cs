using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato
{
    public interface ICtoContratoRepositorio
    {
        List<string> CodigosCarpetaPorGrupoPorEstado(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaPorGrupoPorEstadoPorClase(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorClaseEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoContrato(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaSoloObrasPorGrupoPorEstado(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContrato(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminEnGarantiaEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(ReportesSacFiltros filtroReporteBasico);

        List<string> CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminEntreFechas(ReportesSacFiltros filtroReporteBasico);

        List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario);
    }
}
