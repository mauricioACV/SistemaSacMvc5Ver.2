using SistemaSacMvcVer2.Dominio.Interfaces.ICtoComuna;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratista;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratoModifica;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoDominio;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoGrupoClase;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoInspectorFiscal;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoResidente;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoUsuario;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoVisitador;
using SistemaSacMvcVer2.Dominio.Interfaces.IIndiceBase;
using SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac;
using System;

namespace SistemaSacMvcVer2.Dominio.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ICtoDominioRepositorio CtoDominioRepositorio { get; }

        ICtoGrupoClaseRepositorio CtoGrupoClaseRepositorio { get; }

        IIndiceBaseRepositorio IndiceBaseRepositorio { get; }

        ICtoInspectorFiscalRepositorio CtoInspectorFiscalRepositorio { get; }

        ICtoVisitadorRepositorio CtoVisitadorRepositorio { get; }

        ICtoContratoRepositorio CtoContratoRepositorio { get; }

        ICtoContratistaRepositorio CtoContratistaRepositorio { get; }

        ICtoResidenteRepositorio CtoResidenteRepositorio { get; }

        ICtoComunaRepositorio CtoComunaRepositorio { get; }

        IReportesSacRepositorio ReportesSacRepositorio { get; }

        ICtoContratoModificaRepositorio CtoContratoModificaRepositorio { get; }

        ICtoUsuarioRepositorio CtoUsuarioRepositorio { get; }
    }
}
