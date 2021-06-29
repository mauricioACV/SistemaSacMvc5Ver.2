using SistemaSacMvcVer2.Dominio.Interfaces.ICtoUsuario;
using System;
using System.Web.Mvc;

namespace SistemaSacMvcVer2.Front.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ICtoUsuarioServicio _ctoUsuarioServicio;

        public AccesoController(ICtoUsuarioServicio ctoUsuarioServicio)
        {
            _ctoUsuarioServicio = ctoUsuarioServicio;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtUser, string txtPass)
        {
            try
            {
                var CtoUsuario = _ctoUsuarioServicio.ObtenerUsuario(txtUser, txtPass);

                if (CtoUsuario.Usuario == null)
                {
                    ViewBag.MensajeError = "Usuario no existe o contraseña no válida";
                    return View();
                }

                Session["UserSession"] = CtoUsuario;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}