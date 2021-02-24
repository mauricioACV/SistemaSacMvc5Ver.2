using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Aplicación.Servicios
{
    public class CtoContratoServicio : ICtoContratoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public CtoContratoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CtoGrupoClase> ListarAdministracionPorClaseUsuario(string pGrupoUsuario)
        {
            return _unitOfWork.CtoGrupoClaseRepositorio.ListarAdministracionPorClaseUsuario(pGrupoUsuario);
        }

        public List<CtoDominio> ListarItemsPorDominioUsuario(string pDominio, string pGrupoUsuario)
        {
            return _unitOfWork.CtoDominioRepositorio.ObtenerItemsPorDominioUsuario(pDominio, pGrupoUsuario);
        }

        public List<CtoDominio> ListarItemsPorDominio(string pDominio)
        {
            return _unitOfWork.CtoDominioRepositorio.ObtenerItemsPorDominio(pDominio);
        }

        public List<IndiceBase> ListarItemsIndiceBase()
        {
            return _unitOfWork.IndiceBaseRepositorio.ListarItemsIndiceBase();
        }

        public List<CtoInspectorFiscal> ObtenerListadoInspectorFiscalActivos()
        {
            return _unitOfWork.CtoInspectorFiscalRepositorio.ObtenerListadoInspectorFiscalActivos();
        }

        public List<CtoVisitador> ObtenerListadoVisitadoresActivos()
        {
            return _unitOfWork.CtoVisitadorRepositorio.ObtenerListadoVisitadoresActivos();
        }

        public List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario)
        {
            return _unitOfWork.CtoContratoRepositorio.ObtenerAsesoriaContratosEnEjecucionOrGarantia(pGrupoUsuario);
        }

        public List<CtoContratista> ObtenerContratistas()
        {
            return _unitOfWork.CtoContratistaRepositorio.ObtenerContratistas();
        }

        public List<CtoResidente> ObtenerListadoResidente()
        {
            return _unitOfWork.CtoResidenteRepositorio.ObtenerListadoResidente();
        }

        public List<CtoResidente> BuscarResidentePorPalabraClave(string pPalabraClave)
        {
            return _unitOfWork.CtoResidenteRepositorio.BuscarResidentePorPalabraClave(pPalabraClave);
        }
    }
}
