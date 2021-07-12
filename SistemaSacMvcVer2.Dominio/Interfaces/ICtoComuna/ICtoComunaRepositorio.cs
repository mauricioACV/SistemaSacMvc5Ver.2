using SistemaSacMvcVer2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoComuna
{
    public interface ICtoComunaRepositorio
    {
        List<CtoComuna> ObtenerRegiones();
        List<CtoComuna> ObtenerComunasGruposNivelCentral();
        List<CtoComuna> ObtenerComunasPorGrupoRegiones(string pPegionUsuario);
    }
}
