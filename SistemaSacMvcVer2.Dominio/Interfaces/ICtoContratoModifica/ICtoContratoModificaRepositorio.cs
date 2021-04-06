using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratoModifica
{
    public interface ICtoContratoModificaRepositorio
    {
        List<string> ObtenerCodigosCarpetaLiquidadosPorGrupo(ReportesSacFiltros filtroReporteBasico);
    }
}
