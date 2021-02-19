using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratista
{
    public interface ICtoContratistaRepositorio
    {
        List<CtoContratista> ObtenerContratistas();
    }
}
