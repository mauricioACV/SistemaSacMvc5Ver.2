using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoDominio;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoGrupoClase;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoInspectorFiscal;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoVisitador;
using SistemaSacMvcVer2.Dominio.Interfaces.IIndiceBase;
using SistemaSacMvcVer2.Infraestructura.Repositorios;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
#pragma warning disable 0649
        private readonly OracleConnection _conexion;
        private readonly ICtoDominioRepositorio _ctoDominioRepositorio;
        private readonly ICtoGrupoClaseRepositorio _ctoGrupoClaseRepositorio;
        private readonly IIndiceBaseRepositorio _indiceBaseRepositorio;
        private readonly ICtoInspectorFiscalRepositorio _inspectorFiscalRepositorio;
        private readonly ICtoVisitadorRepositorio _visitadorRepositorio;

#pragma warning restore 0649

        public UnitOfWork()
        {
            _conexion = ConexionBD.ObtenerInstancia().ObtenerConexionBD();
        }

        public ICtoDominioRepositorio CtoDominioRepositorio => _ctoDominioRepositorio ?? new CtoDominioRepositorio(_conexion);

        public ICtoGrupoClaseRepositorio CtoGrupoClaseRepositorio => _ctoGrupoClaseRepositorio ?? new CtoGrupoClaseRepositorio(_conexion);

        public IIndiceBaseRepositorio IndiceBaseRepositorio => _indiceBaseRepositorio ?? new IndiceBaseRepositorio(_conexion);

        public ICtoInspectorFiscalRepositorio CtoInspectorFiscalRepositorio => _inspectorFiscalRepositorio ?? new CtoInspectorFiscalRepositorio(_conexion);

        public ICtoVisitadorRepositorio CtoVisitadorRepositorio => _visitadorRepositorio ?? new CtoVisitadorRepositorio(_conexion);

        public void Dispose()
        {
            _conexion?.Dispose();
        }
    }
}
