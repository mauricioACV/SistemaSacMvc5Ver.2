using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
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

        public List<string> ObtenerObrasRegionalesAdministradasCentralPorEstadoContratoGrupo(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionalesAdmCentral = new List<string>();

            try
            {
                var query = @"select distinct(c.CODIGO_CARPETA) from cto_contrato c
                                inner join cto_contrato_comuna com on c.CODIGO_CARPETA = com.CODIGO_CARPETA
                                where c.estado_contrato = :pEstadoContrato and (C.GRUPO = 'CENTRAL' and com.region = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroReporteBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroReporteBasico.Grupo));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoObrasRegionalesAdmCentral.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoObrasRegionalesAdmCentral;
        }

        public List<string> ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionalesAdmCentralTipoContrato = new List<string>();

            try
            {
                var query = @"select distinct(c.CODIGO_CARPETA) from cto_contrato c
                                inner join cto_contrato_comuna com on c.CODIGO_CARPETA = com.CODIGO_CARPETA
                                where c.estado_contrato = :pEstadoContrato and c.tipo_contrato = :pTipoContrato and (C.GRUPO = 'CENTRAL' and com.region = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroReporteBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroReporteBasico.TipoContrato));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroReporteBasico.Grupo));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoObrasRegionalesAdmCentralTipoContrato.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoObrasRegionalesAdmCentralTipoContrato;
        }

        public List<string> ObtenerObrasRegionalesAdministradasCentralPorEstadoSoloObras(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoSoloObrasRegionalesAdmCentral = new List<string>();

            try
            {
                var query = @"select distinct(c.CODIGO_CARPETA) from cto_contrato c
                                inner join cto_contrato_comuna com on c.CODIGO_CARPETA = com.CODIGO_CARPETA
                                where c.estado_contrato = :pEstadoContrato and (c.tipo_contrato <> '00' and c.tipo_contrato <> '01') and (C.GRUPO = 'CENTRAL' and com.region = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroReporteBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroReporteBasico.Grupo));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoSoloObrasRegionalesAdmCentral.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoSoloObrasRegionalesAdmCentral;
        }

        public List<string> CodigosCarpetaEnGarantiaPorGrupoEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaEnGarantia = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato where
                              fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                              and grupo = :pGrupo
                              and estado_contrato = 'EN GARANTIA'";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpetaEnGarantia.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpetaEnGarantia;
        }

        public List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaEnGarantia = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato
                              where
                              fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                              and grupo = :pGrupo
                              and estado_contrato = 'EN GARANTIA'
                              and tipo_contrato = :pTipoContrato";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroReporteBasico.TipoContrato));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpetaEnGarantia.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpetaEnGarantia;
        }

        public List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(ReportesSacFiltros filtroReporteBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaEnGarantia = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato
                              where
                              fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                              and GRUPO = :pGrupo
                              and ESTADO_CONTRATO = 'EN GARANTIA'
                              and TIPO_CONTRATO <> '01'
                              and TIPO_CONTRATO <> '00'";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroReporteBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroReporteBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroReporteBasico.Grupo));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpetaEnGarantia.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpetaEnGarantia;
        }
    }
}
