using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.IDominioItemsFormulario;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Aplicación.Servicios
{
    public class DominioItemsFormularioServicio : IDominioItemsFormularioServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public DominioItemsFormularioServicio(IUnitOfWork unitOfWork)
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

        public List<CtoResidente> BuscarResidentePorPalabraClave(string pPalabraClave)
        {
            return _unitOfWork.CtoResidenteRepositorio.BuscarResidentePorPalabraClave(pPalabraClave);
        }

        public List<CtoGrupoClase> ListarGrupoClase()
        {
            return _unitOfWork.CtoGrupoClaseRepositorio.ListarGrupoClase();
        }

        public List<CtoComuna> ObtenerRegiones()
        {
            return _unitOfWork.CtoComunaRepositorio.ObtenerRegiones();
        }

        public List<CtoComuna> ObtenerComunas(string pGrupoUsuario)
        {
            List<CtoComuna> ListadoComunas = new List<CtoComuna>();

            if (pGrupoUsuario == "CENTRAL" || pGrupoUsuario == "D.I.V.URBANA" || pGrupoUsuario == "D.INGENIERIA" || pGrupoUsuario == "D.REDES")
            {
                ListadoComunas = _unitOfWork.CtoComunaRepositorio.ObtenerComunasGruposNivelCentral();
            }
            else
            {
                ListadoComunas = _unitOfWork.CtoComunaRepositorio.ObtenerComunasPorGrupoRegiones(pGrupoUsuario);
            }

            return ListadoComunas;
        }
    }
}
