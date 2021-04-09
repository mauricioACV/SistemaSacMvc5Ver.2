using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratoModifica
{
    public interface ICtoContratoModificaRepositorio
    {
        List<string> ObtenerCodigosCarpetaLiquidadosPorGrupoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> ObtenerCodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico);
        List<string> ObtenerCodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico);
    }
}
