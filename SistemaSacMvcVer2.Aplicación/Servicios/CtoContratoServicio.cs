using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato;

namespace SistemaSacMvcVer2.Aplicación.Servicios
{
    public class CtoContratoServicio : ICtoContratoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public CtoContratoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
