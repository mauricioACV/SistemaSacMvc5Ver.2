using SistemaSacMvcVer2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Interfaces
{
    public interface ISafiWebServiceRepositorio
    {
        List<CtoContrato> ObtenerInfoContratoPorCodigoSafi(int pCodigoSafi);
    }
}
