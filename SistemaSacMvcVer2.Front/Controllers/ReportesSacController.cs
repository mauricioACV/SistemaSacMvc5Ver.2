using SistemaSacMvcVer2.Dominio.Interfaces.ICtoGrupoClase;
using SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class ReportesSacController : Controller
    {
        private readonly ICtoGrupoClaseServicio _ctoGrupoClaseServicio;
        private readonly IReportesSacServicio _reportesSacServicio;

        public ReportesSacController(ICtoGrupoClaseServicio ctoGrupoClaseServicio, IReportesSacServicio reportesSacServicio)
        {
            _ctoGrupoClaseServicio = ctoGrupoClaseServicio;
            _reportesSacServicio = reportesSacServicio;
        }

        // GET: ReportesSac
        public ActionResult ListadoObras()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerListadoGrupos()
        {
            var ListadoGrupos = _ctoGrupoClaseServicio.ListarGrupoClase();
            return Json(new { data = ListadoGrupos });
        }

        [HttpPost]
        public ActionResult ObtenerRegiones()
        {
            var ListadoRegiones = _ctoGrupoClaseServicio.ObtenerRegiones();
            return Json(new { data = ListadoRegiones });
        }

        [HttpPost]
        public ActionResult ObtenerListadoBasicoObras()
        {
            var ListadoBasicoObras = _reportesSacServicio.ObtenerListadoBasicoObras();
            return Json(new { data = ListadoBasicoObras });
        }
    }
}