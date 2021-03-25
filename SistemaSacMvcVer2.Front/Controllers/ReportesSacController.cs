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
        public ActionResult ListadoObras()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObras(ReportesSacFiltros filtroReporteBasico)
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObras(filtroReporteBasico);
            return Json(new { data = ListadoBasicoObras });
        }
    }
}