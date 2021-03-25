using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
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

        public List<ReportesSac> ObtenerListadoBasicoObras(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBacisoObras = new List<ReportesSac>();
            ListadoBacisoObras = _unitOfWork.ReportesSac.ObtenerListadoBasicoObrasPorEstadoYgrupo(filtroReporteBasico);

            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasPorCentral(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoBacisoObras.Add(_unitOfWork.ReportesSac.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }


            return ListadoBacisoObras;
        }
    }
}
