using SistemaSacMvcVer2.Dominio.Common.Models;
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

        public List<ReportesSac> ObtenerListadoBasicoObrasPorGrupoPorEstado(SacFiltros filtroBasico)
        {
            List<ReportesSac> ListadoBacisoObrasPorGrupoPorEstado = new List<ReportesSac>();

            if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetaGarantiaPorFechas = new List<string>();

                if (filtroBasico.Clase == null)
                {
                    CodCarpetaGarantiaPorFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetaGarantiaPorFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetaGarantiaPorFechas)
                {
                    ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetaLiquidadoPorFechas = new List<string>();

                if (filtroBasico.Clase == null)
                {
                    CodCarpetaLiquidadoPorFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetaLiquidadoPorFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetaLiquidadoPorFechas)
                {
                    ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else
            {
                List<string> ListCodCarpeta = new List<string>();

                if (filtroBasico.Clase == null)
                {
                    ListCodCarpeta = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorGrupoPorEstado(filtroBasico);
                }
                else
                {
                    ListCodCarpeta = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorGrupoPorEstadoPorClase(filtroBasico);
                }
                foreach (var codigoCarpeta in ListCodCarpeta)
                {
                    ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            if (filtroBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "EN GARANTIA")
                {
                    filtroBasico.Grupo = "CENTRAL";
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoEntreFechas(filtroBasico);

                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                else if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "LIQUIDADO")
                {
                    filtroBasico.Grupo = "CENTRAL";
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoEntreFechas(filtroBasico);

                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                else
                {
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoContrato(filtroBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }

            }
            return ListadoBacisoObrasPorGrupoPorEstado;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoPorGrupoSoloObras(SacFiltros filtroBasico)
        {
            List<ReportesSac> ListadoBasicoObrasEstadoGrupoSoloObras = new List<ReportesSac>();


            if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasObrasFechas = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetasObrasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetasObrasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasObrasFechas)
                {
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

                if (filtroBasico.IncluirCentral)
                {
                    filtroBasico.Grupo = "CENTRAL";
                    List<string> CodCarpetasObrasCentralFechas = new List<string>();
                    CodCarpetasObrasCentralFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroBasico);
                    foreach (var codCarpeta in CodCarpetasObrasCentralFechas)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasObrasFechas = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetasObrasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetasObrasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorClaseSoloObrasEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasObrasFechas)
                {
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

                if (filtroBasico.IncluirCentral)
                {
                    filtroBasico.Grupo = "CENTRAL";
                    List<string> CodCarpetasObrasCentralFechas = new List<string>();
                    CodCarpetasObrasCentralFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(filtroBasico);
                    foreach (var codCarpeta in CodCarpetasObrasCentralFechas)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else
            {
                List<string> CodCarpetas = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                if (filtroBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBasicoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
            }
            return ListadoBasicoObrasEstadoGrupoSoloObras;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato(SacFiltros filtroBasico)
        {
            List<ReportesSac> ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato = new List<ReportesSac>();

            if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasFechas = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasFechas)
                {
                    ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                if (filtroBasico.IncluirCentral)
                {
                    filtroBasico.Grupo = "CENTRAL";
                    CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                    foreach (var codCarpeta in CodCarpetasFechas)
                    {
                        ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasFechas = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorTipoContratoPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasFechas)
                {
                    ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                if (filtroBasico.IncluirCentral)
                {
                    filtroBasico.Grupo = "CENTRAL";
                    CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                    foreach (var codCarpeta in CodCarpetasFechas)
                    {
                        ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else
            {
                List<string> CodCarpetas = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                if (filtroBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                    ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroBasico);
                    foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                    {
                        ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
            }


            return ListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasEnEjecucionMasTerminados(SacFiltros filtroBasico)
        {
            List<ReportesSac> ListadoObrasEnEjecucionTerminados = new List<ReportesSac>();

            List<ReportesSac> ListadoObrasEnEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasTerminados = new List<ReportesSac>();

            List<ReportesSac> ListadoObrasRegionAdmCentralEnEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasRegionAdmCentralTerminados = new List<ReportesSac>();

            #region "Obtener En Ejecucion"

            filtroBasico.EstadoContrato = "EN EJECUCION";

            if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
            {
                List<string> CodCarpetas = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            if (filtroBasico.TipoContrato == "OBRAS")
            {
                List<string> CodCarpetas = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            if(filtroBasico.TipoContrato == "TODOS")
            {
                List<string> CodCarpetas = new List<string>();
                //Asesorias
                filtroBasico.TipoContrato = "00";
                if (filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                //Estudios
                filtroBasico.TipoContrato = "01";
                if (filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                //Obras
                if(filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                filtroBasico.TipoContrato = "TODOS";
            }

            if (filtroBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
                {
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroBasico));
                }
                if (filtroBasico.TipoContrato == "OBRAS")
                {
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroBasico));
                }
                if (filtroBasico.TipoContrato == "TODOS")
                {
                    //Asesorias
                    filtroBasico.TipoContrato = "00";
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroBasico));
                    //Estudios
                    filtroBasico.TipoContrato = "01";
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroBasico));
                    //Obras
                    ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroBasico));
                    filtroBasico.TipoContrato = "TODOS";
                }

                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoObrasRegionAdmCentralEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            #endregion

            #region "Obtener En Garantía"

            filtroBasico.EstadoContrato = "EN GARANTIA";

            if (filtroBasico.RangoFecha)
            {
                List<string> CodCarpetasGarantiaFechas = new List<string>();

                if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
                {
                    if(filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroBasico.TipoContrato == "OBRAS")
                {
                    if(filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroBasico.TipoContrato == "TODOS")
                {
                    filtroBasico.TipoContrato = "00";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }

                    filtroBasico.TipoContrato = "01";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                                       
                    filtroBasico.TipoContrato = "TODOS";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }

                if (filtroBasico.IncluirCentral)
                {
                    filtroBasico.Grupo = "CENTRAL";

                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                    if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
                    {
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                    }
                    if (filtroBasico.TipoContrato == "OBRAS")
                    {
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                    }
                    if (filtroBasico.TipoContrato == "TODOS")
                    {
                        filtroBasico.TipoContrato = "00";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                        filtroBasico.TipoContrato = "01";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                        filtroBasico.TipoContrato = "TODOS";
                        ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroBasico);
                        foreach (var codCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                        {
                            ListadoObrasRegionAdmCentralTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                        }
                    }

                }

            }
            else
            {
                if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
                {
                    List<string> CodCarpetas = new List<string>();
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroBasico.TipoContrato == "OBRAS")
                {
                    List<string> CodCarpetas = new List<string>();
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroBasico.TipoContrato == "TODOS")
                {
                    List<string> CodCarpetas = new List<string>();
                    //Asesorias
                    filtroBasico.TipoContrato = "00";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Estudios
                    filtroBasico.TipoContrato = "01";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Obras
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    filtroBasico.TipoContrato = "TODOS";
                }
                if (filtroBasico.IncluirCentral)
                {
                    List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();

                    if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
                    {
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroBasico));
                    }
                    if (filtroBasico.TipoContrato == "OBRAS")
                    {
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroBasico));
                    }
                    if (filtroBasico.TipoContrato == "TODOS")
                    {
                        filtroBasico.TipoContrato = "00";
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroBasico));
                        filtroBasico.TipoContrato = "01";
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoTipoContrato(filtroBasico));
                        ListCodCarpetaObrasRegionAdmCentral.AddRange(_unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionAdminCentralPorEstadoSoloObras(filtroBasico));
                        filtroBasico.TipoContrato = "TODOS";
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

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoContrato(SacFiltros filtroBasico)
        {
            List<ReportesSac> ListadoObrasRegionPorGrupoAdmin = new List<ReportesSac>();

            if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminEnGarantiaEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorClaseEnGarantiaEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else
            {
                List<string> CodCarpetaObrasRegionPorGrupoAdmin = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetaObrasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetaObrasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorClase(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetaObrasRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            return ListadoObrasRegionPorGrupoAdmin;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorTipoContrato(SacFiltros filtroBasico)
        {
            List<ReportesSac> ListadoBasicoObrasRegionPorGrupoAdmin = new List<ReportesSac>();

            if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasEnGarantiaRegionPorGrupoAdminFechas = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetasEnGarantiaRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetasEnGarantiaRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasEnGarantiaRegionPorGrupoAdminFechas)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasLiquidadosRegionPorGrupoAdminFechas = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetasLiquidadosRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetasLiquidadosRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasLiquidadosRegionPorGrupoAdminFechas)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else
            {
                List<string> CodCarpetasRegionPorGrupoAdmin = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasRegionPorGrupoAdmin)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            return ListadoBasicoObrasRegionPorGrupoAdmin;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoSoloObras(SacFiltros filtroBasico)
        {
            List<ReportesSac> ListadoBasicoObrasRegionGrupoAdminSoloObras = new List<ReportesSac>();

            if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasObrasRegionGrupoAdminGarantiaFechas = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetasObrasRegionGrupoAdminGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetasObrasRegionGrupoAdminGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasObrasRegionGrupoAdminGarantiaFechas)
                {
                    ListadoBasicoObrasRegionGrupoAdminSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

            }
            else if (filtroBasico.RangoFecha && filtroBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasObrasRegionGrupoAdminLiquidadoFechas = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetasObrasRegionGrupoAdminLiquidadoFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminEntreFechas(filtroBasico);
                }
                else
                {
                    CodCarpetasObrasRegionGrupoAdminLiquidadoFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminPorClaseEntreFechas(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasObrasRegionGrupoAdminLiquidadoFechas)
                {
                    ListadoBasicoObrasRegionGrupoAdminSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

            }
            else
            {
                List<string> CodCarpetasSoloObrasRegionGrupoAdmin = new List<string>();
                if(filtroBasico.Clase == null)
                {
                    CodCarpetasSoloObrasRegionGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroBasico);
                }
                else
                {
                    CodCarpetasSoloObrasRegionGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetasSoloObrasRegionGrupoAdmin)
                {
                    ListadoBasicoObrasRegionGrupoAdminSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            return ListadoBasicoObrasRegionGrupoAdminSoloObras;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminEjEjecucionMasTerminados(SacFiltros filtroBasico)
        {
            List<ReportesSac> ListadoObrasEnEjecucionMasTerminados = new List<ReportesSac>();

            List<ReportesSac> ListadoObrasEnEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasTerminados = new List<ReportesSac>();

            #region "Obtener En Ejecucion"

            filtroBasico.EstadoContrato = "EN EJECUCION";

            if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
            {
                List<string> CodCarpetas = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            if (filtroBasico.TipoContrato == "OBRAS")
            {
                List<string> CodCarpetas = new List<string>();
                if (filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            if (filtroBasico.TipoContrato == "TODOS")
            {
                List<string> CodCarpetas = new List<string>();
                //Asesorias
                filtroBasico.TipoContrato = "00";
                if (filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                //Estudios
                filtroBasico.TipoContrato = "01";
                if (filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                //Obras
                if (filtroBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                filtroBasico.TipoContrato = "TODOS";
            }
            #endregion

            #region "Obtener En Garantía"

            filtroBasico.EstadoContrato = "EN GARANTIA";

            if (filtroBasico.RangoFecha)
            {
                List<string> CodCarpetasGarantiaFechas = new List<string>();

                if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
                {
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroBasico.TipoContrato == "OBRAS")
                {
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminPorClaseEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroBasico.TipoContrato == "TODOS")
                {
                    filtroBasico.TipoContrato = "00";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }

                    filtroBasico.TipoContrato = "01";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }

                    filtroBasico.TipoContrato = "TODOS";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(filtroBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else
            {
                if (filtroBasico.TipoContrato == "00" || filtroBasico.TipoContrato == "01")
                {
                    List<string> CodCarpetas = new List<string>();
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroBasico.TipoContrato == "OBRAS")
                {
                    List<string> CodCarpetas = new List<string>();
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroBasico.TipoContrato == "TODOS")
                {
                    List<string> CodCarpetas = new List<string>();
                    //Asesorias
                    filtroBasico.TipoContrato = "00";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Estudios
                    filtroBasico.TipoContrato = "01";
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Obras
                    if (filtroBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    filtroBasico.TipoContrato = "TODOS";
                }
            }
            #endregion

            ListadoObrasEnEjecucionMasTerminados.AddRange(ListadoObrasEnEjecucion);
            ListadoObrasEnEjecucionMasTerminados.AddRange(ListadoObrasTerminados);

            return ListadoObrasEnEjecucionMasTerminados;
        }

    }
}
