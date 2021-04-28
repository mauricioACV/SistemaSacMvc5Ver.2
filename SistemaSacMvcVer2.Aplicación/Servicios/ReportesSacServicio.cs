using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
using SistemaSacMvcVer2.Dominio.Entidades;
using SistemaSacMvcVer2.Dominio.Interfaces;
using SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac;
using System.Collections.Generic;

namespace SistemaSacMvcVer2.Aplicación.Servicios
{

    public class ReportesSacServicio : IReportesSacServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportesSacServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasPorGrupoPorEstado(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBacisoObrasPorGrupoPorEstado = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetaGarantiaPorFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoEntreFechas(filtroReporteBasico);

                foreach (var codigoCarpeta in CodCarpetaGarantiaPorFechas)
                {
                    ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetaLiquidadoPorFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoEntreFechas(filtroReporteBasico);

                foreach (var codigoCarpeta in CodCarpetaLiquidadoPorFechas)
                {
                    ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else
            {
                List<string> ListCodCarpeta = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorGrupoPorEstado(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpeta)
                {
                    ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoEntreFechas(filtroReporteBasico);

                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoEntreFechas(filtroReporteBasico);

                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                else
                {
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoContrato(filtroReporteBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }

            }
            return ListadoBacisoObrasPorGrupoPorEstado;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoPorGrupoSoloObras(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBasicoObrasEstadoGrupoSoloObras = new List<ReportesSac>();


            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasObrasFechas = new List<string>();
                CodCarpetasObrasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasObrasFechas)
                {
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    List<string> CodCarpetasObrasCentralFechas = new List<string>();
                    CodCarpetasObrasCentralFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasObrasCentralFechas)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasObrasFechas = new List<string>();
                CodCarpetasObrasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasObrasFechas)
                {
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    List<string> CodCarpetasObrasCentralFechas = new List<string>();
                    CodCarpetasObrasCentralFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasObrasCentralFechas)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else
            {
                List<string> CodCarpetas = new List<string>();
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroReporteBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
            }




            return ListadoBasicoObrasEstadoGrupoSoloObras;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasFechas = new List<string>();
                CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasFechas)
                {
                    ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasFechas)
                    {
                        ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasFechas = new List<string>();
                CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasFechas)
                {
                    ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasFechas)
                    {
                        ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else
            {
                List<string> CodCarpetas = new List<string>();

                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
            }


            return ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasEnEjecucionMasTerminados(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoObrasEnEjecucionTerminados = new List<ReportesSac>();

            List<ReportesSac> ListadoObrasEnEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasTerminados = new List<ReportesSac>();

            List<ReportesSac> ListadoObrasRegionAdmCentralEnEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasRegionAdmCentralTerminados = new List<ReportesSac>();

            #region "Obtener En Ejecucion"

            filtroReporteBasico.EstadoContrato = "EN EJECUCION";

            if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
            {
                List<string> CodCarpetas = new List<string>();
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            if (filtroReporteBasico.TipoContrato == "OBRAS")
            {
                List<string> CodCarpetas = new List<string>();
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            if(filtroReporteBasico.TipoContrato == "TODOS")
            {
                List<string> CodCarpetas = new List<string>();
                //Asesorias
                filtroReporteBasico.TipoContrato = "00";
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                //Estudios
                filtroReporteBasico.TipoContrato = "01";
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                //Obras
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                filtroReporteBasico.TipoContrato = "TODOS";
            }

            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                {
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico));
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroReporteBasico));
                }
                if (filtroReporteBasico.TipoContrato == "TODOS")
                {
                    //Asesorias
                    filtroReporteBasico.TipoContrato = "00";
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico));
                    //Estudios
                    filtroReporteBasico.TipoContrato = "01";
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico));
                    //Obras
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroReporteBasico));
                    filtroReporteBasico.TipoContrato = "TODOS";
                }

                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoObrasRegionAdmCentralEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            #endregion

            #region "Obtener En Garantía"

            filtroReporteBasico.EstadoContrato = "EN GARANTIA";

            if (filtroReporteBasico.RangoFecha)
            {
                List<string> CodCarpetasGarantiaFechas = new List<string>();

                if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                {
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);

                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);

                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "TODOS")
                {
                    filtroReporteBasico.TipoContrato = "00";
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }

                    filtroReporteBasico.TipoContrato = "01";
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                                       
                    filtroReporteBasico.TipoContrato = "TODOS";
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }

                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";

                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                    if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                    {
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                    }
                    if (filtroReporteBasico.TipoContrato == "OBRAS")
                    {
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                    }
                    if (filtroReporteBasico.TipoContrato == "TODOS")
                    {
                        filtroReporteBasico.TipoContrato = "00";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                        filtroReporteBasico.TipoContrato = "01";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                        filtroReporteBasico.TipoContrato = "TODOS";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                    }

                }

            }
            else
            {
                if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                {
                    List<string> CodCarpetas = new List<string>();
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    List<string> CodCarpetas = new List<string>();
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "TODOS")
                {
                    List<string> CodCarpetas = new List<string>();
                    //Asesorias
                    filtroReporteBasico.TipoContrato = "00";
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Estudios
                    filtroReporteBasico.TipoContrato = "01";
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Obras
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    filtroReporteBasico.TipoContrato = "TODOS";
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                    if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                    {
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico));
                    }
                    if (filtroReporteBasico.TipoContrato == "OBRAS")
                    {
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroReporteBasico));
                    }
                    if (filtroReporteBasico.TipoContrato == "TODOS")
                    {
                        filtroReporteBasico.TipoContrato = "00";
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico));
                        filtroReporteBasico.TipoContrato = "01";
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico));
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroReporteBasico));
                        filtroReporteBasico.TipoContrato = "TODOS";
                    }

                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
            }

            #endregion

            ListadoObrasEnEjecucionTerminados.AddRange(ListadoObrasEnEjecucion);
            ListadoObrasEnEjecucionTerminados.AddRange(ListadoObrasTerminados);
            ListadoObrasEnEjecucionTerminados.AddRange(ListadoObrasRegionAdmCentralEnEjecucion);
            ListadoObrasEnEjecucionTerminados.AddRange(ListadoObrasRegionAdmCentralTerminados);


            return ListadoObrasEnEjecucionTerminados;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasEnEjecucionMasTerminadosTodoTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoObrasEjecucionTerminadosTodoTipoContrato = new List<ReportesSac>();

            List<ReportesSac> ListadoAsesoriasEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoAsesoriasEjecucionAdmCentral = new List<ReportesSac>();
            List<ReportesSac> ListadoEstudiosEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoEstudiosEjecucionAdmCentral = new List<ReportesSac>();
            List<ReportesSac> ListadoSoloObrasEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoSoloObrasEjecucionAdmCentral = new List<ReportesSac>();

            List<ReportesSac> ListadoAsesoriasTerminados = new List<ReportesSac>();
            List<ReportesSac> ListadoAsesoriasTerminadosAdmCentral = new List<ReportesSac>();
            List<ReportesSac> ListadoEstudiosTerminados = new List<ReportesSac>();
            List<ReportesSac> ListadoEstudiosTerminadosAdmCentral = new List<ReportesSac>();
            List<ReportesSac> ListadoSoloObrasTerminados = new List<ReportesSac>();
            List<ReportesSac> ListadoSoloObrasTerminadosAdmCentral = new List<ReportesSac>();

            filtroReporteBasico.EstadoContrato = "EN EJECUCION";
            filtroReporteBasico.TipoContrato = "00";

            List<string> CodCarpetas = new List<string>();

            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoAsesoriasEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoAsesoriasEjecucionAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            filtroReporteBasico.EstadoContrato = "EN EJECUCION";
            filtroReporteBasico.TipoContrato = "01";

            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoEstudiosEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoEstudiosEjecucionAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            //Obras
            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoSoloObrasEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoSoloObrasEjecucionAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            filtroReporteBasico.EstadoContrato = "EN GARANTIA";
            filtroReporteBasico.TipoContrato = "00";

            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoAsesoriasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoAsesoriasTerminadosAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }


            filtroReporteBasico.EstadoContrato = "EN GARANTIA";
            filtroReporteBasico.TipoContrato = "01";

            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoEstudiosTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoEstudiosTerminadosAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            //Obras
            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoSoloObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoSoloObrasTerminadosAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoAsesoriasEjecucion);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoEstudiosEjecucion);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoSoloObrasEjecucion);

            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoAsesoriasTerminados);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoEstudiosTerminados);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoSoloObrasTerminados);

            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoAsesoriasEjecucionAdmCentral);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoEstudiosEjecucionAdmCentral);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoSoloObrasEjecucionAdmCentral);

            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoAsesoriasTerminadosAdmCentral);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoEstudiosTerminadosAdmCentral);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoSoloObrasTerminadosAdmCentral);


            return ListadoObrasEjecucionTerminadosTodoTipoContrato;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoObrasRegionPorGrupoAdmin = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin = new List<string>();
                CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminEnGarantiaEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin = new List<string>();
                CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

            }
            else
            {
                List<string> CodCarpetaObrasRegionPorGrupoAdmin = new List<string>();
                CodCarpetaObrasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContrato(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetaObrasRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }

            return ListadoObrasRegionPorGrupoAdmin;

        }

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionGrupoAdminPorTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBasicoObrasRegionPorGrupoAdmin = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasEnGarantiaRegionPorGrupoAdminFechas = new List<string>();
                CodCarpetasEnGarantiaRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasEnGarantiaRegionPorGrupoAdminFechas)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasLiquidadosRegionPorGrupoAdminFechas = new List<string>();
                CodCarpetasLiquidadosRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasLiquidadosRegionPorGrupoAdminFechas)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else
            {
                List<string> CodCarpetasRegionPorGrupoAdmin = new List<string>();
                CodCarpetasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasRegionPorGrupoAdmin)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }

            return ListadoBasicoObrasRegionPorGrupoAdmin;
        }

    }
}
