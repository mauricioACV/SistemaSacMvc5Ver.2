using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato
{
    public interface ICtoContratoRepositorio
    {
        List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario);
        List<string> ObtenerObrasRegionalesAdministradasPorCentral(ReportesSacFiltros filtroReporteBasico);
    }
}
