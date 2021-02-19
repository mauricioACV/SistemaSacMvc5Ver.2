using SistemaSacMvcVer2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Dominio.Interfaces.ICtoInspectorFiscal
{
    public interface ICtoInspectorFiscalRepositorio
    {
        List<CtoInspectorFiscal> ObtenerListadoInspectorFiscalActivos();
    }
}
