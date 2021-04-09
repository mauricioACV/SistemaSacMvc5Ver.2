using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoComuna;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratista;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratoModifica;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoDominio;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoGrupoClase;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoInspectorFiscal;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoResidente;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoVisitador;
using SistemaSacMvcVer2.Dominio.Interfaces.IIndiceBase;
using SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
#pragma warning disable 0649
        private readonly OracleConnection _conexion;
        private readonly ICtoDominioRepositorio _ctoDominioRepositorio;
        private readonly ICtoGrupoClaseRepositorio _ctoGrupoClaseRepositorio;
        private readonly IIndiceBaseRepositorio _indiceBaseRepositorio;
        private readonly ICtoInspectorFiscalRepositorio _ctoInspectorFiscalRepositorio;
        private readonly ICtoVisitadorRepositorio _ctoVisitadorRepositorio;
        private readonly ICtoContratoRepositorio _ctoContratoRepositorio;
        private readonly ICtoContratistaRepositorio _ctoContratistaRepositorio;
        private readonly ICtoResidenteRepositorio _ctoResidenteRepositorio;
        private readonly ICtoComunaRepositorio _ctoComunaRepositorio;
        private readonly IReportesSacRepositorio _reportesSacRepositorio;
        private readonly ICtoContratoModificaRepositorio _ctoContratoModificaRepositorio;
#pragma warning restore 0649

        public UnitOfWork()
        {
            _conexion = ConexionBD.ObtenerInstancia().ObtenerConexionBD();
        }

        public ICtoDominioRepositorio CtoDominioRepositorio => _ctoDominioRepositorio ?? new CtoDominioRepositorio(_conexion);

        public ICtoGrupoClaseRepositorio CtoGrupoClaseRepositorio => _ctoGrupoClaseRepositorio ?? new CtoGrupoClaseRepositorio(_conexion);

        public IIndiceBaseRepositorio IndiceBaseRepositorio => _indiceBaseRepositorio ?? new IndiceBaseRepositorio(_conexion);

        public ICtoInspectorFiscalRepositorio CtoInspectorFiscalRepositorio => _ctoInspectorFiscalRepositorio ?? new CtoInspectorFiscalRepositorio(_conexion);

        public ICtoVisitadorRepositorio CtoVisitadorRepositorio => _ctoVisitadorRepositorio ?? new CtoVisitadorRepositorio(_conexion);

        public ICtoContratoRepositorio CtoContratoRepositorio => _ctoContratoRepositorio ?? new CtoContratoRepositorio(_conexion);

        public ICtoContratistaRepositorio CtoContratistaRepositorio => _ctoContratistaRepositorio ?? new CtoContratistaRepositorio(_conexion);

        public ICtoResidenteRepositorio CtoResidenteRepositorio => _ctoResidenteRepositorio ?? new CtoResidenteRepositorio(_conexion);

        public ICtoComunaRepositorio CtoComunaRepositorio => _ctoComunaRepositorio ?? new CtoComunaRepositorio(_conexion);

        public IReportesSacRepositorio ReportesSacRepositorio => _reportesSacRepositorio ?? new ReportesSacRepositorio(_conexion);

        public ICtoContratoModificaRepositorio CtoContratoModificaRepositorio => _ctoContratoModificaRepositorio ?? new CtoContratoModificaRepositorio(_conexion);

        public void Dispose()
        {
            if(_conexion != null)
            {
                _conexion.Dispose();
            }
        }
    }
}
