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
            List<ReportesSac> ListadoBacisoObras = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetaGarantiaPorFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoEntreFechas(filtroReporteBasico);

                foreach (var codigoCarpeta in CodCarpetaGarantiaPorFechas)
                {
                    ListadoBacisoObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetaLiquidadoPorFechas = _unitOfWork.CtoContratoModificaRepositorio.ObtenerCodigosCarpetaLiquidadosPorGrupoEntreFechas(filtroReporteBasico);

                foreach (var codigoCarpeta in CodCarpetaLiquidadoPorFechas)
                {
                    ListadoBacisoObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else
            {
                List<string> ListCodCarpeta = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorGrupoPorEstado(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpeta)
                {
                    ListadoBacisoObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
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
                        ListadoBacisoObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoModificaRepositorio.ObtenerCodigosCarpetaLiquidadosPorGrupoEntreFechas(filtroReporteBasico);

                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                else
                {
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoContratoGrupo(filtroReporteBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }

            }
            return ListadoBacisoObras;
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
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    List<string> CodCarpetasObrasCentralFechas = new List<string>();
                    CodCarpetasObrasCentralFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasObrasCentralFechas)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasObrasFechas = new List<string>();
                CodCarpetasObrasFechas = _unitOfWork.CtoContratoModificaRepositorio.ObtenerCodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasObrasFechas)
                {
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    List<string> CodCarpetasObrasCentralFechas = new List<string>();
                    CodCarpetasObrasCentralFechas = _unitOfWork.CtoContratoModificaRepositorio.ObtenerCodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasObrasCentralFechas)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else
            {
                List<string> CodCarpetas = new List<string>();
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoSoloObras(filtroReporteBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
            }




            return ListadoBasicoObrasEstadoGrupoSoloObras;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBacisoObrasEstadoGrupoTipoContrato = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasFechas = new List<string>();
                CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasFechas)
                {
                    ListadoBacisoObrasEstadoGrupoTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasFechas)
                    {
                        ListadoBacisoObrasEstadoGrupoTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasFechas = new List<string>();
                CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.ObtenerCodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                foreach (var codCarpeta in CodCarpetasFechas)
                {
                    ListadoBacisoObrasEstadoGrupoTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    filtroReporteBasico.Grupo = "CENTRAL";
                    CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.ObtenerCodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasFechas)
                    {
                        ListadoBacisoObrasEstadoGrupoTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else
            {
                List<string> CodCarpetas = new List<string>();

                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoBacisoObrasEstadoGrupoTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObrasEstadoGrupoTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
            }


            return ListadoBacisoObrasEstadoGrupoTipoContrato;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasEnEjecucionTerminados(ReportesSacFiltros filtroReporteBasico)
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
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            if (filtroReporteBasico.TipoContrato == "OBRAS")
            {
                List<string> CodCarpetas = new List<string>();
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
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
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                //Estudios
                filtroReporteBasico.TipoContrato = "01";
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                //Obras
                CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                filtroReporteBasico.TipoContrato = "TODOS";
            }

            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                {
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico));
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoSoloObras(filtroReporteBasico));
                }
                if (filtroReporteBasico.TipoContrato == "TODOS")
                {
                    //Asesorias
                    filtroReporteBasico.TipoContrato = "00";
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico));
                    //Estudios
                    filtroReporteBasico.TipoContrato = "01";
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico));
                    //Obras
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoSoloObras(filtroReporteBasico));
                    filtroReporteBasico.TipoContrato = "TODOS";
                }

                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoObrasRegionAdmCentralEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
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
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);

                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "TODOS")
                {
                    filtroReporteBasico.TipoContrato = "00";
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }

                    filtroReporteBasico.TipoContrato = "01";
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                                       
                    filtroReporteBasico.TipoContrato = "TODOS";
                    CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
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
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                    }
                    if (filtroReporteBasico.TipoContrato == "OBRAS")
                    {
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                    }
                    if (filtroReporteBasico.TipoContrato == "TODOS")
                    {
                        filtroReporteBasico.TipoContrato = "00";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                        filtroReporteBasico.TipoContrato = "01";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                        filtroReporteBasico.TipoContrato = "TODOS";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codCarpeta));
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
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    List<string> CodCarpetas = new List<string>();
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
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
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Estudios
                    filtroReporteBasico.TipoContrato = "01";
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Obras
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    filtroReporteBasico.TipoContrato = "TODOS";
                }
                if (filtroReporteBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                    if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                    {
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico));
                    }
                    if (filtroReporteBasico.TipoContrato == "OBRAS")
                    {
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoSoloObras(filtroReporteBasico));
                    }
                    if (filtroReporteBasico.TipoContrato == "TODOS")
                    {
                        filtroReporteBasico.TipoContrato = "00";
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico));
                        filtroReporteBasico.TipoContrato = "01";
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico));
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoSoloObras(filtroReporteBasico));
                        filtroReporteBasico.TipoContrato = "TODOS";
                    }

                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
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

        public List<ReportesSac> ObtenerListadoBasicoObrasEnEjecucionTerminadosTodoTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoObrasEjecucionTerminadosTodoTipoContrato = new List<ReportesSac>();

            List<ReportesSac> ListadoAsesoriasEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoAsesoriasEjecucionAdmCentral = new List<ReportesSac>();
            List<ReportesSac> ListadoEstudiosEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoEstudiosEjecucionAdmCentral = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasEjecucionAdmCentral = new List<ReportesSac>();

            List<ReportesSac> ListadoAsesoriasTerminados = new List<ReportesSac>();
            List<ReportesSac> ListadoAsesoriasTerminadosAdmCentral = new List<ReportesSac>();
            List<ReportesSac> ListadoEstudiosTerminados = new List<ReportesSac>();
            List<ReportesSac> ListadoEstudiosTerminadosAdmCentral = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasTerminados = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasTerminadosAdmCentral = new List<ReportesSac>();

            filtroReporteBasico.EstadoContrato = "EN EJECUCION";
            filtroReporteBasico.TipoContrato = "00";

            List<string> CodCarpetas = new List<string>();

            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoAsesoriasEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoAsesoriasEjecucionAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            filtroReporteBasico.EstadoContrato = "EN EJECUCION";
            filtroReporteBasico.TipoContrato = "01";

            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoEstudiosEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoEstudiosEjecucionAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            //Obras
            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoObrasEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoObrasEjecucionAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            filtroReporteBasico.EstadoContrato = "EN GARANTIA";
            filtroReporteBasico.TipoContrato = "00";

            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoAsesoriasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoAsesoriasTerminadosAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }


            filtroReporteBasico.EstadoContrato = "EN GARANTIA";
            filtroReporteBasico.TipoContrato = "01";

            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoEstudiosTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoEstudiosTerminadosAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            //Obras
            CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
            foreach (var codigoCarpeta in CodCarpetas)
            {
                ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
            }
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoObrasTerminadosAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoAsesoriasEjecucion);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoEstudiosEjecucion);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoObrasEjecucion);

            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoAsesoriasTerminados);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoEstudiosTerminados);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoObrasTerminados);

            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoAsesoriasEjecucionAdmCentral);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoEstudiosEjecucionAdmCentral);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoObrasEjecucionAdmCentral);

            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoAsesoriasTerminadosAdmCentral);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoEstudiosTerminadosAdmCentral);
            ListadoObrasEjecucionTerminadosTodoTipoContrato.AddRange(ListadoObrasTerminadosAdmCentral);


            return ListadoObrasEjecucionTerminadosTodoTipoContrato;
        }

    }
}
