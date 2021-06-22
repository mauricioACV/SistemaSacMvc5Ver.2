using SistemaSacMvcVer2.Aplicación.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SistemaSacMvcVer2.Infraestructura.Servicios.EncriptaService
{
    public class EncriptaServiceRepositorio : IEncriptaServiceRepositorio
    {
        public string EncriptaMD5(string pString)
        {
            var stringSource = pString;
            var tmpSource = Encoding.ASCII.GetBytes(stringSource);
            var tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            StringBuilder stringOutput = new StringBuilder(tmpHash.Length);
            for (int i = 0; i < tmpHash.Length; i++)
            {
                stringOutput.Append(tmpHash[i].ToString("X2"));
            }

            return stringOutput.ToString();
        }
    }
}
