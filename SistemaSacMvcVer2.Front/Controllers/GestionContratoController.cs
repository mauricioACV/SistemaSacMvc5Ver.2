using SistemaSacMvcVer2.Infraestructura.Interfaces;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class GestionContratoController : Controller
    {
        private readonly IUnitOfWebService _unitOfWebService;

        public GestionContratoController(IUnitOfWebService unitOfWebService)
        {
            _unitOfWebService = unitOfWebService;
        }

        // GET: GestionContrato
        public ActionResult NuevoContrato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerInfoContratoPorCodigoSafi(int codigoSafi)
        {
            var ListadoSafi = _unitOfWebService.SafiWebServiceRepositorio.ObtenerInfoContratoPorCodigoSafi(codigoSafi);
            return Json(new { data = ListadoSafi });
        }
    }
}