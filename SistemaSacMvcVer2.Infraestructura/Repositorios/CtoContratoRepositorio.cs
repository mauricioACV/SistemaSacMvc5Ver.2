using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoContratoRepositorio : ICtoContratoRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoContratoRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<CtoContrato> ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<CtoContrato> ListadoContrato = new List<CtoContrato>();

            try
            {
                var query = @"select CODIGO_CARPETA, Replace(NOMBRE_CONTRATO,Chr(34),'') as NOMBRE_CONTRATO from CTO_CONTRATO where TIPO_CONTRATO='00' AND (ESTADO_CONTRATO='EN EJECUCION' or ESTADO_CONTRATO='EN GARANTIA')  AND grupo = :pGrupoUsuario order by CODIGO_CARPETA";
                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter("pGrupoUsuario", pGrupoUsuario));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CtoContrato objCtoContrato = new CtoContrato
                        {
                            CodigoCarpeta = dr["CODIGO_CARPETA"].ToString(),
                            NombreContrato = dr["NOMBRE_CONTRATO"].ToString()
                        };

                        ListadoContrato.Add(objCtoContrato);
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

            return ListadoContrato;
        }
    }
}
