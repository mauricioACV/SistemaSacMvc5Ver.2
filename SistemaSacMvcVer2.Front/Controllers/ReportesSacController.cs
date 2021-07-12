using SistemaSacMvcVer2.Dominio.Common.Models;
using SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class ReportesSacController : Controller
    {
        private readonly IReportesSacServicio _reportesSacServicio;

        public ReportesSacController(IReportesSacServicio reportesSacServicio)
        {
            _reportesSacServicio = reportesSacServicio;
        }

        // GET: ReportesSac
        public ActionResult FiltrosListadoObras()
        {
            return View();
        }

        public ActionResult ReporteBasicoDeObras()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObras(SacFiltros filtroBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasPorGrupoPorEstado(filtroBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(SacFiltros filtroBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasPorEstadoPorGrupoPorTipoContrato(filtroBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(SacFiltros filtroBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasPorEstadoPorGrupoSoloObras(filtroBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasEnEjecucionTerminados(SacFiltros filtroBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasEnEjecucionMasTerminados(filtroBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoContrato(SacFiltros filtroBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoContrato(filtroBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasRegionGrupoAdminPorTipoContrato(SacFiltros filtroBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasRegionPorGrupoAdminPorTipoContrato(filtroBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoSoloObras(SacFiltros filtroBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasRegionPorGrupoAdminPorEstadoSoloObras(filtroBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasRegionPorGrupoAdminEnEjecucionTerminados(SacFiltros filtroBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasRegionPorGrupoAdminEjEjecucionMasTerminados(filtroBasico);
            return Json(new { data = ListadoBasicoObras });
        }
    }
}