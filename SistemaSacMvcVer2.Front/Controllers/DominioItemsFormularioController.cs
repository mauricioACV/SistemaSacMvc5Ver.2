using SistemaSacMvcVer2.Dominio.Interfaces.IDominioItemsFormulario;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class DominioItemsFormularioController : Controller
    {
        private readonly IDominioItemsFormularioServicio _dominioItemsFormularioServicio;

        public DominioItemsFormularioController(IDominioItemsFormularioServicio dominioItemsFormularioServicio)
        {
            _dominioItemsFormularioServicio = dominioItemsFormularioServicio;
        }

        [HttpPost]
        public ActionResult ObtenerItemsPorDominio(string pDominio)
        {
            var ListadoTipoDominioPorUsuario = _dominioItemsFormularioServicio.ListarItemsPorDominio(pDominio);
            return Json(new { data = ListadoTipoDominioPorUsuario });
        }

        [HttpPost]
        public ActionResult ObtenerItemsPorDominioUsuario(string pDominio, string pGrupoUsuario)
        {
            var ListadoTipoDominio = _dominioItemsFormularioServicio.ListarItemsPorDominioUsuario(pDominio, pGrupoUsuario);
            return Json(new { data = ListadoTipoDominio });
        }

        [HttpPost]
        public ActionResult ObtenerItemsAdministracionPorClaseUsuario(string pGrupoUsuario)
        {
            var ListadoClase = _dominioItemsFormularioServicio.ListarAdministracionPorClaseUsuario(pGrupoUsuario);
            return Json(new { data = ListadoClase });
        }

        [HttpPost]
        public ActionResult ObtenerItemsIndiceBase()
        {
            var ItemsIndiceBase = _dominioItemsFormularioServicio.ListarItemsIndiceBase();
            return Json(new { data = ItemsIndiceBase });
        }

        [HttpPost]
        public ActionResult ObtenerListadoInspectorFiscalActivos()
        {
            var ItemsListadoInspectorFiscal = _dominioItemsFormularioServicio.ObtenerListadoInspectorFiscalActivos();
            return Json(new { data = ItemsListadoInspectorFiscal });
        }

        [HttpPost]
        public ActionResult ObtenerListadoVisitadoresActivos()
        {
            var ItemsListadoVisitadores = _dominioItemsFormularioServicio.ObtenerListadoVisitadoresActivos();
            return Json(new { data = ItemsListadoVisitadores });
        }

        [HttpPost]
        public ActionResult ObtenerAsesoriaContratosEnEjecucionOrGarantia(string pGrupoUsuario)
        {
            var ItemsListadoAsesoria = _dominioItemsFormularioServicio.ObtenerAsesoriaContratosEnEjecucionOrGarantia(pGrupoUsuario);
            return Json(new { data = ItemsListadoAsesoria });
        }

        [HttpPost]
        public ActionResult ObtenerContratistas()
        {
            var ItemsListadoContratistas = _dominioItemsFormularioServicio.ObtenerContratistas();
            return Json(new { data = ItemsListadoContratistas });
        }

        [HttpPost]
        public ActionResult ObtenerResidentesPorPalabraClave(string pPalabraClave)
        {
            var ItemsListadoResidentes = _dominioItemsFormularioServicio.BuscarResidentePorPalabraClave(pPalabraClave);
            return Json(new { data = ItemsListadoResidentes });
        }

        [HttpPost]
        public ActionResult ObtenerListadoGrupos()
        {
            var ListadoGrupos = _dominioItemsFormularioServicio.ListarGrupoClase();
            return Json(new { data = ListadoGrupos });
        }

        [HttpPost]
        public ActionResult ObtenerRegiones()
        {
            var ListadoRegiones = _dominioItemsFormularioServicio.ObtenerRegiones();
            return Json(new { data = ListadoRegiones });
        }
    }
}