using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Common.Models;
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

        public List<string> CodigosCarpetaPorGrupoPorEstado(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpeta = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato
                              where
                              GRUPO = :pGrupo
                              and ESTADO_CONTRATO = :pEstadoContrato";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpeta.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpeta;
        }

        public List<string> CodigosCarpetaPorGrupoPorEstadoPorClase(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpeta = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato
                              where
                              GRUPO = :pGrupo
                              and ESTADO_CONTRATO = :pEstadoContrato
                              and CLASE = :pClase";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpeta.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpeta;
        }

        public List<string> CodigosCarpetaEnGarantiaPorGrupoEntreFechas(SacFiltros filtroBasico)
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
                              and estado_contrato = 'EN GARANTIA'";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));

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

        public List<string> CodigosCarpetaEnGarantiaPorGrupoPorClaseEntreFechas(SacFiltros filtroBasico)
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
                              and CLASE = :pClase";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Clase));

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

        public List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoContrato(SacFiltros filtroBasico)
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
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Grupo));
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

        public List<string> CodigosCarpetaSoloObrasPorGrupoPorEstado(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpeta = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato
                              where
                              GRUPO = :pGrupo
                              and ESTADO_CONTRATO = :pEstadoContrato
                              and TIPO_CONTRATO <> '01'
                              and TIPO_CONTRATO <> '00'";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpeta.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpeta;
        }

        public List<string> CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpeta = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato
                              where
                              GRUPO = :pGrupo
                              and ESTADO_CONTRATO = :pEstadoContrato
                              and CLASE = :pClase
                              and TIPO_CONTRATO <> '01'
                              and TIPO_CONTRATO <> '00'";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpeta.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpeta;
        }

        public List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(SacFiltros filtroBasico)
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
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));

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

        public List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(SacFiltros filtroBasico)
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
                              and CLASE = :pClase
                              and TIPO_CONTRATO <> '01'
                              and TIPO_CONTRATO <> '00'";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));

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

        public List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(SacFiltros filtroBasico)
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
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));

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

        public List<string> CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(SacFiltros filtroBasico)
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
                              and clase = :pClase
                              and estado_contrato = 'EN GARANTIA'
                              and tipo_contrato = :pTipoContrato";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));

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

        public List<string> CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpeta = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato
                              where
                              grupo = :pGrupo
                              and estado_contrato = :pEstadoContrato
                              and tipo_contrato = :pTipoContrato";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpeta.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpeta;
        }

        public List<string> CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpeta = new List<string>();

            try
            {
                var query = @"select codigo_carpeta, grupo from cto_contrato
                              where
                              grupo = :pGrupo
                              and estado_contrato = :pEstadoContrato
                              and clase = :pClase
                              and tipo_contrato = :pTipoContrato";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));

                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CodigosCarpeta.Add(dr["CODIGO_CARPETA"].ToString());
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

            return CodigosCarpeta;
        }

        public List<string> CodigosCarpetaContratosRegionPorGrupoAdminEnGarantiaEntreFechas(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionGrupoAdminFechas = new List<string>();

            try
            {
                var query = @"select distinct(C.CODIGO_CARPETA) from cto_contrato C
                                inner join cto_contrato_comuna COM on C.CODIGO_CARPETA = COM.CODIGO_CARPETA
                                where
                                C.fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                                and C.estado_contrato = 'EN GARANTIA' 
                                and (C.GRUPO = :pGrupo and COM.region = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoObrasRegionGrupoAdminFechas.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoObrasRegionGrupoAdminFechas;
        }

        public List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorClaseEnGarantiaEntreFechas(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionGrupoAdminFechas = new List<string>();

            try
            {
                var query = @"select distinct(C.CODIGO_CARPETA) from cto_contrato C
                                inner join cto_contrato_comuna COM on C.CODIGO_CARPETA = COM.CODIGO_CARPETA
                                where
                                C.fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                                and C.ESTADO_CONTRATO = 'EN GARANTIA' 
                                and C.CLASE = :pClase 
                                and (C.GRUPO = :pGrupo and COM.region = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoObrasRegionGrupoAdminFechas.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoObrasRegionGrupoAdminFechas;
        }

        public List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContrato(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionGrupoAdmin = new List<string>();

            try
            {
                var query = @"select distinct(C.CODIGO_CARPETA) from cto_contrato C
                                inner join cto_contrato_comuna COM on C.CODIGO_CARPETA = COM.CODIGO_CARPETA
                                where 
                                C.estado_contrato = :pEstadoContrato 
                                and (C.GRUPO = :pGrupo and COM.region = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoObrasRegionGrupoAdmin.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoObrasRegionGrupoAdmin;
        }

        public List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorClase(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionGrupoAdmin = new List<string>();

            try
            {
                var query = @"select distinct(C.CODIGO_CARPETA) from cto_contrato C
                                inner join cto_contrato_comuna COM on C.CODIGO_CARPETA = COM.CODIGO_CARPETA
                                where 
                                C.ESTADO_CONTRATO = :pEstadoContrato 
                                and C.CLASE = :pClase 
                                and (C.GRUPO = :pGrupo and COM.region = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoObrasRegionGrupoAdmin.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoObrasRegionGrupoAdmin;
        }

        public List<string> CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionalesAdmCentralTipoContrato = new List<string>();

            try
            {
                var query = @"select distinct(c.CODIGO_CARPETA) from cto_contrato c
                                inner join cto_contrato_comuna com on c.CODIGO_CARPETA = com.CODIGO_CARPETA
                                where 
                                c.estado_contrato = 'EN GARANTIA' 
                                and C.tipo_contrato = :pTipoContrato 
                                and C.GRUPO = :pGrupo 
                                and com.region = :pRegion
                                and C.fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
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

        public List<string> CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionalesAdmCentralTipoContrato = new List<string>();

            try
            {
                var query = @"select distinct(c.CODIGO_CARPETA) from cto_contrato c
                                inner join cto_contrato_comuna com on c.CODIGO_CARPETA = com.CODIGO_CARPETA
                                where 
                                c.estado_contrato = 'EN GARANTIA' 
                                and C.tipo_contrato = :pTipoContrato 
                                and C.GRUPO = :pGrupo 
                                and C.CLASE = :pClase 
                                and com.region = :pRegion
                                and C.fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
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

        public List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionGrupoAdmin = new List<string>();

            try
            {
                var query = @"select distinct(C.CODIGO_CARPETA) from cto_contrato C
                                inner join cto_contrato_comuna COM on C.CODIGO_CARPETA = COM.CODIGO_CARPETA
                                where 
                                C.estado_contrato = :pEstadoContrato 
                                and c.tipo_contrato = :pTipoContrato 
                                and C.GRUPO = :pGrupo 
                                and COM.region = :pRegion";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoObrasRegionGrupoAdmin.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoObrasRegionGrupoAdmin;
        }

        public List<string> CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoObrasRegionGrupoAdmin = new List<string>();

            try
            {
                var query = @"select distinct(C.CODIGO_CARPETA) from cto_contrato C
                                inner join cto_contrato_comuna COM on C.CODIGO_CARPETA = COM.CODIGO_CARPETA
                                where 
                                C.ESTADO_CONTRATO = :pEstadoContrato 
                                and c.TIPO_CONTRATO = :pTipoContrato 
                                and C.CLASE = :pClase 
                                and C.GRUPO = :pGrupo 
                                and COM.REGION = :pRegion";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListadoObrasRegionGrupoAdmin.Add(dr["CODIGO_CARPETA"].ToString());
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

            return ListadoObrasRegionGrupoAdmin;
        }

        public List<string> CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminEntreFechas(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaEnGarantia = new List<string>();

            try
            {
                var query = @"select distinct(c.codigo_carpeta), c.grupo, com.region from cto_contrato c
                                inner join cto_contrato_comuna com on c.codigo_carpeta = com.codigo_carpeta
                                where 
                                c.estado_contrato = 'EN GARANTIA' 
                                and (c.tipo_contrato <> '00' and c.tipo_contrato <> '01') 
                                and (C.GRUPO = :pGrupo and com.region = :pRegion)
                                and c.fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));

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

        public List<string> CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminPorClaseEntreFechas(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> CodigosCarpetaEnGarantia = new List<string>();

            try
            {
                var query = @"select distinct(c.codigo_carpeta), c.grupo, com.region from cto_contrato c
                                inner join cto_contrato_comuna com on c.codigo_carpeta = com.codigo_carpeta
                                where 
                                c.ESTADO_CONTRATO = 'EN GARANTIA' 
                                and c.CLASE = :pClase 
                                and (c.tipo_contrato <> '00' and c.tipo_contrato <> '01') 
                                and (C.GRUPO = :pGrupo and com.region = :pRegion)
                                and c.fecha_real_termino BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));

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

        public List<string> CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoSoloObrasRegionalesAdmCentral = new List<string>();

            try
            {
                var query = @"select distinct(c.CODIGO_CARPETA) from cto_contrato c
                                inner join cto_contrato_comuna com on c.CODIGO_CARPETA = com.CODIGO_CARPETA
                                where 
                                c.estado_contrato = :pEstadoContrato 
                                and (c.tipo_contrato <> '00' and c.tipo_contrato <> '01') 
                                and (C.GRUPO = :pGrupo and com.region = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));

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

        public List<string> CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(SacFiltros filtroBasico)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<string> ListadoSoloObrasRegionalesAdmCentral = new List<string>();

            try
            {
                var query = @"select distinct(c.CODIGO_CARPETA) from cto_contrato c
                                inner join cto_contrato_comuna com on c.CODIGO_CARPETA = com.CODIGO_CARPETA
                                where 
                                c.ESTADO_CONTRATO = :pEstadoContrato 
                                and c.CLASE = :pClase 
                                and (c.TIPO_CONTRATO <> '00' and c.TIPO_CONTRATO <> '01') 
                                and (C.GRUPO = :pGrupo and com.REGION = :pRegion)";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));
                cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));

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

        public List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(SacFiltros filtroBasico)
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
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Grupo));
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

        public List<string> CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(SacFiltros filtroBasico)
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
                cmd.Parameters.Add(new OracleParameter(":pEstadoContrato", filtroBasico.EstadoContrato));
                cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Grupo));

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
