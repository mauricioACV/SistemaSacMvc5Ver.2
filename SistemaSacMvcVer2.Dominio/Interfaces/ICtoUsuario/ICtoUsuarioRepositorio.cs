using SistemaSacMvcVer2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoUsuario
{
    public interface ICtoUsuarioRepositorio
    {
        CtoUsuario ObtenerUsuario(string pUsuario, string pClave);
    }
}
