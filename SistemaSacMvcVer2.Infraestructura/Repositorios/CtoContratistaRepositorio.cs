using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratista;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoContratistaRepositorio : ICtoContratistaRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoContratistaRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<CtoContratista> ObtenerContratistas()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoContratista> ListadoContratista = new List<CtoContratista>();

            try
            {
                var query = @"select RUT, RAZON_SOCIAL from CTO_CONTRATISTA";
                cmd = new OracleCommand(query, conexionDb);

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoContratista objCtoContratista = new CtoContratista
                        {
                            Rut = Convert.ToInt32(dr["RUT"]),
                            RazonSocial = dr["RAZON_SOCIAL"].ToString()
                        };

                        ListadoContratista.Add(objCtoContratista);
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

            return ListadoContratista;
        }
    }
}
