using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoUsuario;
using System;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoUsuarioRepositorio : ICtoUsuarioRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoUsuarioRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public CtoUsuario ObtenerUsuario(string pUsuario, string pClave)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            CtoUsuario objUsuario = new CtoUsuario();

            try
            {
                var query = @"select NOMBRES, APELLIDOS, GRUPO, USUARIO, TIPO_USUARIO from CTO_USUARIO
                              where
                              upper(USUARIO) = upper(:pUsuario)
                              and CLAVE = :pClave";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pUsuario", pUsuario));
                cmd.Parameters.Add(new OracleParameter(":pClave", pClave));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objUsuario.Nombres = dr["NOMBRES"].ToString();
                        objUsuario.Apellidos = dr["APELLIDOS"].ToString();
                        objUsuario.Grupo = dr["GRUPO"].ToString();
                        objUsuario.Usuario = dr["USUARIO"].ToString();
                        objUsuario.TipoUsuario = dr["TIPO_USUARIO"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDb.Close();
            }

            return objUsuario;
        }
    }
}
