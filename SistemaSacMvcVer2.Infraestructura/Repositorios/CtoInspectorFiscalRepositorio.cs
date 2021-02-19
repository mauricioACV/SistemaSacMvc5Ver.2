using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoInspectorFiscal;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoInspectorFiscalRepositorio : ICtoInspectorFiscalRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoInspectorFiscalRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<CtoInspectorFiscal> ObtenerListadoInspectorFiscalActivos()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoInspectorFiscal> ListadoInspectorFiscal = new List<CtoInspectorFiscal>();

            try
            {
                var query = @"select RUT, APELLIDOS, NOMBRES from CTO_INSPECTORFISCAL  where ESTADO = 'ACTIVO' order by APELLIDOS";
                cmd = new OracleCommand(query, conexionDb);

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoInspectorFiscal objInspectorFiscal = new CtoInspectorFiscal
                        {
                            Rut = Convert.ToInt32(dr["RUT"] is DBNull ? "0" : dr["RUT"]),
                            Nombres = dr["NOMBRES"].ToString(),
                            Apellidos = dr["APELLIDOS"].ToString()

                        };

                        ListadoInspectorFiscal.Add(objInspectorFiscal);
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

            return ListadoInspectorFiscal;
        }
    }
}
