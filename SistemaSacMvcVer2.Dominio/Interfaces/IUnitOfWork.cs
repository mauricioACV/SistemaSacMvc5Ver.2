using SistemaSacMvcVer2.Dominio.Interfaces.ICtoDominio;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoGrupoClase;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoInspectorFiscal;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoVisitador;
using SistemaSacMvcVer2.Dominio.Interfaces.IIndiceBase;
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
    }
}
