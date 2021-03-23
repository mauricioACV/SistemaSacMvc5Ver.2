using SistemaSacMvcVer2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Interfaces.IDominioItemsFormulario
{
    public interface IDominioItemsFormularioServicio
    {
        List<CtoGrupoClase> ListarAdministracionPorClaseUsuario(string pGrupoUsuario);
        List<CtoDominio> ListarItemsPorDominioUsuario(string pDominio, string pGrupoUsuario);
        List<CtoDominio> ListarItemsPorDominio(string pDominio);
        List<IndiceBase> ListarItemsIndiceBase();
        List<CtoInspectorFiscal> ObtenerListadoInspectorFiscalActivos();
        List<CtoVisitador> ObtenerListadoVisitadoresActivos();
        List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario);
        List<CtoContratista> ObtenerContratistas();
        List<CtoResidente> BuscarResidentePorPalabraClave(string pPalabraClave);
        List<CtoGrupoClase> ListarGrupoClase();
        List<CtoComuna> ObtenerRegiones();
    }
}
