using SistemaSacMvcVer2.Dominio.Common.Models.ReportesSac;
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
        public ActionResult ObtenerListadoBasicoObras(ReportesSacFiltros filtroReporteBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasPorGrupoPorEstado(filtroReporteBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato(filtroReporteBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras(ReportesSacFiltros filtroReporteBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasPorEstadoPorGrupoSoloObras(filtroReporteBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasEnEjecucionTerminados(ReportesSacFiltros filtroReporteBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasEnEjecucionTerminados(filtroReporteBasico);
            return Json(new { data = ListadoBasicoObras });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObrasEnEjecucionTerminadosTodoTipoContrato(ReportesSacFiltros filtroReporteBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObrasEnEjecucionTerminadosTodoTipoContrato(filtroReporteBasico);
            return Json(new { data = ListadoBasicoObras });
        }
    }
}