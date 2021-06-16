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
                List<string> CodCarpetaGarantiaPorFechas = new List<string>();

                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetaGarantiaPorFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetaGarantiaPorFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorClaseEntreFechas(filtroReporteBasico);
                }
                foreach (var codigoCarpeta in CodCarpetaGarantiaPorFechas)
                {
                    ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetaLiquidadoPorFechas = new List<string>();

                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetaLiquidadoPorFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetaLiquidadoPorFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorClaseEntreFechas(filtroReporteBasico);
                }
                foreach (var codigoCarpeta in CodCarpetaLiquidadoPorFechas)
                {
                    ListadoBacisoObrasPorGrupoPorEstado.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else
            {
                List<string> ListCodCarpeta = new List<string>();

                if (filtroReporteBasico.Clase == null)
                {
                    ListCodCarpeta = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorGrupoPorEstado(filtroReporteBasico);
                }
                else
                {
                    ListCodCarpeta = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorGrupoPorEstadoPorClase(filtroReporteBasico);
                }
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
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetasObrasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasObrasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(filtroReporteBasico);
                }
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
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetasObrasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoSoloObrasEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasObrasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorClaseSoloObrasEntreFechas(filtroReporteBasico);
                }
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
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroReporteBasico);
                }
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
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                }
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
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaLiquidadosPorGrupoPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                }
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
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroReporteBasico);
                }
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
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroReporteBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            if (filtroReporteBasico.TipoContrato == "OBRAS")
            {
                List<string> CodCarpetas = new List<string>();
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroReporteBasico);
                }
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
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroReporteBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                //Estudios
                filtroReporteBasico.TipoContrato = "01";
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroReporteBasico);
                }
                foreach (var codigoCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
                //Obras
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroReporteBasico);
                }
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
                    if(filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    if(filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "TODOS")
                {
                    filtroReporteBasico.TipoContrato = "00";
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }

                    filtroReporteBasico.TipoContrato = "01";
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                                       
                    filtroReporteBasico.TipoContrato = "TODOS";
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(filtroReporteBasico);
                    }
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
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroReporteBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    List<string> CodCarpetas = new List<string>();
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroReporteBasico);
                    }
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
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroReporteBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Estudios
                    filtroReporteBasico.TipoContrato = "01";
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContrato(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaPorEstadoPorGrupoPorTipoContratoPorClase(filtroReporteBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Obras
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstado(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasPorGrupoPorEstadoPorClase(filtroReporteBasico);
                    }
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

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoObrasRegionPorGrupoAdmin = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin = new List<string>();
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminEnGarantiaEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorClaseEnGarantiaEntreFechas(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetaObrasEnGarantiaPorRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin = new List<string>();
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminPorClaseEntreFechas(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetaObrasLiquidadasPorRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else
            {
                List<string> CodCarpetaObrasRegionPorGrupoAdmin = new List<string>();
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetaObrasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetaObrasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorClase(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetaObrasRegionPorGrupoAdmin)
                {
                    ListadoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            return ListadoObrasRegionPorGrupoAdmin;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBasicoObrasRegionPorGrupoAdmin = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasEnGarantiaRegionPorGrupoAdminFechas = new List<string>();
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetasEnGarantiaRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasEnGarantiaRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetasEnGarantiaRegionPorGrupoAdminFechas)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasLiquidadosRegionPorGrupoAdminFechas = new List<string>();
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetasLiquidadosRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasLiquidadosRegionPorGrupoAdminFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaRegionLiquidadosPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetasLiquidadosRegionPorGrupoAdminFechas)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            else
            {
                List<string> CodCarpetasRegionPorGrupoAdmin = new List<string>();
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasRegionPorGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetasRegionPorGrupoAdmin)
                {
                    ListadoBasicoObrasRegionPorGrupoAdmin.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            return ListadoBasicoObrasRegionPorGrupoAdmin;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoSoloObras(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBasicoObrasRegionGrupoAdminSoloObras = new List<ReportesSac>();

            if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "EN GARANTIA")
            {
                List<string> CodCarpetasObrasRegionGrupoAdminGarantiaFechas = new List<string>();
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetasObrasRegionGrupoAdminGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasObrasRegionGrupoAdminGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminPorClaseEntreFechas(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetasObrasRegionGrupoAdminGarantiaFechas)
                {
                    ListadoBasicoObrasRegionGrupoAdminSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

            }
            else if (filtroReporteBasico.RangoFecha && filtroReporteBasico.EstadoContrato == "LIQUIDADO")
            {
                List<string> CodCarpetasObrasRegionGrupoAdminLiquidadoFechas = new List<string>();
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetasObrasRegionGrupoAdminLiquidadoFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminEntreFechas(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasObrasRegionGrupoAdminLiquidadoFechas = _unitOfWork.CtoContratoModificaRepositorio.CodigosCarpetaSoloObrasLiquidadosRegionPorGrupoAdminPorClaseEntreFechas(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetasObrasRegionGrupoAdminLiquidadoFechas)
                {
                    ListadoBasicoObrasRegionGrupoAdminSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }

            }
            else
            {
                List<string> CodCarpetasSoloObrasRegionGrupoAdmin = new List<string>();
                if(filtroReporteBasico.Clase == null)
                {
                    CodCarpetasSoloObrasRegionGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroReporteBasico);
                }
                else
                {
                    CodCarpetasSoloObrasRegionGrupoAdmin = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetasSoloObrasRegionGrupoAdmin)
                {
                    ListadoBasicoObrasRegionGrupoAdminSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            return ListadoBasicoObrasRegionGrupoAdminSoloObras;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasRegionPorGrupoAdminEjEjecucionMasTerminados(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoObrasEnEjecucionMasTerminados = new List<ReportesSac>();

            List<ReportesSac> ListadoObrasEnEjecucion = new List<ReportesSac>();
            List<ReportesSac> ListadoObrasTerminados = new List<ReportesSac>();

            #region "Obtener En Ejecucion"

            filtroReporteBasico.EstadoContrato = "EN EJECUCION";

            if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
            {
                List<string> CodCarpetas = new List<string>();
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            if (filtroReporteBasico.TipoContrato == "OBRAS")
            {
                List<string> CodCarpetas = new List<string>();
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
            }
            if (filtroReporteBasico.TipoContrato == "TODOS")
            {
                List<string> CodCarpetas = new List<string>();
                //Asesorias
                filtroReporteBasico.TipoContrato = "00";
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                //Estudios
                filtroReporteBasico.TipoContrato = "01";
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                //Obras
                if (filtroReporteBasico.Clase == null)
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroReporteBasico);
                }
                else
                {
                    CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroReporteBasico);
                }
                foreach (var codCarpeta in CodCarpetas)
                {
                    ListadoObrasEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                }
                filtroReporteBasico.TipoContrato = "TODOS";
            }
            #endregion

            #region "Obtener En Garantía"

            filtroReporteBasico.EstadoContrato = "EN GARANTIA";

            if (filtroReporteBasico.RangoFecha)
            {
                List<string> CodCarpetasGarantiaFechas = new List<string>();

                if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                {
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasEnGarantiaRegionPorGrupoAdminPorClaseEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "TODOS")
                {
                    filtroReporteBasico.TipoContrato = "00";
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }

                    filtroReporteBasico.TipoContrato = "01";
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosEnGarantiaRegionPorGrupoAdminPorTipoContratoPorClaseEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }

                    filtroReporteBasico.TipoContrato = "TODOS";
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoSoloObrasEntreFechas(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetasGarantiaFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoPorTipoPorClaseSoloObrasEntreFechas(filtroReporteBasico);
                    }
                    foreach (var codCarpeta in CodCarpetasGarantiaFechas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codCarpeta));
                    }
                }
            }
            else
            {
                if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
                {
                    List<string> CodCarpetas = new List<string>();
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroReporteBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                }
                if (filtroReporteBasico.TipoContrato == "OBRAS")
                {
                    List<string> CodCarpetas = new List<string>();
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroReporteBasico);
                    }
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
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroReporteBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Estudios
                    filtroReporteBasico.TipoContrato = "01";
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContrato(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaContratosRegionPorGrupoAdminPorEstadoContratoPorTipoContratoPorClase(filtroReporteBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    //Obras
                    if (filtroReporteBasico.Clase == null)
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstado(filtroReporteBasico);
                    }
                    else
                    {
                        CodCarpetas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaSoloObrasRegionPorGrupoAdminPorEstadoPorClase(filtroReporteBasico);
                    }
                    foreach (var codigoCarpeta in CodCarpetas)
                    {
                        ListadoObrasTerminados.Add(_unitOfWork.ReportesSacRepositorio.ObtenerReporteBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                    }
                    filtroReporteBasico.TipoContrato = "TODOS";
                }
            }
            #endregion

            ListadoObrasEnEjecucionMasTerminados.AddRange(ListadoObrasEnEjecucion);
            ListadoObrasEnEjecucionMasTerminados.AddRange(ListadoObrasTerminados);

            return ListadoObrasEnEjecucionMasTerminados;
        }

    }
}
