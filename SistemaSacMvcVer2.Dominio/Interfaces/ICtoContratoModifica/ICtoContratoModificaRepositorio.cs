using SistemaSacMvcVer2.Dominio.Common.Models;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratoModifica
{
    public interface ICtoContratoModificaRepositorio
    {
        List<string> CodigosCarpetaLiquidadosPorGrupoEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaLiquidadosPorGrupoPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaLiquidadosPorGrupoPorTipoContratoPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminPorClaseEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(SacFiltros filtroBasico);

        List<string> CodigosCarpetaLiquidadosPorGrupoPorClaseSoloObrasEntreFechas(SacFiltros filtroBasico);
    }
}
