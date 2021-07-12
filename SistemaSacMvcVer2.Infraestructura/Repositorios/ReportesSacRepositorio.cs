using Oracle.ManagedDataAccess.Client;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac;
using System;

namespace SistemaSacMvcVer2.Infraestructura.Repositorios
{
    public class ReportesSacRepositorio : IReportesSacRepositorio
    {
        private readonly OracleConnection conexionDb;

        public ReportesSacRepositorio(OracleConnection pDbConexion)
        {
            conexionDb = pDbConexion;
        }

        public ReportesSac ObtenerReporteBasicoObrasPorCodigoCarpeta(string pCodigoCarpeta)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            ReportesSac objReportesSac = new ReportesSac();

            try
            {
                var query = @"select
                                (select descripcion from CTO_DOMINIO WHERE CTO_dominio.dominio='CTO_TIPO_CONTRATO' and CTO_dominio.id_item=CTO_contrato.TIPO_CONTRATO) as TIPO_CONTRATO
                                ,(select distinct(region) from CTO_contrato_comuna com where com.codigo_carpeta= cto_contrato.codigo_carpeta) as REGION
                                ,CODIGO_CHILECOMPRA
                                ,NOMBRE_CONTRATO
                                ,TIPO_CARPETA
                                ,CODIGO_SAFI
                                ,cto_contrato.codigo_carpeta as CODIGO_CARPETA
                                ,GRUPO
                                ,CLASE
                                ,(select nota_final from cto_contrato_calificacion where cto_contrato_calificacion.codigo_carpeta=cto_contrato.codigo_carpeta) as NOTA
                                ,ESTADO_CONTRATO
                                ,FECHA_INICIO
                                ,PRESUPUESTO_INICIAL
                                ,FECHA_TRAMITE
                                ,FECHA_REAL_TERMINO
                                ,(origen_resolucion ||' Nº'|| n_resolucion) as RESOLUCION
                                ,FECHA_RESOLUCION
                                ,FECHA_APERTURA_TECNICA
                                ,FECHA_APERTURA_ECONOMICA
                                ,AMBITO_CONTRATO
                                ,cto_contrato.codigo_carpeta as AVANCE_FISICO
                                ,cto_contrato.codigo_carpeta as AVANCE_FINANCIERO
                                ,(select CTO_visitador.profesion || ' ' || CTO_visitador.nombres || ' ' || CTO_visitador.apellidos from CTO_visitador where CTO_visitador.rut=CTO_contrato.rut_visitador) as VISITADOR
                                ,(select CTO_contratista.razon_social from CTO_contratista where CTO_contratista.rut=CTO_contrato.rut_contratista) as CONTRATISTA
                                ,(select CTO_residente.profesion || ' ' || CTO_residente.nombres || ' ' || CTO_residente.apellidos from CTO_residente where CTO_residente.rut=CTO_contrato.rut_residente) as RESIDENTE
                                ,(select CTO_inspectorfiscal.profesion || ' ' || CTO_inspectorfiscal.nombres || ' ' || CTO_inspectorfiscal.apellidos from CTO_inspectorfiscal where CTO_inspectorfiscal.rut=CTO_contrato.rut_if) as INSPECTOR_FISCAL
                                ,CODIGO_ASESORIA
                                ,(select descripcion from CTO_dominio where CTO_dominio.dominio='CTO_FINANCIAMIENTO' and CTO_dominio.id_item=CTO_contrato.financiamiento) as FINANCIAMIENTO
                                ,(select descripcion from CTO_dominio where CTO_dominio.dominio='CTO_LICITACION' and CTO_dominio.id_item=CTO_contrato.licitacion) as LICITACION
                                ,(select descripcion from CTO_dominio where CTO_dominio.dominio='CTO_REAJUSTE' and CTO_dominio.id_item=CTO_contrato.reajuste) as TIPOREAJUSTE
                                ,INDICE_BASE
                                ,PRESUPUESTO_OFICIAL
                                ,(select COALESCE(sum(VALOR_RESOLUCION),0) from CTO_contrato_modifica where CTO_contrato_modifica.codigo_carpeta=cto_contrato.codigo_carpeta and CTO_contrato_modifica.estado='TRAMITADA') as MONTO_MODIF_TRAMITADAS
                                ,((select COALESCE(sum(VALOR_RESOLUCION),0) from CTO_contrato_modifica where CTO_contrato_modifica.codigo_carpeta=cto_contrato.codigo_carpeta and CTO_contrato_modifica.estado='TRAMITADA') + presupuesto_inicial) as MONTO_ACTUAL
                                ,(select COALESCE(sum(monto),0) from cto_contrato_eepp where cto_contrato_eepp.codigo_carpeta=cto_contrato.codigo_carpeta and cto_contrato_eepp.tipo_eepp='EEPP' and (estado=1 or estado=3) and cto_contrato_eepp.fecha_eepp < to_date('20210322','YYYY-MM-DD') ) as PAGADO
                                ,(select COALESCE(sum(reajustes),0) from cto_contrato_eepp where cto_contrato_eepp.codigo_carpeta=cto_contrato.codigo_carpeta and cto_contrato_eepp.tipo_eepp='EEPP' and (estado=1 or estado=3) and cto_contrato_eepp.fecha_eepp < to_date('20210322','YYYY-MM-DD') ) as MONTO_REAJUSTES
                                ,PLAZO_ORIGINAL
                                ,(FECHA_INICIO + PLAZO_ORIGINAL) AS TERMINO_ORIGINAL
                                ,(fecha_inicio + (select COALESCE(sum(n_dias),0) from CTO_contrato_modifica where CTO_contrato_modifica.codigo_carpeta=cto_contrato.codigo_carpeta and CTO_contrato_modifica.estado='TRAMITADA') + plazo_original) as FECHA_TERMINO
                                ,(select COALESCE(SUM(N_DIAS),0)  from CTO_contrato_modifica where CTO_CONTRATO.codigo_carpeta=CTO_contrato_modifica.codigo_carpeta and CTO_contrato_modifica.origen_resolucion='PRE-APROBADO') as DIAS_PREAPROBADOS
                                ,(select COALESCE(sum(n_dias),0) from CTO_contrato_modifica where CTO_contrato_modifica.codigo_carpeta=cto_contrato.codigo_carpeta and CTO_contrato_modifica.estado='TRAMITADA') as MODIFICA_DIAS_TRAMITADOS
                                ,(select COALESCE(SUM(valor_resolucion),0)  from CTO_contrato_modifica where CTO_CONTRATO.codigo_carpeta=CTO_contrato_modifica.codigo_carpeta and CTO_contrato_modifica.origen_resolucion='PRE-APROBADO') as MOD_MONTO_PREAPROBADO
                                ,(select COALESCE(SUM(valor_resolucion),0)  from CTO_contrato_modifica where CTO_CONTRATO.codigo_carpeta=CTO_contrato_modifica.codigo_carpeta and CTO_contrato_modifica.origen_resolucion='NO APROBADO') as MOD_MONTO_NO_APROBADO
                                ,(select COALESCE(SUM(n_dias),0)  from CTO_contrato_modifica where CTO_CONTRATO.codigo_carpeta=CTO_contrato_modifica.codigo_carpeta and CTO_contrato_modifica.origen_resolucion='NO APROBADO') as MOD_DIAS_NO_APROBADO
                                from CTO_CONTRATO
                                where
                                cto_contrato.codigo_carpeta = :pCodigoCarpeta
                                ORDER BY FECHA_TRAMITE";

                cmd = new OracleCommand(query, conexionDb);
                cmd.Parameters.Add(new OracleParameter(":pCodigoCarpeta", pCodigoCarpeta));
                conexionDb.Open();

                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objReportesSac.EstadoContrato = dr["ESTADO_CONTRATO"].ToString();
                        objReportesSac.Region = dr["REGION"].ToString();
                        objReportesSac.Grupo = dr["GRUPO"].ToString();
                        objReportesSac.Clase = dr["CLASE"].ToString();
                        objReportesSac.CodigoCarpeta = dr["CODIGO_CARPETA"].ToString();
                        objReportesSac.CodigoSafi = dr["CODIGO_SAFI"].ToString();
                        objReportesSac.Administracion = dr["CLASE"].ToString();
                        objReportesSac.NombreContrato = dr["NOMBRE_CONTRATO"].ToString();
                        objReportesSac.Resolucion = dr["RESOLUCION"].ToString();
                        objReportesSac.FechaResolucion = dr["FECHA_RESOLUCION"].ToString();
                        objReportesSac.FechaTramite = dr["FECHA_TRAMITE"].ToString();
                        objReportesSac.FechaAperturaEconomica = dr["FECHA_APERTURA_ECONOMICA"].ToString();
                        objReportesSac.FechaAperturaTecnica = dr["FECHA_APERTURA_TECNICA"].ToString();
                        objReportesSac.Contratista = dr["CONTRATISTA"].ToString();
                        objReportesSac.Residente = dr["RESIDENTE"].ToString();
                        objReportesSac.InspectorFiscal = dr["INSPECTOR_FISCAL"].ToString();
                        objReportesSac.Visitador = dr["VISITADOR"].ToString();
                        objReportesSac.CodigoAsesoria = dr["CODIGO_ASESORIA"].ToString();
                        objReportesSac.Financiamiento = dr["FINANCIAMIENTO"].ToString();
                        objReportesSac.Licitacion = dr["LICITACION"].ToString();
                        objReportesSac.TipoReajuste = dr["TIPOREAJUSTE"].ToString();
                        objReportesSac.IndiceBase = dr["INDICE_BASE"].ToString();
                        objReportesSac.PresupuestoOficial = dr["PRESUPUESTO_OFICIAL"].ToString();
                        objReportesSac.PresupuestoInicial = dr["PRESUPUESTO_INICIAL"].ToString();
                        objReportesSac.MontoModificatoriasTramitadas = dr["MONTO_MODIF_TRAMITADAS"].ToString();
                        objReportesSac.MontoActual = dr["MONTO_ACTUAL"].ToString();
                        objReportesSac.Pagado = dr["PAGADO"].ToString();
                        objReportesSac.MontoReajustes = dr["MONTO_REAJUSTES"].ToString();
                        objReportesSac.FechaInicio = dr["FECHA_INICIO"].ToString().ToString();
                        objReportesSac.PlazoOriginal = dr["PLAZO_ORIGINAL"].ToString();
                        objReportesSac.FechaTerminoOriginal = dr["TERMINO_ORIGINAL"].ToString().ToString();
                        objReportesSac.ModificaDiasTramitados = dr["MODIFICA_DIAS_TRAMITADOS"].ToString().ToString();
                        objReportesSac.FechaTerminoLegal = dr["FECHA_TERMINO"].ToString().ToString();
                        objReportesSac.FechaRealTermino = dr["FECHA_REAL_TERMINO"].ToString().ToString();
                        objReportesSac.ModificaDiasPreAprobado = dr["DIAS_PREAPROBADOS"].ToString().ToString();
                        objReportesSac.ModificaMontoPreAprobado = dr["MOD_MONTO_PREAPROBADO"].ToString().ToString();
                        objReportesSac.ModificaDiasNoAprobado = dr["MOD_DIAS_NO_APROBADO"].ToString().ToString();
                        objReportesSac.ModificaMontoNoAprobado = dr["MOD_MONTO_NO_APROBADO"].ToString().ToString();
                        objReportesSac.AmbitoContrato = dr["AMBITO_CONTRATO"].ToString().ToString();
                        objReportesSac.TipoCarpeta = dr["TIPO_CARPETA"].ToString().ToString();
                        objReportesSac.TipoContrato = dr["TIPO_CONTRATO"].ToString().ToString();
                        objReportesSac.CodigoChileCompra = dr["CODIGO_CHILECOMPRA"].ToString().ToString();
                        objReportesSac.Nota = dr["NOTA"].ToString().ToString();
                        objReportesSac.AvanceFisico = dr["AVANCE_FISICO"].ToString().ToString();
                        objReportesSac.AvanceFinanciero = dr["AVANCE_FINANCIERO"].ToString().ToString();
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

            return objReportesSac;
        }
    }
}
