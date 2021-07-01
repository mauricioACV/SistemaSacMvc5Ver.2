using SistemaSacMvcVer2.Dominio.Entidades;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class HomeController : Controller
    {
        private CtoUsuario objUsuario;

        public ActionResult Index()
        {
            objUsuario = (CtoUsuario)Session["UserSession"];
            Session["NombresUser"] = objUsuario.Nombres;
            Session["ApellidosUser"] = objUsuario.Apellidos;
            Session["GrupoUser"] = objUsuario.Grupo;
            Session["CuentaUser"] = objUsuario.Usuario;
            return View();
        }
    }
}