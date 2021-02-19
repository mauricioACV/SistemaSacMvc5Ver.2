using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoVisitador
{
    public interface ICtoVisitadorRepositorio
    {
        List<CtoVisitador> ObtenerListadoVisitadoresActivos();
    }
}
