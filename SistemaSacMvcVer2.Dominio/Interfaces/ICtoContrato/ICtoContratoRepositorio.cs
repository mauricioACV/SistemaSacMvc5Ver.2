using SistemaSacMvcVer2.Dominio.Common.Models;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato
{
    public interface ICtoContratoRepositorio
    {
        List<string> CodigosCarpetaPorGrupoPorEstado(SacFiltros filtroBasico);

        List<string> CodigosCarpetaPorGrupoPorEstadoPorClase(SacFiltros filtroBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoContrato(SacFiltros filtroBasico);

        List<string> CodigosCarpetaSoloObrasPorGrupoPorEstado(SacFiltros filtroBasico);

        List<string> CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(SacFiltros filtroBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(SacFiltros filtroBasico);

        List<string> CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminEnGarantiaEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorClaseEnGarantiaEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContrato(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorClase(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(SacFiltros filtroBasico);

        List<string> CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(SacFiltros filtroBasico);

        List<string> CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(SacFiltros filtroBasico);

        List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(SacFiltros filtroBasico);

        List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario);
    }
}
