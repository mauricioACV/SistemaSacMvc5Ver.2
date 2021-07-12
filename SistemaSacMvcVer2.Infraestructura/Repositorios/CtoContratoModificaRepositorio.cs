using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Common.Models;
using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContratoModifica;
using System;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class CtoContratoModificaRepositorio : ICtoContratoModificaRepositorio
    {
        private readonly OracleConnection conexionDb;

        public CtoContratoModificaRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public List<string> CodigosCarpetaLiquidadosPorGrupoEntreFechas(SacFiltros filtroBasico)
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

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));

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

        public List<string> CodigosCarpetaLiquidadosPorGrupoPorClaseEntreFechas(SacFiltros filtroBasico)
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
                                AND M.TIPO = 'LIQUIDADO'
                                AND M.FECHA_TRAMITE BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')
                                AND C.GRUPO = :pGrupo
                                AND C.CLASE = :pClase";

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Clase));

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

        public List<string> CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(SacFiltros filtroBasico)
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
                                AND
                                C.TIPO_CONTRATO = :pTipoContrato";

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));

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

        public List<string> CodigosCarpetaLiquidadosPorGrupoPorTipoContratoPorClaseEntreFechas(SacFiltros filtroBasico)
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
                                C.CLASE = :pClase
                                AND
                                c.estado_contrato = 'LIQUIDADO'
                                AND
                                C.TIPO_CONTRATO = :pTipoContrato";

                using (cmd = new OracleCommand(query, conexionDb))
                {
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

        public List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminEntreFechas(SacFiltros filtroBasico)
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

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));

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

        public List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminPorClaseEntreFechas(SacFiltros filtroBasico)
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
                                and C.CLASE = :pClase 
                                and com.region = :pRegion 
                                and m.tipo = 'LIQUIDADO' 
                                and m.fecha_tramite BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                using (cmd = new OracleCommand(query, conexionDb))
                {
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

        public List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoEntreFechas(SacFiltros filtroBasico)
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

        public List<string> CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoPorClaseEntreFechas(SacFiltros filtroBasico)
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
                                and C.CLASE = :pClase 
                                and C.GRUPO = :pGrupo 
                                and com.region = :pRegion 
                                and m.tipo = 'LIQUIDADO' 
                                and m.fecha_tramite BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pTipoContrato", filtroBasico.TipoContrato));
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

        public List<string> CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminEntreFechas(SacFiltros filtroBasico)
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

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pRegion", filtroBasico.Region));
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));

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

        public List<string> CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminPorClaseEntreFechas(SacFiltros filtroBasico)
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
                                and C.CLASE = :pClase
                                and (c.tipo_contrato <> '00' and c.tipo_contrato <> '01') 
                                and com.region = :pRegion
                                and m.tipo = 'LIQUIDADO'
                                and m.fecha_tramite BETWEEN to_date(:pFechaInicio,'DD-MM-YYYY') AND to_date(:pFechaTermino,'DD-MM-YYYY')";

                using (cmd = new OracleCommand(query, conexionDb))
                {
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

        public List<string> CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(SacFiltros filtroBasico)
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
                                AND
                                C.TIPO_CONTRATO <> '01'
                                AND
                                C.TIPO_CONTRATO <> '00'";

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));

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

        public List<string> CodigosCarpetaLiquidadosPorGrupoPorClaseSoloObrasEntreFechas(SacFiltros filtroBasico)
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
                                AND
                                C.CLASE = :pClase
                                AND
                                C.TIPO_CONTRATO <> '01'
                                AND
                                C.TIPO_CONTRATO <> '00'";

                using (cmd = new OracleCommand(query, conexionDb))
                {
                    cmd.Parameters.Add(new OracleParameter(":pFechaInicio", filtroBasico.FechaDesde));
                    cmd.Parameters.Add(new OracleParameter(":pFechaTermino", filtroBasico.FechaHasta));
                    cmd.Parameters.Add(new OracleParameter(":pGrupo", filtroBasico.Grupo));
                    cmd.Parameters.Add(new OracleParameter(":pClase", filtroBasico.Clase));

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
