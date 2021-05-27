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

        public List<string> CodigosCarpetaLiquidadosPorGrupoEntreFechas(ReportesSacFiltros filtroReporteBasico)
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
                                C.GRUPO = :pGrupo";


                //AND
                //                C.ESTADO_CONTRATO = 'LIQUIDADO'

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

        public List<string> CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico)
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
                                C.TIPO_CONTRATO = :pTipoContrato";


                //AND
                //                C.ESTADO_CONTRATO = 'LIQUIDADO'

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

        public List<string> CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico)
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
                                C.TIPO_CONTRATO <> '01'
                                AND
                                C.TIPO_CONTRATO <> '00'";


                //AND
                //                C.ESTADO_CONTRATO = 'LIQUIDADO'

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

        public List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaLiquidadosPorGrupoAdminFechas = new List<string>();

            try
            {
                var query = @"select distinct(c.codigo_carpeta), c.GRUPO, com.region from cto_contrato c 
                                inner join cto_contrato_comuna com on c.codigo_carpeta = com.codigo_carpeta 
                                inner join cto_contrato_modifica M on com.codigo_carpeta = m.codigo_carpeta 
                                where
                                C.GRUPO = :pGrupo 
                                and com.region = :pRegion 
                                and m.tipo = 'LIQUIDADO' 
                                and m.fecha_tramite BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";


                //and
                //c.estado_contrato = 'LIQUIDADO'
                                

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pRegion", filtroReporteBasico.Region));
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));

                    conexionDb.Open();

                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CodigosCarpetaLiquidadosPorGrupoAdminFechas.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpetaLiquidadosPorGrupoAdminFechas;
        }

        public List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaLiquidadosPorGrupoAdminFechas = new List<string>();

            try
            {
                var query = @"select distinct(c.codigo_carpeta), c.GRUPO, com.region from cto_contrato c 
                                inner join cto_contrato_comuna com on c.codigo_carpeta = com.codigo_carpeta 
                                inner join cto_contrato_modifica M on com.codigo_carpeta = m.codigo_carpeta 
                                where 
                                c.TIPO_CONTRATO = :pTipoContrato
                                and C.GRUPO = :pGrupo 
                                and com.region = :pRegion 
                                and m.tipo = 'LIQUIDADO' 
                                and m.fecha_tramite BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                //and
                //c.estado_contrato = 'LIQUIDADO'

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroReporteBasico.TipoContrato));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pRegion", filtroReporteBasico.Region));
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));

                    conexionDb.Open();

                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CodigosCarpetaLiquidadosPorGrupoAdminFechas.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpetaLiquidadosPorGrupoAdminFechas;
        }

        public List<string> CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaLiquidadosPorGrupoAdminFechas = new List<string>();

            try
            {
                var query = @"select distinct(c.codigo_carpeta), c.grupo, com.region from cto_contrato c
                                inner join cto_contrato_comuna com on c.codigo_carpeta = com.codigo_carpeta
                                inner join cto_contrato_modifica M on com.codigo_carpeta = m.codigo_carpeta
                                where
                                C.GRUPO = :pGrupo
                                and (c.tipo_contrato <> '00' and c.tipo_contrato <> '01') 
                                and com.region = :pRegion
                                and m.tipo = 'LIQUIDADO'
                                and m.fecha_tramite BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                //and
                //c.estado_contrato = 'LIQUIDADO'

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pRegion", filtroReporteBasico.Region));
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));

                    conexionDb.Open();

                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CodigosCarpetaLiquidadosPorGrupoAdminFechas.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpetaLiquidadosPorGrupoAdminFechas;
        }
    }
}
