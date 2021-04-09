using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratoModifica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoContratoModificaRepositorio : ICtoContratoModificaRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoContratoModificaRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<string> ObtenerCodigosCarpetaLiquidadosPorGrupoEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaLiquidados = new List<string>();

            try
            {
                var query = @"SELECT M.CODIGO_CARPETA from CTO_CONTRATO_MODIFICA M
                                INNER JOIN CTO_CONTRATO C ON C.CODIGO_CARPETA = M.CODIGO_CARPETA
                                WHERE
                                M.ESTADO = 'TRAMITADA'
                                AND
                                M.TIPO = 'LIQUIDADO'
                                AND
                                M.FECHA_TRAMITE BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                                AND
                                C.GRUPO = :pGrupo
                                AND
                                C.ESTADO_CONTRATO = 'LIQUIDADO'";

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));

                    conexionDb.Open();

                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CodigosCarpetaLiquidados.Add(dr["CODIGO_CARPETA"].ToString());
                        }
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

            return CodigosCarpetaLiquidados;
        }

        public List<string> ObtenerCodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaLiquidados = new List<string>();

            try
            {
                var query = @"SELECT M.CODIGO_CARPETA from CTO_CONTRATO_MODIFICA M
                                INNER JOIN CTO_CONTRATO C ON C.CODIGO_CARPETA = M.CODIGO_CARPETA
                                WHERE
                                M.ESTADO = 'TRAMITADA'
                                AND
                                M.TIPO = 'LIQUIDADO'
                                AND
                                M.FECHA_TRAMITE BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                                AND
                                C.GRUPO = :pGrupo
                                AND
                                C.ESTADO_CONTRATO = 'LIQUIDADO'
                                and
                                C.TIPO_CONTRATO = :pTipoContrato";

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroReporteBasico.TipoContrato));

                    conexionDb.Open();

                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CodigosCarpetaLiquidados.Add(dr["CODIGO_CARPETA"].ToString());
                        }
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

            return CodigosCarpetaLiquidados;
        }

        public List<string> ObtenerCodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaLiquidados = new List<string>();

            try
            {
                var query = @"SELECT M.CODIGO_CARPETA from CTO_CONTRATO_MODIFICA M
                                INNER JOIN CTO_CONTRATO C ON C.CODIGO_CARPETA = M.CODIGO_CARPETA
                                WHERE
                                M.ESTADO = 'TRAMITADA'
                                AND
                                M.TIPO = 'LIQUIDADO'
                                AND
                                M.FECHA_TRAMITE BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                                AND
                                C.GRUPO = :pGrupo
                                AND
                                C.ESTADO_CONTRATO = 'LIQUIDADO'
                                and
                                C.TIPO_CONTRATO <> '01'
                                and
                                C.TIPO_CONTRATO <> '00'";

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));

                    conexionDb.Open();

                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CodigosCarpetaLiquidados.Add(dr["CODIGO_CARPETA"].ToString());
                        }
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

            return CodigosCarpetaLiquidados;
        }
    }
}
