using SistemaSacMvcVer2.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoDominio
{
    public interface ICtoDominioRepositorio
    {
        List<CtoDominio> ObtenerItemsPorDominio(string pDominio);

        List<CtoDominio> ObtenerItemsPorDominioUsuario(string pDominio, string pGrupoUsuario);
    }
}
