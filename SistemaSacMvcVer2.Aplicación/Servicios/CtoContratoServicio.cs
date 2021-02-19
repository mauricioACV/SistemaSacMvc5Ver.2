using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Aplicación.Servicios
{
    public class CtoContratoServicio : ICtoContratoServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IUnitOfWebService _unitOfWebService;

        public CtoContratoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CtoGrupoClase> ListarAdministracionPorClaseUsuario(string pGrupoUsuario)
        {
            //Reglas de negocio
            return _unitOfWork.CtoGrupoClaseRepositorio.ListarAdministracionPorClaseUsuario(pGrupoUsuario);
        }

        public List<CtoDominio> ListarItemsPorDominioUsuario(string pDominio, string pGrupoUsuario)
        {
            //Reglas de negocio
            return _unitOfWork.CtoDominioRepositorio.ObtenerItemsPorDominioUsuario(pDominio, pGrupoUsuario);
        }

        public List<CtoDominio> ListarItemsPorDominio(string pDominio)
        {
            //Reglas de negocio
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
    }
}
