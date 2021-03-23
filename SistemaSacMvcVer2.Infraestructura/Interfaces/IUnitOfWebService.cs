using SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Interfaces;

namespace SistemaSacMvcVer2.Infraestructura.Interfaces
{
    public interface IUnitOfWebService
    {
        ISafiWebServiceRepositorio SafiWebServiceRepositorio { get; }
    }
}
