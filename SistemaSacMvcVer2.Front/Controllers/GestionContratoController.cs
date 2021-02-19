using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato;
using SistemaSacMvcVer2.Infraestructura.Interfaces;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class GestionContratoController : Controller
    {
        private readonly ICtoContratoServicio _ctoContratoServicio;
        private readonly IUnitOfWebService _unitOfWebService;

        public GestionContratoController(ICtoContratoServicio ctoContratoServicio, IUnitOfWebService unitOfWebService)
        {
            _ctoContratoServicio = ctoContratoServicio;
            _unitOfWebService = unitOfWebService;
        }

        // GET: GestionContrato
        public ActionResult NuevoContrato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerItemsPorDominio(string pDominio)
        {            
            var ListadoTipoDominioPorUsuario = _ctoContratoServicio.ListarItemsPorDominio(pDominio);
            return Json(new { data = ListadoTipoDominioPorUsuario });
        }

        [HttpPost]
        public ActionResult ObtenerItemsPorDominioUsuario(string pDominio, string pGrupoUsuario)
        {
            var ListadoTipoDominio = _ctoContratoServicio.ListarItemsPorDominioUsuario(pDominio, pGrupoUsuario);
            return Json(new { data = ListadoTipoDominio });
        }

        [HttpPost]
        public ActionResult ObtenerItemsAdministracionPorClaseUsuario(string pGrupoUsuario)
        {
            var ListadoClase = _ctoContratoServicio.ListarAdministracionPorClaseUsuario(pGrupoUsuario);
            return Json(new { data = ListadoClase });
        }

        [HttpPost]
        public ActionResult ObtenerInfoContratoPorCodigoSafi(int codigoSafi)
        {
            var ListadoSafi = _unitOfWebService.SafiWebServiceRepositorio.ObtenerInfoContratoPorCodigoSafi(codigoSafi);
            return Json(new { data = ListadoSafi });
        }

        [HttpPost]
        public ActionResult ObtenerItemsIndiceBase()
        {
            var ItemsIndiceBase = _ctoContratoServicio.ListarItemsIndiceBase();
            return Json(new { data = ItemsIndiceBase });
        }

        [HttpPost]
        public ActionResult ObtenerListadoInspectorFiscalActivos()
        {
            var ItemsListadoInspectorFiscal = _ctoContratoServicio.ObtenerListadoInspectorFiscalActivos();
            return Json(new { data = ItemsListadoInspectorFiscal });
        }

        [HttpPost]
        public ActionResult ObtenerListadoVisitadoresActivos()
        {
            var ItemsListadoVisitadores = _ctoContratoServicio.ObtenerListadoVisitadoresActivos();
            return Json(new { data = ItemsListadoVisitadores });
        }
    }
}