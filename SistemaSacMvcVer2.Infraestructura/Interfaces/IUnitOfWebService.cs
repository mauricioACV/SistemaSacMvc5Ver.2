using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Infraestructura.Interfaces
{
    public interface IUnitOfWebService
    {
        ISafiWebServiceRepositorio SafiWebServiceRepositorio { get; }
    }
}
