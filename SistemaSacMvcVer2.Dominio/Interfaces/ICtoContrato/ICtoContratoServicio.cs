using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato
{
    public interface ICtoContratoServicio
    {
        List<CtoDominio> ListarItemsPorDominio(string pDominio);

        List<CtoDominio> ListarItemsPorDominioUsuario(string pDominio, string pGrupoUsuario);

        List<CtoGrupoClase> ListarAdministracionPorClaseUsuario(string pGrupoUsuario);

        List<IndiceBase> ListarItemsIndiceBase();

        List<CtoInspectorFiscal> ObtenerListadoInspectorFiscalActivos();

        List<CtoVisitador> ObtenerListadoVisitadoresActivos();

        List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario);

        List<CtoContratista> ObtenerContratistas();

        List<CtoResidente> ObtenerListadoResidente();

        List<CtoResidente> BuscarResidentePorPalabraClave(string pPalabraClave);
    }
}
