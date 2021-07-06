using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoComuna;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoComunaRepositorio : ICtoComunaRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoComunaRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<CtoComuna> ObtenerRegiones()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoComuna> ListadoRegiones = new List<CtoComuna>();

            try
            {
                var query = @"select distinct(REGION) from CTO_COMUNA";
                cmd = new OracleCommand(query, conexionDb);

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoComuna objComuna = new CtoComuna
                        {
                            Region = dr["REGION"].ToString()
                        };

                        ListadoRegiones.Add(objComuna);
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

            return ListadoRegiones;
        }

        public List<CtoComuna> ObtenerComunasGruposNivelCentral()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoComuna> ListadoComunas = new List<CtoComuna>();

            try
            {
                var query = @"select COMUNA, REGION from CTO_comuna order by ID_REGION";
                cmd = new OracleCommand(query, conexionDb);

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoComuna objComuna = new CtoComuna
                        {
                            Region = dr["REGION"].ToString(),
                            Comuna = dr["COMUNA"].ToString()
                        };

                        ListadoComunas.Add(objComuna);
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

            return ListadoComunas;
        }
    }
}
