using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Aplicación.Servicios
{

    public class ReportesSacServicio : IReportesSacServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportesSacServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ReportesSac> ObtenerListadoBasicoObras()
        {
            return _unitOfWork.ReportesSac.ObtenerListadoBasicoObras();
        }
    }
}
