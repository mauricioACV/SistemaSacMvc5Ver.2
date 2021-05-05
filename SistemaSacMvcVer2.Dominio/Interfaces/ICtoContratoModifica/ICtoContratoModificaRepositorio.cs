using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratoModifica
{
    public interface ICtoContratoModificaRepositorio
    {
        List<string> CodigosCarpetaLiquidadosPorGrupoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminEntreFechas(ReportesSacFiltros filtroReporteBasico);
    }
}
