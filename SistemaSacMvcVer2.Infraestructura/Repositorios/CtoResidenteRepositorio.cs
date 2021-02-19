using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoResidente;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoResidenteRepositorio : ICtoResidenteRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoResidenteRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<CtoResidente> ObtenerListadoResidente()
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoResidente> ListadoResidentes = new List<CtoResidente>();

            try
            {
                var query = @"select RUT, APELLIDOS, NOMBRES, (select COALESCE(count(RUT_RESIDENTE),0)  from CTO_CONTRATO where CTO_CONTRATO.RUT_RESIDENTE = CTO_RESIDENTE.RUT and CTO_CONTRATO.ESTADO_CONTRATO = 'EN EJECUCION') as TOTAL from CTO_RESIDENTE group by RUT, APELLIDOS, NOMBRES order by APELLIDOS";
                cmd = new OracleCommand(query, conexionDb);

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoResidente objCtoResidente = new CtoResidente
                        {
                            Rut = Convert.ToInt32(dr["RUT"]),
                            Nombres = dr["NOMBRES"].ToString(),
                            Apellidos = dr["APELLIDOS"].ToString(),
                            TotalObrasEnEjecucion = Convert.ToInt32(dr["TOTAL"])
                        };

                        ListadoResidentes.Add(objCtoResidente);
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

            return ListadoResidentes;
        }
    }
}
