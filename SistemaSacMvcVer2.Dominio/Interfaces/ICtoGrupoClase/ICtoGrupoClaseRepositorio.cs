using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoGrupoClase
{
    public interface ICtoGrupoClaseRepositorio
    {
        List<CtoGrupoClase> ListarAdministracionPorClaseUsuario(string pGrupoUsuario);
    }
}
