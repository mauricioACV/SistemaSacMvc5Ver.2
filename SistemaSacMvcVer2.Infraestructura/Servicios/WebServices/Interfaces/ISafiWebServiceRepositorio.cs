using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Interfaces
{
    public interface ISafiWebServiceRepositorio
    {
        List<CtoContrato> ObtenerInfoContratoPorCodigoSafi(int pCodigoSafi);
    }
}
