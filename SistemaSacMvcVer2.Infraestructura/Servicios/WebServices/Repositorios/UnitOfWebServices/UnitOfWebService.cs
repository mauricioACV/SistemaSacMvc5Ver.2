using SistemaSacMvcVer2.Infraestructura.Interfaces;
using SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Interfaces;

namespace SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Repositorios.UnitOfWebService
{
    public class UnitOfWebService : IUnitOfWebService
    {
#pragma warning disable 0649
        private readonly ISafiWebServiceRepositorio _safiWebServiceRepositorio;
#pragma warning restore 0649

        public ISafiWebServiceRepositorio SafiWebServiceRepositorio => _safiWebServiceRepositorio ?? new SafiWebServiceRepositorio();

    }
}
