using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoVisitador;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoVisitadorRepositorio : ICtoVisitadorRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoVisitadorRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<CtoVisitador> ObtenerListadoVisitadoresActivos()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoVisitador> ListadoVisitadores = new List<CtoVisitador>();

            try
            {
                var query = @"select RUT, APELLIDOS, NOMBRES from CTO_VISITADOR  where ESTADO='ACTIVO' order by APELLIDOS";
                cmd = new OracleCommand(query, conexionDb);

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoVisitador objVisitador = new CtoVisitador
                        {
                            Rut = Convert.ToInt32(dr["RUT"] is DBNull ? "0" : dr["RUT"]),
                            Nombres = dr["NOMBRES"].ToString(),
                            Apellidos = dr["APELLIDOS"].ToString()

                        };

                        ListadoVisitadores.Add(objVisitador);
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

            return ListadoVisitadores;
        }
    }
}
