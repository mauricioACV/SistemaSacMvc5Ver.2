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
                List<string> CodigoCarpetaPorFechas = _unitOfWork.CtoContratoRepositorio.CodigosCarpetaEnGarantiaPorGrupoEntreFechas(filtroReporteBasico);

                foreach (var codigoCarpeta in CodigoCarpetaPorFechas)
                {
                    ListadoBacisoObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }
            else
            {
                ListadoBacisoObras = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoYgrupo(filtroReporteBasico);
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

        public List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBacisoObrasEstadoGrupoSoloObras = new List<ReportesSac>();
            ListadoBacisoObrasEstadoGrupoSoloObras = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico);

            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoSoloObras(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoBacisoObrasEstadoGrupoSoloObras.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            return ListadoBacisoObrasEstadoGrupoSoloObras;
        }

        public List<ReportesSac> ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            List<ReportesSac> ListadoBacisoObrasEstadoGrupoTipoContrato = new List<ReportesSac>();
            ListadoBacisoObrasEstadoGrupoTipoContrato = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico);

            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoBacisoObrasEstadoGrupoTipoContrato.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
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

            filtroReporteBasico.EstadoContrato = "EN EJECUCION";

            if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
            {
                ListadoObrasEnEjecucion.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico));
            }
            if (filtroReporteBasico.TipoContrato == "OBRAS")
            {
                ListadoObrasEnEjecucion.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico));
            }
            if(filtroReporteBasico.TipoContrato == "TODOS")
            {
                filtroReporteBasico.TipoContrato = "00";
                ListadoObrasEnEjecucion.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico));
                filtroReporteBasico.TipoContrato = "01";
                ListadoObrasEnEjecucion.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico));
                ListadoObrasEnEjecucion.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico));
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
                    ListadoObrasRegionAdmCentralEnEjecucion.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            filtroReporteBasico.EstadoContrato = "EN GARANTIA";

            if (filtroReporteBasico.TipoContrato == "00" || filtroReporteBasico.TipoContrato == "01")
            {
                ListadoObrasTerminados.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico));
            }
            if (filtroReporteBasico.TipoContrato == "OBRAS")
            {
                ListadoObrasTerminados.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico));
            }
            if (filtroReporteBasico.TipoContrato == "TODOS")
            {
                filtroReporteBasico.TipoContrato = "00";
                ListadoObrasEnEjecucion.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico));
                filtroReporteBasico.TipoContrato = "01";
                ListadoObrasEnEjecucion.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico));
                ListadoObrasEnEjecucion.AddRange(_unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico));
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
            ListadoAsesoriasEjecucion = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico);
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
            ListadoEstudiosEjecucion = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico);
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoEstudiosEjecucionAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            ListadoObrasEjecucion = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico);
            if (filtroReporteBasico.IncluirCentral)
            {
                ListadoObrasEjecucionAdmCentral = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico);
            }

            filtroReporteBasico.EstadoContrato = "EN GARANTIA";
            filtroReporteBasico.TipoContrato = "00";
            ListadoAsesoriasTerminados = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico);
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
            ListadoEstudiosTerminados = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico);
            if (filtroReporteBasico.IncluirCentral)
            {
                List<string> ListCodCarpetaObrasRegionAdmCentral = new List<string>();
                ListCodCarpetaObrasRegionAdmCentral = _unitOfWork.CtoContratoRepositorio.ObtenerObrasRegionalesAdministradasCentralPorEstadoTipoContrato(filtroReporteBasico);
                foreach (var codigoCarpeta in ListCodCarpetaObrasRegionAdmCentral)
                {
                    ListadoEstudiosTerminadosAdmCentral.Add(_unitOfWork.ReportesSacRepositorio.ObtenerDatosBasicoObrasPorCodigoCarpeta(codigoCarpeta));
                }
            }

            ListadoObrasTerminados = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico);
            if (filtroReporteBasico.IncluirCentral)
            {
                ListadoObrasTerminadosAdmCentral = _unitOfWork.ReportesSacRepositorio.ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(filtroReporteBasico);
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
