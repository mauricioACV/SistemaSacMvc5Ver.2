using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace SistemaSacMvcVer2.Infraestructura
{
    public class ConexionBD
    {
        #region "Singleton"
        private static ConexionBD instanciaBd = null;
        private ConexionBD() { }
        public static ConexionBD ObtenerInstancia()
        {
            if(instanciaBd == null)
            {
                instanciaBd = new ConexionBD();
            }

            return instanciaBd;
        }
        #endregion

        public OracleConnection ObtenerConexionBD()
        {
            OracleConnection conexion = new OracleConnection
            {
                ConnectionString = ConfigurationManager.AppSettings["DB_ORACLE_PRODUCCION"].ToString()
            };

            return conexion;
        }
    }
}
