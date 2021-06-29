using SistemaSacMvcVer2.Aplicación.Interfaces;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoUsuario;
using System;

namespace SistemaSacMvcVer2.Aplicación.Servicios
{
    public class CtoUsuarioServicio : ICtoUsuarioServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncriptaServiceRepositorio _encriptaServiceRepositorio;

        public CtoUsuarioServicio(IUnitOfWork unitOfWork, IEncriptaServiceRepositorio encriptaServiceRepositorio)
        {
            _unitOfWork = unitOfWork;
            _encriptaServiceRepositorio = encriptaServiceRepositorio;
        }

        public CtoUsuario ObtenerUsuario(string pUsuario, string pClave)
        {
            string pClaveCripto = _encriptaServiceRepositorio.EncriptaMD5(pClave);

            var objUsuario = _unitOfWork.CtoUsuarioRepositorio.ObtenerUsuario(pUsuario, pClaveCripto);

            return objUsuario;
        }
    }
}
