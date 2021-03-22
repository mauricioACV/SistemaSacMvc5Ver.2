using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoGrupoClase;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Aplicación.Servicios
{


    public class CtoGrupoClaseServicio : ICtoGrupoClaseServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public CtoGrupoClaseServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CtoGrupoClase> ListarGrupoClase()
        {
            //Reglas de aplicación
            return _unitOfWork.CtoGrupoClaseRepositorio.ListarGrupoClase();
        }

        public List<CtoComuna> ObtenerRegiones()
        {
            return _unitOfWork.CtoComunaRepositorio.ObtenerRegiones();
        }
    }
}
